#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fusion8.Cropper.Core;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    ///     Represents a form for setting options in the application.
    /// </summary>
    public partial class Options : Form
    {
        #region Member Fields

        private static readonly Regex IsNumeric = new Regex(@"^\d+$", RegexOptions.Compiled);
        
        private Form configForm;
        private readonly Hashtable errors = new Hashtable();
        private bool addingSize;

        #endregion

        #region .ctor

        public Options()
        {
            InitializeComponent();
            
            ApplyConfiguration();
            BuildOptionsNavigation();
            SetResourceStrings();
            LoadAvailablePlugins();
            LoadHotKeys();
        }

        private void ApplyConfiguration()
        {
            folderChooser.Text = Configuration.Current.OutputPath;
            fullImageTemplate.Text = Configuration.Current.FullImageTemplate;
            thumbImageTemplate.Text = Configuration.Current.ThumbImageTemplate;
            backgroundColor.BackColor = Color.FromArgb(Configuration.Current.NonFormAreaColorArgb);
            toolTip.SetToolTip(backgroundColor, $"Color\nRed:{backgroundColor.BackColor.R}\nGreen{backgroundColor.BackColor.G}\nBlue:{backgroundColor.BackColor.B}");
            colorNonFormAreaCheck.Checked = Configuration.Current.ColorNonFormArea;
            opacitySlider.Value = Convert.ToInt32(Configuration.Current.UserOpacity * 100) / 10;
            opacityValue.Text = opacitySlider.Value * 10 + "%";
            showOpacityMenu.Checked = Configuration.Current.ShowOpacityMenu;
            trapPrintScreen.Checked = Configuration.Current.TrapPrintScreen;
            hideAfterCapture.Checked = Configuration.Current.HideFormAfterCapture;
            keepPrntScrnOnClipboard.Checked = Configuration.Current.LeavePrintScreenOnClipboard;
            allowMultipleCropperInstances.Checked = Configuration.Current.AllowMultipleInstances;
            includeMouseCursorInCapture.Checked = Configuration.Current.IncludeMouseCursorInCapture;

            foreach (CropSize size in Configuration.Current.PredefinedSizes)
                predefinedSizeList.Items.Add(size);
            foreach (double size in Configuration.Current.PredefinedThumbSizes)
                predefinedThumbSizeList.Items.Add(size);
        }

        private void BuildOptionsNavigation()
        {
            foreach (TabPage page in optionsTabs.TabPages)
                page.BackColor = SystemColors.Control;

            foreach (TabPage page in optionsTabs.TabPages)
            {
                TreeNode node = optionsNavigator.Nodes.Add(page.Name, page.Text);
                node.Tag = page;
            }

            if (optionsNavigator.Nodes.Count > 0)
            {
                optionsNavigator.SelectedNode = optionsNavigator.Nodes[0];
                optionsNavigator.SelectedNode.EnsureVisible();
                optionsNavigator.Select();
            }
        }

        private void SetResourceStrings()
        {
            folder.Description = SR.FolderBrowseText;
            outputTemplatesDescription.Text = SR.OptionOutputTemplatesDescription;
            hotKeysDescription.Text = SR.OptionHotKeysDescription;
            nonRectWindowsDescription.Text = SR.OptionNonRectWindowsDescription;
        }

        private void LoadAvailablePlugins()
        {
            pluginsComboBox.Items.Clear();
            pluginsComboBox.Items.Add("Select Plug-in");
            foreach (IPersistableImageFormat format in ImageCapture.ImageOutputs)
            {
                if (format is IConfigurablePlugin configurable && configurable.ConfigurationForm != null)
                    pluginsComboBox.Items.Add(configurable);
            }

            pluginsComboBox.SelectedIndex = 0;
        }

        private void LoadHotKeys()
        {
            hotKeySelection.HotKeyRegister += HotKeySelectionOnHotKeyRegister;
            hotKeySelection.ShowGroups = true;
            hotKeySelection.AddRange(HotKeys.GetRegisteredHotKeys());
        }

        #endregion

        #region Dpi Scaling

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            ScaleControls(e.DeviceDpiNew, e.DeviceDpiOld);
            base.OnDpiChanged(e);
        }

        private void ScaleControls(int deviceDpiNew, int deviceDpiOld)
        {
            float dpiScale = deviceDpiNew / 96.0f;
            Font prototype = new Font(DefaultFont.FontFamily, DefaultFont.Size * dpiScale);
            foreach (Control control in this.GetControlHierarchy())
            {
                switch (control)
                {
                    case TextBox _:
                    case ShortcutTextBox _:
                    case TreeView _:
                    case ComboBox _:
                        control.Font = new Font(prototype, control.Font.Style);
                        break;
                    case ListView listView:
                        listView.Font = new Font(prototype, listView.Font.Style);
                        float headerScale = deviceDpiNew / (float) deviceDpiOld;
                        foreach (ColumnHeader column in listView.Columns)
                            column.Width = (int) (column.Width * headerScale);
                        break;
                }
            }

            if(configForm == null)
                return;
            
            foreach (Control control in pluginConfigHostPanel.GetControlHierarchy())
            {
                switch (control)
                {
                    case TextBox _:
                    case ShortcutTextBox _:
                    case TreeView _:
                    case ComboBox _:
                        control.Font = new Font(prototype, control.Font.Style);
                        break;
                    case ListView listView:
                        listView.Font = new Font(prototype, listView.Font.Style);
                        float headerScale = deviceDpiNew / (float)deviceDpiOld;
                        foreach (ColumnHeader column in listView.Columns)
                            column.Width = (int)(column.Width * headerScale);
                        break;
                }
            }
        }

        #endregion

        protected override void OnShown(EventArgs e)
        {
            MoveAround();
            base.OnShown(e);
        }

        private void MoveAround()
        {
            Point targetLocation = Location;

            Screen currentScreen = Screen.FromControl(this);
            if (!currentScreen.Primary)
                Location = Screen.PrimaryScreen.Bounds.Location;

            Location = targetLocation;
            if (DeviceDpi > 96)
                Location = new Point(Location.X - 120, Location.Y - 120);
        }

        private void HotKeySelectionOnHotKeyRegister(object sender, HotKeyRegistrationEventArgs e)
        {
            HotKeys.Unregister(e.OldKeyData, Owner);
            if (e.Global)
                HotKeys.RegisterGlobal(e.Id, e.KeyData, Owner, e.Name, e.Action);
            else
                HotKeys.RegisterLocal(e.Id, e.KeyData, e.Name, e.Action);
        }

        private static bool ValidateFileName(string name)
        {
            return !(name.IndexOfAny(new[] {'/', '*', ':', '?', '"', '<', '>', '|'}) >= 0);
        }

        private void HandleFolderChooserButtonClick(object sender, EventArgs e)
        {
            if (folder.ShowDialog() == DialogResult.OK)
                folderChooser.Text = folder.SelectedPath;
        }

        private void HandleOkClick(object sender, EventArgs e)
        {
            if (addingSize)
            {
                addingSize = false;
                return;
            }

            Configuration.Current.OutputPath = Environment.ExpandEnvironmentVariables(folderChooser.Text);
            if (ValidateFileName(fullImageTemplate.Text))
                Configuration.Current.FullImageTemplate = fullImageTemplate.Text;
            if (ValidateFileName(thumbImageTemplate.Text))
                Configuration.Current.ThumbImageTemplate = thumbImageTemplate.Text;

            Configuration.Current.ColorNonFormArea = colorNonFormAreaCheck.Checked;
            Configuration.Current.NonFormAreaColorArgb = backgroundColor.BackColor.ToArgb();
            Configuration.Current.UserOpacity = (double) (opacitySlider.Value * 10) / 100;
            Configuration.Current.ShowOpacityMenu = showOpacityMenu.Checked;
            Configuration.Current.TrapPrintScreen = trapPrintScreen.Checked;
            Configuration.Current.HideFormAfterCapture = hideAfterCapture.Checked;
            Configuration.Current.LeavePrintScreenOnClipboard = keepPrntScrnOnClipboard.Checked;
            Configuration.Current.AllowMultipleInstances = allowMultipleCropperInstances.Checked;
            Configuration.Current.IncludeMouseCursorInCapture = includeMouseCursorInCapture.Checked;
            Configuration.Current.PredefinedSizes = predefinedSizeList.Items.Cast<CropSize>().ToArray();
            Configuration.Current.PredefinedThumbSizes = predefinedThumbSizeList.Items.Cast<double>().ToArray();
            Configuration.Current.HotKeySettings = HotKeys.GetRegisteredHotKeys(true).Select(hk => new HotKeySetting {Id = hk.Id, KeyCode = (int) hk.KeyData}).ToArray();

            List<object> pluginSettings = new List<object>();
            foreach (IPersistableImageFormat output in ImageCapture.ImageOutputs)
            {
                IConfigurablePlugin plugin = output as IConfigurablePlugin;
                plugin?.ConfigurationForm?.Save();
                if (plugin?.Settings != null)
                    pluginSettings.Add(plugin.Settings);
            }
            Configuration.Current.PluginSettings = pluginSettings.ToArray();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void HandleFullImageMenuButtonClick(object sender, EventArgs e)
        {
            currentTextBox = fullImageTemplate;
            templateMenu.Show(fullImageMenuButton, new Point(fullImageMenuButton.Width, 0));
        }

        private void HandleThumbImageMenuButtonClick(object sender, EventArgs e)
        {
            currentTextBox = thumbImageTemplate;
            templateMenu.Show(thumbImageMenuButton, new Point(thumbImageMenuButton.Width, 0));
        }

        private void HandleTemplateItemClick(object sender, EventArgs e)
        {
            if (sender is MenuItem item)
                InsertTemplate(currentTextBox, "{" + item.Text.ToLower() + "}");
            
            currentTextBox.Focus();
            currentTextBox.SelectionLength = 0;
        }

        private void HandleTextBoxTextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox validateBox))
                return;

            if (!ValidateFileName(validateBox.Text))
            {
                if (!errors.ContainsKey(validateBox))
                    errors.Add(validateBox, SR.MessageInvalidTemplateCharacters);
                errorProvider.SetError(validateBox, SR.MessageInvalidTemplateCharacters);
                okButton.Enabled = false;
            }
            else
            {
                errors.Remove(validateBox);
                errorProvider.SetError(validateBox, string.Empty);
                if (errors.Count == 0)
                    okButton.Enabled = true;
            }
        }

        private void HandleDirectoryTextChanged(object sender, EventArgs e)
        {
            try
            {
                new DirectoryInfo(folderChooser.Text);
                errors.Remove(folderChooser);
                errorProvider.SetError(folderChooser, string.Empty);
                if (errors.Count == 0)
                    okButton.Enabled = true;
            }
            catch (NotSupportedException)
            {
                if (!errors.ContainsKey(folderChooser))
                    errors.Add(folderChooser, SR.MessageInvalidPathCharacters);
                errorProvider.SetError(folderChooser, SR.MessageInvalidPathCharacters);
                okButton.Enabled = false;
            }
            catch (ArgumentException)
            {
                if (!errors.ContainsKey(folderChooser))
                    errors.Add(folderChooser, SR.MessageInvalidPathCharacters);
                errorProvider.SetError(folderChooser, SR.MessageInvalidPathCharacters);
                okButton.Enabled = false;
            }
        }

        private void HandleDefaultTemplateClicked(object sender, EventArgs e)
        {
            if (currentTextBox == fullImageTemplate)
                currentTextBox.Text = FileNameTemplate.DefaultFullImageTemplate;
            if (currentTextBox == thumbImageTemplate)
                currentTextBox.Text = FileNameTemplate.DefaultThumbImageTemplate;
        }

        private void HandleColorChooserButtonClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                backgroundColor.BackColor = colorDialog.Color;
                toolTip.SetToolTip(backgroundColor, $"Color\nRed:{backgroundColor.BackColor.R}\nGreen{backgroundColor.BackColor.G}\nBlue:{backgroundColor.BackColor.B}");
            }
        }

        private void HandleOpacitySliderValueChanged(object sender, EventArgs e)
        {
            opacityValue.Text = opacitySlider.Value * 10 + "%";
        }

        private void HandlePluginSelectionChanged(object sender, EventArgs e)
        {
            if (configForm != null)
            {
                configForm.Hide();
                pluginConfigHostPanel.Controls.Remove(configForm);
                configForm = null;
            }

            IConfigurablePlugin plugin = pluginsComboBox.SelectedItem as IConfigurablePlugin;
            if (plugin?.ConfigurationForm != null)
            {
                configForm = plugin.ConfigurationForm;
                configForm.PerformAutoScale();

                if (plugin.HostInOptions)
                    ShowHostedConfiguration();
                else
                    ShowDialogConfiguration();
            }
        }

        private void HandleAddSizeClick(object sender, EventArgs e)
        {
            AddSize();
        }

        private void HandleRemoveSizeClick(object sender, EventArgs e)
        {
            int index = predefinedSizeList.SelectedIndex;

            predefinedSizeList.Items.Remove(predefinedSizeList.SelectedItem);
            predefinedSizeList.Focus();
            if (predefinedSizeList.Items.Count > 0)
                predefinedSizeList.SelectedIndex = index > predefinedSizeList.Items.Count - 1 ? predefinedSizeList.Items.Count - 1 : index;
        }

        private void HandleSizeInputEnter(object sender, EventArgs e)
        {
            if (!(sender is TextBox box))
                return;

            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
        }

        private void HandleSizeInputPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            addingSize = true;
            AddSize();
        }

        private void HandleOptionsNavigatorAfterSelect(object sender, TreeViewEventArgs e)
        {
            TabPage page = (TabPage) e.Node.Tag;
            optionsTabs.SelectTab(page);
        }

        private static void InsertTemplate(TextBoxBase templateBox, string template)
        {
            templateBox.SelectedText = template;
        }

        private void ShowHostedConfiguration()
        {
            configForm.TopLevel = false;
            configForm.FormBorderStyle = FormBorderStyle.None;
            configForm.Dock = DockStyle.Fill;
            pluginConfigHostPanel.Controls.Add(configForm);
            
            float dpiScale = DeviceDpi / 96.0f;
            Font prototype = new Font(DefaultFont.FontFamily, DefaultFont.Size * dpiScale);
            foreach (Control control in pluginConfigHostPanel.GetControlHierarchy())
            {
                switch (control)
                {
                    case TextBox _:
                    case ShortcutTextBox _:
                    case TreeView _:
                    case ComboBox _:
                        control.Font = new Font(prototype, control.Font.Style);
                        break;
                    case ListView listView:
                        listView.Font = new Font(prototype, listView.Font.Style);
                        float headerScale = DeviceDpi / (float)DeviceDpi;
                        foreach (ColumnHeader column in listView.Columns)
                            column.Width = (int)(column.Width * headerScale);
                        break;
                }
            }
            configForm.Show();
            configForm.PerformAutoScale();
        }

        private void ShowDialogConfiguration()
        {
            configForm.StartPosition = FormStartPosition.CenterParent;
            configForm.ShowDialog(this);
        }

        private void AddSize()
        {
            if (!IsNumeric.Match(widthInput.Text).Success || !IsNumeric.Match(heightInput.Text).Success)
                return;

            CropSize size = new CropSize(
                Convert.ToInt32(widthInput.Text),
                Convert.ToInt32(heightInput.Text));

            if (!predefinedSizeList.Items.Contains(size))
            {
                predefinedSizeList.Items.Add(size);

                List<CropSize> cropSize = new List<CropSize>();
                foreach (CropSize item in predefinedSizeList.Items)
                    cropSize.Add(item);

                predefinedSizeList.Items.Clear();
                CropSize[] sizes = cropSize.ToArray();
                Array.Sort(sizes);
                foreach (CropSize item in sizes)
                    predefinedSizeList.Items.Add(item);
            }

            widthInput.Focus();
        }

        private void SizeInputTextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox box))
                return;

            errorProvider.SetError(box, !IsNumeric.Match(box.Text).Success ? "Only numeric values are valid." : null);
        }

        private void HandleAddThumbSizeClick(object sender, EventArgs e)
        {
            AddThumbSize();
        }

        private void AddThumbSize()
        {
            if (!IsNumeric.Match(thumbMaxInput.Text).Success) return;
            double size = Convert.ToDouble(thumbMaxInput.Text);

            if (!predefinedThumbSizeList.Items.Contains(size))
            {
                predefinedThumbSizeList.Items.Add(size);

                List<double> cropSize = new List<double>();
                foreach (double item in predefinedThumbSizeList.Items)
                    cropSize.Add(item);

                predefinedThumbSizeList.Items.Clear();
                double[] sizes = cropSize.ToArray();
                Array.Sort(sizes);
                foreach (double item in sizes)
                    predefinedThumbSizeList.Items.Add(item);
            }

            thumbMaxInput.Focus();
        }

        private void HandleRemoveThumbSizeClick(object sender, EventArgs e)
        {
            int index = predefinedThumbSizeList.SelectedIndex;

            predefinedThumbSizeList.Items.Remove(predefinedThumbSizeList.SelectedItem);
            predefinedThumbSizeList.Focus();
            if (predefinedThumbSizeList.Items.Count > 0)
                predefinedThumbSizeList.SelectedIndex = index > predefinedThumbSizeList.Items.Count - 1 ? predefinedThumbSizeList.Items.Count - 1 : index;
        }

        private void HandleThumbSizeInputEnter(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box == null)
                return;

            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
        }

        private void HandleThumbSizeInputPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            addingSize = true;
            AddThumbSize();
        }

        private void ThumbSizeInputTextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box == null)
                return;

            errorProvider.SetError(box, !IsNumeric.Match(box.Text).Success ? "Only numeric values are valid." : null);
        }
    }

    public class DpiAwareTextBox : TextBox
    {
        protected override void OnDpiChangedBeforeParent(EventArgs e)
        {
            base.OnDpiChangedBeforeParent(e);
        }

        protected override void OnDpiChangedAfterParent(EventArgs e)
        {
            
            base.OnDpiChangedAfterParent(e);
        }
    }
}