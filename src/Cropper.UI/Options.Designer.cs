using System.Windows.Forms;
using Fusion8.Cropper.Core;

namespace Fusion8.Cropper
{
    public partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();
            base.Dispose(disposing);
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folder = new System.Windows.Forms.FolderBrowserDialog();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.templateMenu = new System.Windows.Forms.ContextMenu();
            this.templateIncrement = new System.Windows.Forms.MenuItem();
            this.templateDate = new System.Windows.Forms.MenuItem();
            this.templateTime = new System.Windows.Forms.MenuItem();
            this.templateTimestamp = new System.Windows.Forms.MenuItem();
            this.templateExtension = new System.Windows.Forms.MenuItem();
            this.seperator1 = new System.Windows.Forms.MenuItem();
            this.templateUser = new System.Windows.Forms.MenuItem();
            this.templateDomain = new System.Windows.Forms.MenuItem();
            this.templateMachine = new System.Windows.Forms.MenuItem();
            this.seperator2 = new System.Windows.Forms.MenuItem();
            this.templatePrompt = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.widthInput = new Fusion8.Cropper.DpiAwareTextBox();
            this.heightInput = new Fusion8.Cropper.DpiAwareTextBox();
            this.folderChooser = new System.Windows.Forms.TextBox();
            this.fullImageTemplate = new System.Windows.Forms.TextBox();
            this.thumbImageTemplate = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.outputFolderGroup = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.outputFolderDescription = new System.Windows.Forms.Label();
            this.labelOutputFolder = new System.Windows.Forms.Label();
            this.fullImageMenuButton = new Fusion8.Cropper.Core.DropDownButton();
            this.thumbImageMenuButton = new Fusion8.Cropper.Core.DropDownButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.optionsNavigator = new System.Windows.Forms.TreeView();
            this.line = new System.Windows.Forms.Label();
            this.optionsTabs = new Fusion8.Cropper.Core.TablessTabControl();
            this.appearanceTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.opacityDescription = new System.Windows.Forms.Label();
            this.opacityValue = new System.Windows.Forms.Label();
            this.opacitySlider = new System.Windows.Forms.TrackBar();
            this.hideAfterCapture = new System.Windows.Forms.CheckBox();
            this.showOpacityMenu = new System.Windows.Forms.CheckBox();
            this.behaviorTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rememberLocation = new System.Windows.Forms.CheckBox();
            this.allowMultipleCropperInstances = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.predefinedSizeList = new System.Windows.Forms.ListBox();
            this.buttonAddSize = new System.Windows.Forms.Button();
            this.buttonRemoveSize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outputTab = new System.Windows.Forms.TabPage();
            this.outputTemplateGroup = new System.Windows.Forms.GroupBox();
            this.outputTemplatesDescription = new System.Windows.Forms.Label();
            this.labelFullImageTemplate = new System.Windows.Forms.Label();
            this.labelThumbImageTemplate = new System.Windows.Forms.Label();
            this.capturesTab = new System.Windows.Forms.TabPage();
            this.hotKeysGroup = new System.Windows.Forms.GroupBox();
            this.keepPrntScrnOnClipboard = new System.Windows.Forms.CheckBox();
            this.hotKeysDescription = new System.Windows.Forms.Label();
            this.trapPrintScreen = new System.Windows.Forms.CheckBox();
            this.nonRectangularCapturesGroup = new System.Windows.Forms.GroupBox();
            this.colorChooserButton = new System.Windows.Forms.Button();
            this.nonRectWindowsDescription = new System.Windows.Forms.Label();
            this.colorNonFormAreaCheck = new System.Windows.Forms.CheckBox();
            this.backgroundColor = new System.Windows.Forms.Panel();
            this.otherOptionsDescription = new System.Windows.Forms.GroupBox();
            this.includeMouseCursorInCapture = new System.Windows.Forms.CheckBox();
            this.keyboardTab = new System.Windows.Forms.TabPage();
            this.keyboardShortcutsGroup = new System.Windows.Forms.GroupBox();
            this.hotKeySelection = new Fusion8.Cropper.Core.HotKeySelection();
            this.pluginsTab = new System.Windows.Forms.TabPage();
            this.pluginConfigHostPanel = new System.Windows.Forms.Panel();
            this.pluginsComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.outputFolderGroup.SuspendLayout();
            this.optionsTabs.SuspendLayout();
            this.appearanceTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
            this.behaviorTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.outputTab.SuspendLayout();
            this.outputTemplateGroup.SuspendLayout();
            this.capturesTab.SuspendLayout();
            this.hotKeysGroup.SuspendLayout();
            this.nonRectangularCapturesGroup.SuspendLayout();
            this.otherOptionsDescription.SuspendLayout();
            this.keyboardTab.SuspendLayout();
            this.keyboardShortcutsGroup.SuspendLayout();
            this.pluginsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(325, 405);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.HandleOkClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(410, 405);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            // 
            // templateMenu
            // 
            this.templateMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.templateIncrement,
            this.templateDate,
            this.templateTime,
            this.templateTimestamp,
            this.templateExtension,
            this.seperator1,
            this.templateUser,
            this.templateDomain,
            this.templateMachine,
            this.seperator2,
            this.templatePrompt,
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // templateIncrement
            // 
            this.templateIncrement.Index = 0;
            this.templateIncrement.Text = "Increment";
            this.templateIncrement.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // templateDate
            // 
            this.templateDate.Index = 1;
            this.templateDate.Text = "Date";
            this.templateDate.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // templateTime
            // 
            this.templateTime.Index = 2;
            this.templateTime.Text = "Time";
            this.templateTime.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // templateTimestamp
            // 
            this.templateTimestamp.Index = 3;
            this.templateTimestamp.Text = "Timestamp";
            this.templateTimestamp.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // templateExtension
            // 
            this.templateExtension.Index = 4;
            this.templateExtension.Text = "Extension";
            this.templateExtension.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // seperator1
            // 
            this.seperator1.Index = 5;
            this.seperator1.Text = "-";
            // 
            // templateUser
            // 
            this.templateUser.Index = 6;
            this.templateUser.Text = "User";
            this.templateUser.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // templateDomain
            // 
            this.templateDomain.Index = 7;
            this.templateDomain.Text = "Domain";
            this.templateDomain.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // templateMachine
            // 
            this.templateMachine.Index = 8;
            this.templateMachine.Text = "Machine";
            this.templateMachine.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // seperator2
            // 
            this.seperator2.Index = 9;
            this.seperator2.Text = "-";
            // 
            // templatePrompt
            // 
            this.templatePrompt.Index = 10;
            this.templatePrompt.Text = "Prompt";
            this.templatePrompt.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 11;
            this.menuItem1.Text = "Window";
            this.menuItem1.Visible = false;
            this.menuItem1.Click += new System.EventHandler(this.HandleTemplateItemClick);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 12;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 13;
            this.menuItem3.Text = "Default";
            this.menuItem3.Click += new System.EventHandler(this.HandleDefaultTemplateClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // widthInput
            // 
            this.errorProvider.SetIconPadding(this.widthInput, 142);
            this.widthInput.Location = new System.Drawing.Point(3, 3);
            this.widthInput.MaxLength = 4;
            this.widthInput.Name = "widthInput";
            this.widthInput.Size = new System.Drawing.Size(39, 20);
            this.widthInput.TabIndex = 0;
            this.toolTip.SetToolTip(this.widthInput, "The width of the crop form.");
            this.widthInput.TextChanged += new System.EventHandler(this.SizeInputTextChanged);
            this.widthInput.Enter += new System.EventHandler(this.HandleSizeInputEnter);
            this.widthInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HandleSizeInputPreviewKeyDown);
            // 
            // heightInput
            // 
            this.errorProvider.SetIconPadding(this.heightInput, 85);
            this.heightInput.Location = new System.Drawing.Point(66, 3);
            this.heightInput.MaxLength = 4;
            this.heightInput.Name = "heightInput";
            this.heightInput.Size = new System.Drawing.Size(39, 20);
            this.heightInput.TabIndex = 2;
            this.toolTip.SetToolTip(this.heightInput, "The height of the crop form.");
            this.heightInput.WordWrap = false;
            this.heightInput.TextChanged += new System.EventHandler(this.SizeInputTextChanged);
            this.heightInput.Enter += new System.EventHandler(this.HandleSizeInputEnter);
            this.heightInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HandleSizeInputPreviewKeyDown);
            // 
            // folderChooser
            // 
            this.errorProvider.SetIconPadding(this.folderChooser, 26);
            this.folderChooser.Location = new System.Drawing.Point(9, 98);
            this.folderChooser.Name = "folderChooser";
            this.folderChooser.Size = new System.Drawing.Size(275, 20);
            this.folderChooser.TabIndex = 4;
            this.toolTip.SetToolTip(this.folderChooser, "Environment variables in the path are supported, i.e. %userprofile%\\Desktop.");
            this.folderChooser.TextChanged += new System.EventHandler(this.HandleDirectoryTextChanged);
            // 
            // fullImageTemplate
            // 
            this.fullImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullImageTemplate.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullImageTemplate.HideSelection = false;
            this.errorProvider.SetIconPadding(this.fullImageTemplate, 24);
            this.fullImageTemplate.Location = new System.Drawing.Point(6, 108);
            this.fullImageTemplate.Name = "fullImageTemplate";
            this.fullImageTemplate.Size = new System.Drawing.Size(283, 20);
            this.fullImageTemplate.TabIndex = 2;
            this.fullImageTemplate.TextChanged += new System.EventHandler(this.HandleTextBoxTextChanged);
            // 
            // thumbImageTemplate
            // 
            this.thumbImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbImageTemplate.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thumbImageTemplate.HideSelection = false;
            this.errorProvider.SetIconPadding(this.thumbImageTemplate, 24);
            this.thumbImageTemplate.Location = new System.Drawing.Point(6, 160);
            this.thumbImageTemplate.Name = "thumbImageTemplate";
            this.thumbImageTemplate.Size = new System.Drawing.Size(283, 20);
            this.thumbImageTemplate.TabIndex = 5;
            this.thumbImageTemplate.TextChanged += new System.EventHandler(this.HandleTextBoxTextChanged);
            // 
            // outputFolderGroup
            // 
            this.outputFolderGroup.Controls.Add(this.folderChooser);
            this.outputFolderGroup.Controls.Add(this.button1);
            this.outputFolderGroup.Controls.Add(this.outputFolderDescription);
            this.outputFolderGroup.Controls.Add(this.labelOutputFolder);
            this.outputFolderGroup.Location = new System.Drawing.Point(8, 8);
            this.outputFolderGroup.Name = "outputFolderGroup";
            this.outputFolderGroup.Size = new System.Drawing.Size(316, 135);
            this.outputFolderGroup.TabIndex = 0;
            this.outputFolderGroup.TabStop = false;
            this.outputFolderGroup.Text = "Output &Location";
            this.toolTip.SetToolTip(this.outputFolderGroup, "Environment variables in the path, i.e. %userprofile%\\Desktop");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.HandleFolderChooserButtonClick);
            // 
            // outputFolderDescription
            // 
            this.outputFolderDescription.Location = new System.Drawing.Point(6, 20);
            this.outputFolderDescription.Name = "outputFolderDescription";
            this.outputFolderDescription.Size = new System.Drawing.Size(304, 59);
            this.outputFolderDescription.TabIndex = 0;
            this.outputFolderDescription.Text = "This is the root folder for all file based screenshots. Environment variables in " +
    "the path are supported, i.e. %userprofile%\\Desktop.";
            // 
            // labelOutputFolder
            // 
            this.labelOutputFolder.Location = new System.Drawing.Point(6, 79);
            this.labelOutputFolder.Name = "labelOutputFolder";
            this.labelOutputFolder.Size = new System.Drawing.Size(289, 15);
            this.labelOutputFolder.TabIndex = 1;
            this.labelOutputFolder.Text = "&Save screenshots to this folder.";
            // 
            // fullImageMenuButton
            // 
            this.fullImageMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fullImageMenuButton.BackColor = System.Drawing.SystemColors.Control;
            this.fullImageMenuButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.fullImageMenuButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fullImageMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullImageMenuButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fullImageMenuButton.Location = new System.Drawing.Point(287, 108);
            this.fullImageMenuButton.Name = "fullImageMenuButton";
            this.fullImageMenuButton.Size = new System.Drawing.Size(23, 20);
            this.fullImageMenuButton.TabIndex = 3;
            this.fullImageMenuButton.TabStop = false;
            this.fullImageMenuButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip.SetToolTip(this.fullImageMenuButton, "Insert template text.");
            this.fullImageMenuButton.UseVisualStyleBackColor = false;
            this.fullImageMenuButton.Click += new System.EventHandler(this.HandleFullImageMenuButtonClick);
            // 
            // thumbImageMenuButton
            // 
            this.thumbImageMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbImageMenuButton.BackColor = System.Drawing.SystemColors.Control;
            this.thumbImageMenuButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.thumbImageMenuButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.thumbImageMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thumbImageMenuButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.thumbImageMenuButton.Location = new System.Drawing.Point(287, 160);
            this.thumbImageMenuButton.Name = "thumbImageMenuButton";
            this.thumbImageMenuButton.Size = new System.Drawing.Size(23, 20);
            this.thumbImageMenuButton.TabIndex = 6;
            this.thumbImageMenuButton.TabStop = false;
            this.thumbImageMenuButton.Text = "6";
            this.toolTip.SetToolTip(this.thumbImageMenuButton, "Insert template text.");
            this.thumbImageMenuButton.UseVisualStyleBackColor = false;
            this.thumbImageMenuButton.Click += new System.EventHandler(this.HandleThumbImageMenuButtonClick);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // optionsNavigator
            // 
            this.optionsNavigator.Indent = 12;
            this.optionsNavigator.Location = new System.Drawing.Point(6, 6);
            this.optionsNavigator.Name = "optionsNavigator";
            this.optionsNavigator.ShowLines = false;
            this.optionsNavigator.Size = new System.Drawing.Size(133, 392);
            this.optionsNavigator.TabIndex = 3;
            this.optionsNavigator.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.HandleOptionsNavigatorAfterSelect);
            // 
            // line
            // 
            this.line.AutoSize = true;
            this.line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.line.Location = new System.Drawing.Point(151, 397);
            this.line.MaximumSize = new System.Drawing.Size(0, 1);
            this.line.MinimumSize = new System.Drawing.Size(335, 1);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(335, 1);
            this.line.TabIndex = 4;
            // 
            // optionsTabs
            // 
            this.optionsTabs.Controls.Add(this.appearanceTab);
            this.optionsTabs.Controls.Add(this.behaviorTab);
            this.optionsTabs.Controls.Add(this.outputTab);
            this.optionsTabs.Controls.Add(this.capturesTab);
            this.optionsTabs.Controls.Add(this.keyboardTab);
            this.optionsTabs.Controls.Add(this.pluginsTab);
            this.optionsTabs.Location = new System.Drawing.Point(145, 6);
            this.optionsTabs.Multiline = true;
            this.optionsTabs.Name = "optionsTabs";
            this.optionsTabs.SelectedIndex = 0;
            this.optionsTabs.Size = new System.Drawing.Size(347, 392);
            this.optionsTabs.TabIndex = 0;
            // 
            // appearanceTab
            // 
            this.appearanceTab.Controls.Add(this.tableLayoutPanel1);
            this.appearanceTab.Location = new System.Drawing.Point(4, 22);
            this.appearanceTab.Name = "appearanceTab";
            this.appearanceTab.Size = new System.Drawing.Size(339, 366);
            this.appearanceTab.TabIndex = 2;
            this.appearanceTab.Text = "Appearance";
            this.appearanceTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.opacityDescription, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.opacityValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.opacitySlider, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.hideAfterCapture, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.showOpacityMenu, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.79105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.20895F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 185);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // opacityDescription
            // 
            this.opacityDescription.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.opacityDescription, 2);
            this.opacityDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opacityDescription.Location = new System.Drawing.Point(3, 0);
            this.opacityDescription.Name = "opacityDescription";
            this.opacityDescription.Size = new System.Drawing.Size(288, 22);
            this.opacityDescription.TabIndex = 0;
            this.opacityDescription.Text = "A&djust the crop form\'s opacity level.";
            // 
            // opacityValue
            // 
            this.opacityValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opacityValue.Location = new System.Drawing.Point(3, 22);
            this.opacityValue.Name = "opacityValue";
            this.opacityValue.Size = new System.Drawing.Size(35, 31);
            this.opacityValue.TabIndex = 1;
            this.opacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opacitySlider
            // 
            this.opacitySlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opacitySlider.LargeChange = 1;
            this.opacitySlider.Location = new System.Drawing.Point(44, 25);
            this.opacitySlider.Maximum = 9;
            this.opacitySlider.Minimum = 1;
            this.opacitySlider.Name = "opacitySlider";
            this.opacitySlider.Size = new System.Drawing.Size(247, 25);
            this.opacitySlider.TabIndex = 2;
            this.opacitySlider.Value = 5;
            this.opacitySlider.ValueChanged += new System.EventHandler(this.HandleOpacitySliderValueChanged);
            // 
            // hideAfterCapture
            // 
            this.hideAfterCapture.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.hideAfterCapture, 2);
            this.hideAfterCapture.Location = new System.Drawing.Point(3, 104);
            this.hideAfterCapture.Name = "hideAfterCapture";
            this.hideAfterCapture.Size = new System.Drawing.Size(174, 17);
            this.hideAfterCapture.TabIndex = 2;
            this.hideAfterCapture.Text = "Hide crop window &after capture";
            this.hideAfterCapture.UseVisualStyleBackColor = true;
            // 
            // showOpacityMenu
            // 
            this.showOpacityMenu.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.showOpacityMenu, 2);
            this.showOpacityMenu.Location = new System.Drawing.Point(3, 79);
            this.showOpacityMenu.Name = "showOpacityMenu";
            this.showOpacityMenu.Size = new System.Drawing.Size(144, 17);
            this.showOpacityMenu.TabIndex = 3;
            this.showOpacityMenu.Text = "&Show opacity menu item.";
            // 
            // behaviorTab
            // 
            this.behaviorTab.Controls.Add(this.groupBox2);
            this.behaviorTab.Controls.Add(this.groupBox1);
            this.behaviorTab.Location = new System.Drawing.Point(4, 22);
            this.behaviorTab.Name = "behaviorTab";
            this.behaviorTab.Padding = new System.Windows.Forms.Padding(3);
            this.behaviorTab.Size = new System.Drawing.Size(339, 366);
            this.behaviorTab.TabIndex = 5;
            this.behaviorTab.Text = "Behavior";
            this.behaviorTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rememberLocation);
            this.groupBox2.Controls.Add(this.allowMultipleCropperInstances);
            this.groupBox2.Location = new System.Drawing.Point(6, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 71);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // rememberLocation
            // 
            this.rememberLocation.Location = new System.Drawing.Point(6, 38);
            this.rememberLocation.Name = "rememberLocation";
            this.rememberLocation.Size = new System.Drawing.Size(291, 24);
            this.rememberLocation.TabIndex = 6;
            this.rememberLocation.Text = "Remember Cropper &location";
            // 
            // allowMultipleCropperInstances
            // 
            this.allowMultipleCropperInstances.Location = new System.Drawing.Point(6, 19);
            this.allowMultipleCropperInstances.Name = "allowMultipleCropperInstances";
            this.allowMultipleCropperInstances.Size = new System.Drawing.Size(291, 24);
            this.allowMultipleCropperInstances.TabIndex = 3;
            this.allowMultipleCropperInstances.Text = "Allow multiple &instances.";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(6, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 193);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Predefined &Sizes";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.82609F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.17391F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.predefinedSizeList, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonAddSize, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonRemoveSize, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.33803F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.66197F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(230, 155);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.widthInput);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.heightInput);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 41);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(108, 29);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.MinimumSize = new System.Drawing.Size(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            // 
            // predefinedSizeList
            // 
            this.predefinedSizeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.predefinedSizeList.FormattingEnabled = true;
            this.predefinedSizeList.Location = new System.Drawing.Point(3, 74);
            this.predefinedSizeList.Name = "predefinedSizeList";
            this.predefinedSizeList.Size = new System.Drawing.Size(104, 78);
            this.predefinedSizeList.TabIndex = 4;
            // 
            // buttonAddSize
            // 
            this.buttonAddSize.AutoSize = true;
            this.buttonAddSize.Location = new System.Drawing.Point(113, 43);
            this.buttonAddSize.Name = "buttonAddSize";
            this.buttonAddSize.Size = new System.Drawing.Size(57, 23);
            this.buttonAddSize.TabIndex = 3;
            this.buttonAddSize.Text = "&Add";
            this.buttonAddSize.UseVisualStyleBackColor = true;
            this.buttonAddSize.Click += new System.EventHandler(this.HandleAddSizeClick);
            // 
            // buttonRemoveSize
            // 
            this.buttonRemoveSize.AutoSize = true;
            this.buttonRemoveSize.Location = new System.Drawing.Point(113, 74);
            this.buttonRemoveSize.Name = "buttonRemoveSize";
            this.buttonRemoveSize.Size = new System.Drawing.Size(57, 23);
            this.buttonRemoveSize.TabIndex = 5;
            this.buttonRemoveSize.Text = "&Remove";
            this.buttonRemoveSize.UseVisualStyleBackColor = true;
            this.buttonRemoveSize.Click += new System.EventHandler(this.HandleRemoveSizeClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add a width and height to quickly cycle through commonly used crop sizes.";
            // 
            // outputTab
            // 
            this.outputTab.Controls.Add(this.outputFolderGroup);
            this.outputTab.Controls.Add(this.outputTemplateGroup);
            this.outputTab.Location = new System.Drawing.Point(4, 22);
            this.outputTab.Name = "outputTab";
            this.outputTab.Size = new System.Drawing.Size(339, 366);
            this.outputTab.TabIndex = 0;
            this.outputTab.Text = "Output";
            this.outputTab.UseVisualStyleBackColor = true;
            // 
            // outputTemplateGroup
            // 
            this.outputTemplateGroup.Controls.Add(this.fullImageMenuButton);
            this.outputTemplateGroup.Controls.Add(this.thumbImageMenuButton);
            this.outputTemplateGroup.Controls.Add(this.outputTemplatesDescription);
            this.outputTemplateGroup.Controls.Add(this.fullImageTemplate);
            this.outputTemplateGroup.Controls.Add(this.thumbImageTemplate);
            this.outputTemplateGroup.Controls.Add(this.labelFullImageTemplate);
            this.outputTemplateGroup.Controls.Add(this.labelThumbImageTemplate);
            this.outputTemplateGroup.Location = new System.Drawing.Point(8, 149);
            this.outputTemplateGroup.Name = "outputTemplateGroup";
            this.outputTemplateGroup.Size = new System.Drawing.Size(316, 200);
            this.outputTemplateGroup.TabIndex = 1;
            this.outputTemplateGroup.TabStop = false;
            this.outputTemplateGroup.Text = "&Output Templates";
            // 
            // outputTemplatesDescription
            // 
            this.outputTemplatesDescription.Location = new System.Drawing.Point(6, 20);
            this.outputTemplatesDescription.Name = "outputTemplatesDescription";
            this.outputTemplatesDescription.Size = new System.Drawing.Size(304, 64);
            this.outputTemplatesDescription.TabIndex = 0;
            this.outputTemplatesDescription.Text = "{Resourced}";
            // 
            // labelFullImageTemplate
            // 
            this.labelFullImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFullImageTemplate.Location = new System.Drawing.Point(3, 88);
            this.labelFullImageTemplate.Name = "labelFullImageTemplate";
            this.labelFullImageTemplate.Size = new System.Drawing.Size(180, 17);
            this.labelFullImageTemplate.TabIndex = 1;
            this.labelFullImageTemplate.Text = "&Full image file name template.";
            // 
            // labelThumbImageTemplate
            // 
            this.labelThumbImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelThumbImageTemplate.Location = new System.Drawing.Point(6, 140);
            this.labelThumbImageTemplate.Name = "labelThumbImageTemplate";
            this.labelThumbImageTemplate.Size = new System.Drawing.Size(202, 17);
            this.labelThumbImageTemplate.TabIndex = 4;
            this.labelThumbImageTemplate.Text = "&Thumbnail image file name template.";
            // 
            // capturesTab
            // 
            this.capturesTab.Controls.Add(this.hotKeysGroup);
            this.capturesTab.Controls.Add(this.nonRectangularCapturesGroup);
            this.capturesTab.Controls.Add(this.otherOptionsDescription);
            this.capturesTab.Location = new System.Drawing.Point(4, 22);
            this.capturesTab.Name = "capturesTab";
            this.capturesTab.Size = new System.Drawing.Size(339, 366);
            this.capturesTab.TabIndex = 1;
            this.capturesTab.Text = "Capturing";
            this.capturesTab.UseVisualStyleBackColor = true;
            // 
            // hotKeysGroup
            // 
            this.hotKeysGroup.Controls.Add(this.keepPrntScrnOnClipboard);
            this.hotKeysGroup.Controls.Add(this.hotKeysDescription);
            this.hotKeysGroup.Controls.Add(this.trapPrintScreen);
            this.hotKeysGroup.Location = new System.Drawing.Point(8, 8);
            this.hotKeysGroup.Name = "hotKeysGroup";
            this.hotKeysGroup.Size = new System.Drawing.Size(316, 132);
            this.hotKeysGroup.TabIndex = 0;
            this.hotKeysGroup.TabStop = false;
            this.hotKeysGroup.Text = "Print &Screen";
            // 
            // keepPrntScrnOnClipboard
            // 
            this.keepPrntScrnOnClipboard.Location = new System.Drawing.Point(24, 102);
            this.keepPrntScrnOnClipboard.Name = "keepPrntScrnOnClipboard";
            this.keepPrntScrnOnClipboard.Size = new System.Drawing.Size(289, 18);
            this.keepPrntScrnOnClipboard.TabIndex = 2;
            this.keepPrntScrnOnClipboard.Text = "&Keep Print Screen image on clipboard after processing.";
            // 
            // hotKeysDescription
            // 
            this.hotKeysDescription.Location = new System.Drawing.Point(6, 21);
            this.hotKeysDescription.Name = "hotKeysDescription";
            this.hotKeysDescription.Size = new System.Drawing.Size(284, 60);
            this.hotKeysDescription.TabIndex = 0;
            this.hotKeysDescription.Text = "{Resourced}";
            // 
            // trapPrintScreen
            // 
            this.trapPrintScreen.Location = new System.Drawing.Point(8, 81);
            this.trapPrintScreen.Name = "trapPrintScreen";
            this.trapPrintScreen.Size = new System.Drawing.Size(248, 24);
            this.trapPrintScreen.TabIndex = 1;
            this.trapPrintScreen.Text = "Use Cropper to process &Print Screen images.";
            // 
            // nonRectangularCapturesGroup
            // 
            this.nonRectangularCapturesGroup.Controls.Add(this.colorChooserButton);
            this.nonRectangularCapturesGroup.Controls.Add(this.nonRectWindowsDescription);
            this.nonRectangularCapturesGroup.Controls.Add(this.colorNonFormAreaCheck);
            this.nonRectangularCapturesGroup.Controls.Add(this.backgroundColor);
            this.nonRectangularCapturesGroup.Location = new System.Drawing.Point(8, 148);
            this.nonRectangularCapturesGroup.Name = "nonRectangularCapturesGroup";
            this.nonRectangularCapturesGroup.Size = new System.Drawing.Size(316, 154);
            this.nonRectangularCapturesGroup.TabIndex = 1;
            this.nonRectangularCapturesGroup.TabStop = false;
            this.nonRectangularCapturesGroup.Text = "Non-&Rectangular Windows";
            // 
            // colorChooserButton
            // 
            this.colorChooserButton.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.colorChooserButton.Location = new System.Drawing.Point(209, 113);
            this.colorChooserButton.Name = "colorChooserButton";
            this.colorChooserButton.Size = new System.Drawing.Size(101, 30);
            this.colorChooserButton.TabIndex = 2;
            this.colorChooserButton.Text = "C&hoose Color";
            this.colorChooserButton.Click += new System.EventHandler(this.HandleColorChooserButtonClick);
            // 
            // nonRectWindowsDescription
            // 
            this.nonRectWindowsDescription.Location = new System.Drawing.Point(6, 21);
            this.nonRectWindowsDescription.Name = "nonRectWindowsDescription";
            this.nonRectWindowsDescription.Size = new System.Drawing.Size(284, 64);
            this.nonRectWindowsDescription.TabIndex = 0;
            this.nonRectWindowsDescription.Text = "{Resourced}";
            // 
            // colorNonFormAreaCheck
            // 
            this.colorNonFormAreaCheck.Location = new System.Drawing.Point(9, 83);
            this.colorNonFormAreaCheck.Name = "colorNonFormAreaCheck";
            this.colorNonFormAreaCheck.Size = new System.Drawing.Size(290, 24);
            this.colorNonFormAreaCheck.TabIndex = 1;
            this.colorNonFormAreaCheck.Text = "&Crop and fill invisible form area with this color...";
            // 
            // backgroundColor
            // 
            this.backgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColor.Location = new System.Drawing.Point(9, 113);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(194, 30);
            this.backgroundColor.TabIndex = 3;
            // 
            // otherOptionsDescription
            // 
            this.otherOptionsDescription.Controls.Add(this.includeMouseCursorInCapture);
            this.otherOptionsDescription.Location = new System.Drawing.Point(8, 308);
            this.otherOptionsDescription.Name = "otherOptionsDescription";
            this.otherOptionsDescription.Size = new System.Drawing.Size(316, 51);
            this.otherOptionsDescription.TabIndex = 4;
            this.otherOptionsDescription.TabStop = false;
            this.otherOptionsDescription.Text = "Other &Options";
            // 
            // includeMouseCursorInCapture
            // 
            this.includeMouseCursorInCapture.Location = new System.Drawing.Point(9, 21);
            this.includeMouseCursorInCapture.Name = "includeMouseCursorInCapture";
            this.includeMouseCursorInCapture.Size = new System.Drawing.Size(291, 20);
            this.includeMouseCursorInCapture.TabIndex = 4;
            this.includeMouseCursorInCapture.Text = "Include &mouse cursor in capture.";
            // 
            // keyboardTab
            // 
            this.keyboardTab.Controls.Add(this.keyboardShortcutsGroup);
            this.keyboardTab.Location = new System.Drawing.Point(4, 22);
            this.keyboardTab.Name = "keyboardTab";
            this.keyboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.keyboardTab.Size = new System.Drawing.Size(339, 366);
            this.keyboardTab.TabIndex = 4;
            this.keyboardTab.Text = "Keyboard";
            this.keyboardTab.UseVisualStyleBackColor = true;
            // 
            // keyboardShortcutsGroup
            // 
            this.keyboardShortcutsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboardShortcutsGroup.Controls.Add(this.hotKeySelection);
            this.keyboardShortcutsGroup.Location = new System.Drawing.Point(7, 7);
            this.keyboardShortcutsGroup.Name = "keyboardShortcutsGroup";
            this.keyboardShortcutsGroup.Size = new System.Drawing.Size(320, 356);
            this.keyboardShortcutsGroup.TabIndex = 1;
            this.keyboardShortcutsGroup.TabStop = false;
            this.keyboardShortcutsGroup.Text = "Keyboard Shortcuts";
            // 
            // hotKeySelection
            // 
            this.hotKeySelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotKeySelection.FocusedItem = null;
            this.hotKeySelection.FullRowSelect = true;
            this.hotKeySelection.GridLines = true;
            this.hotKeySelection.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
            this.hotKeySelection.HideSelection = false;
            this.hotKeySelection.HotTracking = false;
            this.hotKeySelection.HoverSelection = false;
            this.hotKeySelection.Location = new System.Drawing.Point(6, 19);
            this.hotKeySelection.Margin = new System.Windows.Forms.Padding(4);
            this.hotKeySelection.MultiSelect = false;
            this.hotKeySelection.Name = "hotKeySelection";
            this.hotKeySelection.Scrollable = true;
            this.hotKeySelection.ShowGroups = true;
            this.hotKeySelection.ShowItemToolTips = false;
            this.hotKeySelection.Size = new System.Drawing.Size(307, 331);
            this.hotKeySelection.SmallImageList = null;
            this.hotKeySelection.TabIndex = 0;
            this.hotKeySelection.TopItem = null;
            // 
            // pluginsTab
            // 
            this.pluginsTab.Controls.Add(this.pluginConfigHostPanel);
            this.pluginsTab.Controls.Add(this.pluginsComboBox);
            this.pluginsTab.Location = new System.Drawing.Point(4, 22);
            this.pluginsTab.Name = "pluginsTab";
            this.pluginsTab.Size = new System.Drawing.Size(339, 366);
            this.pluginsTab.TabIndex = 3;
            this.pluginsTab.Text = "Plug-ins";
            this.pluginsTab.UseVisualStyleBackColor = true;
            // 
            // pluginConfigHostPanel
            // 
            this.pluginConfigHostPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pluginConfigHostPanel.Location = new System.Drawing.Point(3, 30);
            this.pluginConfigHostPanel.Name = "pluginConfigHostPanel";
            this.pluginConfigHostPanel.Size = new System.Drawing.Size(327, 362);
            this.pluginConfigHostPanel.TabIndex = 1;
            // 
            // pluginsComboBox
            // 
            this.pluginsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pluginsComboBox.Location = new System.Drawing.Point(3, 3);
            this.pluginsComboBox.Name = "pluginsComboBox";
            this.pluginsComboBox.Size = new System.Drawing.Size(327, 21);
            this.pluginsComboBox.TabIndex = 0;
            this.pluginsComboBox.SelectedIndexChanged += new System.EventHandler(this.HandlePluginSelectionChanged);
            // 
            // Options
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(498, 441);
            this.Controls.Add(this.line);
            this.Controls.Add(this.optionsNavigator);
            this.Controls.Add(this.optionsTabs);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cropper Options";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.outputFolderGroup.ResumeLayout(false);
            this.outputFolderGroup.PerformLayout();
            this.optionsTabs.ResumeLayout(false);
            this.appearanceTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).EndInit();
            this.behaviorTab.ResumeLayout(false);
            this.behaviorTab.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.outputTab.ResumeLayout(false);
            this.outputTemplateGroup.ResumeLayout(false);
            this.outputTemplateGroup.PerformLayout();
            this.capturesTab.ResumeLayout(false);
            this.hotKeysGroup.ResumeLayout(false);
            this.nonRectangularCapturesGroup.ResumeLayout(false);
            this.otherOptionsDescription.ResumeLayout(false);
            this.keyboardTab.ResumeLayout(false);
            this.keyboardShortcutsGroup.ResumeLayout(false);
            this.pluginsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderBrowserDialog folder;
        private Button okButton;
        private Button cancelButton;
        private TextBox fullImageTemplate;
        private TextBox thumbImageTemplate;
        private DropDownButton fullImageMenuButton;
        private ContextMenu templateMenu;
        private DropDownButton thumbImageMenuButton;
        private MenuItem templateIncrement;
        private MenuItem templateDate;
        private MenuItem templateTime;
        private MenuItem templateExtension;
        private TextBox currentTextBox;
        private ErrorProvider errorProvider;
        private ToolTip toolTip;
        private MenuItem templateUser;
        private MenuItem templateDomain;
        private MenuItem templateMachine;
        private MenuItem templatePrompt;
        private MenuItem seperator1;
        private MenuItem seperator2;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private Button colorChooserButton;
        private ColorDialog colorDialog;
        private CheckBox colorNonFormAreaCheck;
        private GroupBox outputTemplateGroup;
        private GroupBox hotKeysGroup;
        private Label labelOutputFolder;
        private Label labelThumbImageTemplate;
        private Label labelFullImageTemplate;
        private TrackBar opacitySlider;
        private Label opacityValue;
        private CheckBox showOpacityMenu;
        private CheckBox trapPrintScreen;
        private Label nonRectWindowsDescription;
        private Label outputTemplatesDescription;
        private Label outputFolderDescription;
        private Label hotKeysDescription;
        private Panel backgroundColor;
        private GroupBox nonRectangularCapturesGroup;
        private GroupBox outputFolderGroup;
        private TablessTabControl optionsTabs;
        private TabPage outputTab;
        private TabPage capturesTab;
        private TabPage appearanceTab;
        private TabPage pluginsTab;
        private ComboBox pluginsComboBox;
        private Panel pluginConfigHostPanel;
        private CheckBox keepPrntScrnOnClipboard;
        private Button button1;
        private TextBox folderChooser;
        private CheckBox hideAfterCapture;
        private Button buttonRemoveSize;
        private Button buttonAddSize;
        private ListBox predefinedSizeList;
        private Label label1;
        private DpiAwareTextBox heightInput;
        private DpiAwareTextBox widthInput;
        private TabPage keyboardTab;
        private HotKeySelection hotKeySelection;
        private MenuItem templateTimestamp;
        private CheckBox allowMultipleCropperInstances;
        private GroupBox otherOptionsDescription;
        private CheckBox includeMouseCursorInCapture;
        private TreeView optionsNavigator;
        private Label line;
        private Label opacityDescription;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage behaviorTab;
        private CheckBox rememberLocation;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private GroupBox groupBox2;
        private GroupBox keyboardShortcutsGroup;
    }
}
