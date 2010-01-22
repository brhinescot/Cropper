#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Fusion8.Cropper.Core;
using Fusion8.Cropper.Extensibility;
using Skybound.VisualStyles;
using System.Text.RegularExpressions;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    /// Represents a form for setting options in the application.
    /// </summary>
    public class Options : Form
    {
        #region Member Fields

        private readonly Hashtable errors = new Hashtable();
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
        private Label LabelThumbImageTemplate;
        private Label labelFullImageTemplate;
        private TrackBar opacitySlider;
        private Label opacityValue;
        private CheckBox showOpacityMenu;
        private CheckBox trapPrintScreen;
        private Label nonRectWindowsDescription;
        private Label outputTemplatesDescription;
        private Label outputFolderDescription;
        private Label hotKeysDescription;
        private Label opacityDescription;
        private Panel backgroundColor;
        private GroupBox nonRectangularCapturesGroup;
        private GroupBox outputFolderGroup;
        private TabControl optionsTabs;
        private TabPage outputTab;
        private TabPage capturesTab;
        private TabPage appearanceTab;
        private GroupBox opaityGroup;
        private CheckBox perPixelAlphaBlend;
        private TabPage pluginsTab;
        private ComboBox comboBox1;
        private Panel panel1;
        private CheckBox keepPrntScrnOnClipboard;
        private Button button1;
        private TextBox folderChooser;
        private GroupBox groupBox1;
        private Label visibilityDescription;
        private CheckBox hideDuringCapture;
        private CheckBox hideAfterCapture;
        private GroupBox groupBox2;
        private Button buttonRemoveSize;
        private Button buttonAddSize;
        private ListBox predefinedSizeList;
        private Label label1;
        private TextBox heightInput;
        private TextBox widthInput;
        private IContainer components;

        private static readonly Regex isNumeric = new Regex(@"^\d+$", RegexOptions.Compiled);
        private Label label2;
        private Label label3;
        private TabPage keyboardTab;
        private HotKeySelection hotKeySelection1;
        private MenuItem templateTimestamp;
        private CheckBox allowMultipleCropperInstances;
        private GroupBox otherOptionsDescription;
        private CheckBox includeMouseCursorInCapture;
        private bool addingSize;

        #endregion

        public Options()
        {
            InitializeComponent();
            folder.Description = SR.FolderBrowseText;
            folderChooser.Text = Configuration.Current.OutputPath;
            fullImageTemplate.Text = Configuration.Current.FullImageTemplate;
            thumbImageTemplate.Text = Configuration.Current.ThumbImageTemplate;
            backgroundColor.BackColor = Color.FromArgb(Configuration.Current.NonFormAreaColorArgb);
            toolTip.SetToolTip(backgroundColor, string.Format("Color\nRed:{0}\nGreen{1}\nBlue:{2}", backgroundColor.BackColor.R, backgroundColor.BackColor.G, backgroundColor.BackColor.B));
            colorNonFormAreaCheck.Checked = Configuration.Current.ColorNonFormArea;
            opacitySlider.Value = Convert.ToInt32(Configuration.Current.UserOpacity*100)/10;
            opacityValue.Text = (opacitySlider.Value*10) + "%";
            showOpacityMenu.Checked = Configuration.Current.ShowOpacityMenu;
            trapPrintScreen.Checked = Configuration.Current.TrapPrintScreen;
            perPixelAlphaBlend.Checked = Configuration.Current.UsePerPixelAlpha;
            hideDuringCapture.Checked = Configuration.Current.HideFormDuringCapture;
            hideAfterCapture.Checked = Configuration.Current.HideFormAfterCapture;
            keepPrntScrnOnClipboard.Checked = Configuration.Current.LeavePrintScreenOnClipboard;
            allowMultipleCropperInstances.Checked = Configuration.Current.AllowMultipleInstances;
            includeMouseCursorInCapture.Checked = Configuration.Current.IncludeMouseCursorInCapture;

            foreach (CropSize size in Configuration.Current.PredefinedSizes)
                predefinedSizeList.Items.Add(size);

            SetStrings();

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select Plug-in");
            foreach (IPersistableImageFormat format in ImageCapture.ImageOutputs)
            {
                IConfigurablePlugin configurable = format as IConfigurablePlugin;
                if (configurable != null && configurable.ConfigurationForm != null)
                    comboBox1.Items.Add(configurable);
            }
            comboBox1.SelectedIndex = 0;

            AcceptButton = okButton;
            CancelButton = cancelButton;

            this.optionsTabs.Controls.Remove(this.keyboardTab);
        }

        private void SetStrings()
        {
            outputTemplatesDescription.Text = SR.OptionOutputTemplatesDescription;
            hotKeysDescription.Text = SR.OptionHotKeysDescription;
            nonRectWindowsDescription.Text = SR.OptionNonRectWindowsDescription;
            visibilityDescription.Text = SR.OptionVisibility;
        }

        private static bool ValidateFileName(string name)
        {
            return !(name.IndexOfAny(new char[] {'/', '*', ':', '?', '"', '<', '>', '|'}) >= 0);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folder = new System.Windows.Forms.FolderBrowserDialog();
            this.labelOutputFolder = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.labelFullImageTemplate = new System.Windows.Forms.Label();
            this.fullImageTemplate = new System.Windows.Forms.TextBox();
            this.thumbImageTemplate = new System.Windows.Forms.TextBox();
            this.LabelThumbImageTemplate = new System.Windows.Forms.Label();
            this.templateMenu = new System.Windows.Forms.ContextMenu();
            this.templateIncrement = new System.Windows.Forms.MenuItem();
            this.templateDate = new System.Windows.Forms.MenuItem();
            this.templateTime = new System.Windows.Forms.MenuItem();
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
            this.folderChooser = new System.Windows.Forms.TextBox();
            this.widthInput = new System.Windows.Forms.TextBox();
            this.heightInput = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fullImageMenuButton = new Fusion8.Cropper.Core.DropDownButton();
            this.thumbImageMenuButton = new Fusion8.Cropper.Core.DropDownButton();
            this.colorChooserButton = new System.Windows.Forms.Button();
            this.backgroundColor = new System.Windows.Forms.Panel();
            this.nonRectangularCapturesGroup = new System.Windows.Forms.GroupBox();
            this.nonRectWindowsDescription = new System.Windows.Forms.Label();
            this.colorNonFormAreaCheck = new System.Windows.Forms.CheckBox();
            this.outputTemplateGroup = new System.Windows.Forms.GroupBox();
            this.outputTemplatesDescription = new System.Windows.Forms.Label();
            this.outputFolderGroup = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.outputFolderDescription = new System.Windows.Forms.Label();
            this.hotKeysGroup = new System.Windows.Forms.GroupBox();
            this.keepPrntScrnOnClipboard = new System.Windows.Forms.CheckBox();
            this.hotKeysDescription = new System.Windows.Forms.Label();
            this.trapPrintScreen = new System.Windows.Forms.CheckBox();
            this.optionsTabs = new System.Windows.Forms.TabControl();
            this.outputTab = new System.Windows.Forms.TabPage();
            this.capturesTab = new System.Windows.Forms.TabPage();
            this.otherOptionsDescription = new System.Windows.Forms.GroupBox();
            this.allowMultipleCropperInstances = new System.Windows.Forms.CheckBox();
            this.appearanceTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRemoveSize = new System.Windows.Forms.Button();
            this.buttonAddSize = new System.Windows.Forms.Button();
            this.predefinedSizeList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.visibilityDescription = new System.Windows.Forms.Label();
            this.hideDuringCapture = new System.Windows.Forms.CheckBox();
            this.hideAfterCapture = new System.Windows.Forms.CheckBox();
            this.opaityGroup = new System.Windows.Forms.GroupBox();
            this.opacityValue = new System.Windows.Forms.Label();
            this.showOpacityMenu = new System.Windows.Forms.CheckBox();
            this.opacitySlider = new System.Windows.Forms.TrackBar();
            this.opacityDescription = new System.Windows.Forms.Label();
            this.perPixelAlphaBlend = new System.Windows.Forms.CheckBox();
            this.keyboardTab = new System.Windows.Forms.TabPage();
            this.hotKeySelection1 = new Fusion8.Cropper.Core.HotKeySelection();
            this.pluginsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.templateTimestamp = new System.Windows.Forms.MenuItem();
            this.includeMouseCursorInCapture = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.nonRectangularCapturesGroup.SuspendLayout();
            this.outputTemplateGroup.SuspendLayout();
            this.outputFolderGroup.SuspendLayout();
            this.hotKeysGroup.SuspendLayout();
            this.optionsTabs.SuspendLayout();
            this.outputTab.SuspendLayout();
            this.capturesTab.SuspendLayout();
            this.otherOptionsDescription.SuspendLayout();
            this.appearanceTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.opaityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
            this.keyboardTab.SuspendLayout();
            this.pluginsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOutputFolder
            // 
            this.labelOutputFolder.Location = new System.Drawing.Point(16, 48);
            this.labelOutputFolder.Name = "labelOutputFolder";
            this.labelOutputFolder.Size = new System.Drawing.Size(208, 23);
            this.labelOutputFolder.TabIndex = 1;
            this.labelOutputFolder.Text = "&Save screenshots to this folder. ";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(191, 436);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 29);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.HandleOkClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(275, 436);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 29);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            // 
            // labelFullImageTemplate
            // 
            this.labelFullImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFullImageTemplate.Location = new System.Drawing.Point(16, 88);
            this.labelFullImageTemplate.Name = "labelFullImageTemplate";
            this.labelFullImageTemplate.Size = new System.Drawing.Size(248, 23);
            this.labelFullImageTemplate.TabIndex = 1;
            this.labelFullImageTemplate.Text = "&Full image file name template.";
            // 
            // fullImageTemplate
            // 
            this.fullImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fullImageTemplate.HideSelection = false;
            this.errorProvider.SetIconPadding(this.fullImageTemplate, 24);
            this.fullImageTemplate.Location = new System.Drawing.Point(16, 108);
            this.fullImageTemplate.Name = "fullImageTemplate";
            this.fullImageTemplate.Size = new System.Drawing.Size(256, 20);
            this.fullImageTemplate.TabIndex = 2;
            this.fullImageTemplate.TextChanged += new System.EventHandler(this.HandleTextBoxTextChanged);
            // 
            // thumbImageTemplate
            // 
            this.thumbImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbImageTemplate.HideSelection = false;
            this.errorProvider.SetIconPadding(this.thumbImageTemplate, 24);
            this.thumbImageTemplate.Location = new System.Drawing.Point(16, 160);
            this.thumbImageTemplate.Name = "thumbImageTemplate";
            this.thumbImageTemplate.Size = new System.Drawing.Size(256, 20);
            this.thumbImageTemplate.TabIndex = 5;
            this.thumbImageTemplate.TextChanged += new System.EventHandler(this.HandleTextBoxTextChanged);
            // 
            // LabelThumbImageTemplate
            // 
            this.LabelThumbImageTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelThumbImageTemplate.Location = new System.Drawing.Point(16, 140);
            this.LabelThumbImageTemplate.Name = "LabelThumbImageTemplate";
            this.LabelThumbImageTemplate.Size = new System.Drawing.Size(248, 23);
            this.LabelThumbImageTemplate.TabIndex = 4;
            this.LabelThumbImageTemplate.Text = "&Thumbnail image file name template.";
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
            // folderChooser
            // 
            this.errorProvider.SetIconPadding(this.folderChooser, 26);
            this.folderChooser.Location = new System.Drawing.Point(16, 65);
            this.folderChooser.Name = "folderChooser";
            this.folderChooser.Size = new System.Drawing.Size(254, 20);
            this.folderChooser.TabIndex = 4;
            this.folderChooser.TextChanged += new System.EventHandler(this.HandleDirectoryTextChanged);
            // 
            // widthInput
            // 
            this.errorProvider.SetIconPadding(this.widthInput, 142);
            this.widthInput.Location = new System.Drawing.Point(19, 22);
            this.widthInput.MaxLength = 4;
            this.widthInput.Name = "widthInput";
            this.widthInput.Size = new System.Drawing.Size(33, 20);
            this.widthInput.TabIndex = 0;
            this.toolTip.SetToolTip(this.widthInput, "The width of the crop form.");
            this.widthInput.WordWrap = false;
            this.widthInput.Enter += new System.EventHandler(this.HandleSizeInputEnter);
            this.widthInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HandleSizeInputPreviewKeyDown);
            this.widthInput.TextChanged += new System.EventHandler(this.SizeInputTextChanged);
            // 
            // heightInput
            // 
            this.errorProvider.SetIconPadding(this.heightInput, 85);
            this.heightInput.Location = new System.Drawing.Point(76, 22);
            this.heightInput.MaxLength = 4;
            this.heightInput.Name = "heightInput";
            this.heightInput.Size = new System.Drawing.Size(33, 20);
            this.heightInput.TabIndex = 2;
            this.toolTip.SetToolTip(this.heightInput, "The height of the crop form.");
            this.heightInput.WordWrap = false;
            this.heightInput.Enter += new System.EventHandler(this.HandleSizeInputEnter);
            this.heightInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HandleSizeInputPreviewKeyDown);
            this.heightInput.TextChanged += new System.EventHandler(this.SizeInputTextChanged);
            // 
            // fullImageMenuButton
            // 
            this.fullImageMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fullImageMenuButton.BackColor = System.Drawing.SystemColors.Control;
            this.fullImageMenuButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.fullImageMenuButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fullImageMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullImageMenuButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fullImageMenuButton.Location = new System.Drawing.Point(272, 108);
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
            this.thumbImageMenuButton.Location = new System.Drawing.Point(272, 160);
            this.thumbImageMenuButton.Name = "thumbImageMenuButton";
            this.thumbImageMenuButton.Size = new System.Drawing.Size(23, 20);
            this.thumbImageMenuButton.TabIndex = 6;
            this.thumbImageMenuButton.TabStop = false;
            this.thumbImageMenuButton.Text = "6";
            this.toolTip.SetToolTip(this.thumbImageMenuButton, "Insert template text.");
            this.thumbImageMenuButton.UseVisualStyleBackColor = false;
            this.thumbImageMenuButton.Click += new System.EventHandler(this.HandleThumbImageMenuButtonClick);
            // 
            // colorChooserButton
            // 
            this.colorChooserButton.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.colorChooserButton.Location = new System.Drawing.Point(124, 128);
            this.colorChooserButton.Name = "colorChooserButton";
            this.colorChooserButton.Size = new System.Drawing.Size(75, 23);
            this.colorChooserButton.TabIndex = 2;
            this.colorChooserButton.Text = "C&hoose";
            this.colorChooserButton.Click += new System.EventHandler(this.HandleColorChooserButtonClick);
            // 
            // backgroundColor
            // 
            this.backgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColor.Location = new System.Drawing.Point(36, 124);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(78, 30);
            this.backgroundColor.TabIndex = 3;
            // 
            // nonRectangularCapturesGroup
            // 
            this.nonRectangularCapturesGroup.Controls.Add(this.nonRectWindowsDescription);
            this.nonRectangularCapturesGroup.Controls.Add(this.colorNonFormAreaCheck);
            this.nonRectangularCapturesGroup.Controls.Add(this.backgroundColor);
            this.nonRectangularCapturesGroup.Controls.Add(this.colorChooserButton);
            this.nonRectangularCapturesGroup.Location = new System.Drawing.Point(8, 148);
            this.nonRectangularCapturesGroup.Name = "nonRectangularCapturesGroup";
            this.nonRectangularCapturesGroup.Size = new System.Drawing.Size(316, 172);
            this.nonRectangularCapturesGroup.TabIndex = 1;
            this.nonRectangularCapturesGroup.TabStop = false;
            this.nonRectangularCapturesGroup.Text = "Non-&Rectangular Windows";
            // 
            // nonRectWindowsDescription
            // 
            this.nonRectWindowsDescription.Location = new System.Drawing.Point(17, 21);
            this.nonRectWindowsDescription.Name = "nonRectWindowsDescription";
            this.nonRectWindowsDescription.Size = new System.Drawing.Size(284, 64);
            this.nonRectWindowsDescription.TabIndex = 0;
            this.nonRectWindowsDescription.Text = "{Resourced}";
            // 
            // colorNonFormAreaCheck
            // 
            this.colorNonFormAreaCheck.Location = new System.Drawing.Point(20, 88);
            this.colorNonFormAreaCheck.Name = "colorNonFormAreaCheck";
            this.colorNonFormAreaCheck.Size = new System.Drawing.Size(268, 24);
            this.colorNonFormAreaCheck.TabIndex = 1;
            this.colorNonFormAreaCheck.Text = "&Crop and color invisible form area.";
            // 
            // outputTemplateGroup
            // 
            this.outputTemplateGroup.Controls.Add(this.outputTemplatesDescription);
            this.outputTemplateGroup.Controls.Add(this.fullImageTemplate);
            this.outputTemplateGroup.Controls.Add(this.thumbImageTemplate);
            this.outputTemplateGroup.Controls.Add(this.labelFullImageTemplate);
            this.outputTemplateGroup.Controls.Add(this.LabelThumbImageTemplate);
            this.outputTemplateGroup.Controls.Add(this.fullImageMenuButton);
            this.outputTemplateGroup.Controls.Add(this.thumbImageMenuButton);
            this.outputTemplateGroup.Location = new System.Drawing.Point(8, 120);
            this.outputTemplateGroup.Name = "outputTemplateGroup";
            this.outputTemplateGroup.Size = new System.Drawing.Size(316, 200);
            this.outputTemplateGroup.TabIndex = 1;
            this.outputTemplateGroup.TabStop = false;
            this.outputTemplateGroup.Text = "&Output Templates";
            // 
            // outputTemplatesDescription
            // 
            this.outputTemplatesDescription.Location = new System.Drawing.Point(16, 20);
            this.outputTemplatesDescription.Name = "outputTemplatesDescription";
            this.outputTemplatesDescription.Size = new System.Drawing.Size(288, 64);
            this.outputTemplatesDescription.TabIndex = 0;
            this.outputTemplatesDescription.Text = "{Resourced}";
            // 
            // outputFolderGroup
            // 
            this.outputFolderGroup.Controls.Add(this.folderChooser);
            this.outputFolderGroup.Controls.Add(this.button1);
            this.outputFolderGroup.Controls.Add(this.outputFolderDescription);
            this.outputFolderGroup.Controls.Add(this.labelOutputFolder);
            this.outputFolderGroup.Location = new System.Drawing.Point(8, 8);
            this.outputFolderGroup.Name = "outputFolderGroup";
            this.outputFolderGroup.Size = new System.Drawing.Size(316, 104);
            this.outputFolderGroup.TabIndex = 0;
            this.outputFolderGroup.TabStop = false;
            this.outputFolderGroup.Text = "Output &Location";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.HandleFolderChooserButtonClick);
            // 
            // outputFolderDescription
            // 
            this.outputFolderDescription.Location = new System.Drawing.Point(16, 20);
            this.outputFolderDescription.Name = "outputFolderDescription";
            this.outputFolderDescription.Size = new System.Drawing.Size(284, 24);
            this.outputFolderDescription.TabIndex = 0;
            this.outputFolderDescription.Text = "This is the root folder for all file based screenshots.";
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
            this.hotKeysGroup.Text = "&Hot Keys";
            // 
            // keepPrntScrnOnClipboard
            // 
            this.keepPrntScrnOnClipboard.Location = new System.Drawing.Point(20, 104);
            this.keepPrntScrnOnClipboard.Name = "keepPrntScrnOnClipboard";
            this.keepPrntScrnOnClipboard.Size = new System.Drawing.Size(268, 24);
            this.keepPrntScrnOnClipboard.TabIndex = 2;
            this.keepPrntScrnOnClipboard.Text = "&Keep image on clipboard.";
            // 
            // hotKeysDescription
            // 
            this.hotKeysDescription.Location = new System.Drawing.Point(16, 20);
            this.hotKeysDescription.Name = "hotKeysDescription";
            this.hotKeysDescription.Size = new System.Drawing.Size(284, 60);
            this.hotKeysDescription.TabIndex = 0;
            this.hotKeysDescription.Text = "{Resourced}";
            // 
            // trapPrintScreen
            // 
            this.trapPrintScreen.Location = new System.Drawing.Point(20, 80);
            this.trapPrintScreen.Name = "trapPrintScreen";
            this.trapPrintScreen.Size = new System.Drawing.Size(268, 24);
            this.trapPrintScreen.TabIndex = 1;
            this.trapPrintScreen.Text = "Use Cropper to save &Print Screen images.";
            // 
            // optionsTabs
            // 
            this.optionsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTabs.Controls.Add(this.outputTab);
            this.optionsTabs.Controls.Add(this.capturesTab);
            this.optionsTabs.Controls.Add(this.appearanceTab);
            this.optionsTabs.Controls.Add(this.keyboardTab);
            this.optionsTabs.Controls.Add(this.pluginsTab);
            this.optionsTabs.Location = new System.Drawing.Point(8, 6);
            this.optionsTabs.Name = "optionsTabs";
            this.optionsTabs.SelectedIndex = 0;
            this.optionsTabs.Size = new System.Drawing.Size(344, 421);
            this.optionsTabs.TabIndex = 0;
            // 
            // outputTab
            // 
            this.outputTab.Controls.Add(this.outputFolderGroup);
            this.outputTab.Controls.Add(this.outputTemplateGroup);
            this.outputTab.Location = new System.Drawing.Point(4, 22);
            this.outputTab.Name = "outputTab";
            this.outputTab.Size = new System.Drawing.Size(336, 395);
            this.outputTab.TabIndex = 0;
            this.outputTab.Text = "Output";
            this.outputTab.UseVisualStyleBackColor = true;
            // 
            // capturesTab
            // 
            this.capturesTab.Controls.Add(this.hotKeysGroup);
            this.capturesTab.Controls.Add(this.nonRectangularCapturesGroup);
            this.capturesTab.Controls.Add(this.otherOptionsDescription);
            this.capturesTab.Location = new System.Drawing.Point(4, 22);
            this.capturesTab.Name = "capturesTab";
            this.capturesTab.Size = new System.Drawing.Size(336, 395);
            this.capturesTab.TabIndex = 1;
            this.capturesTab.Text = "Capturing";
            this.capturesTab.UseVisualStyleBackColor = true;
            // 
            // otherOptionsDescription
            // 
            this.otherOptionsDescription.Controls.Add(this.includeMouseCursorInCapture);
            this.otherOptionsDescription.Controls.Add(this.allowMultipleCropperInstances);
            this.otherOptionsDescription.Location = new System.Drawing.Point(8, 326);
            this.otherOptionsDescription.Name = "otherOptionsDescription";
            this.otherOptionsDescription.Size = new System.Drawing.Size(316, 66);
            this.otherOptionsDescription.TabIndex = 4;
            this.otherOptionsDescription.TabStop = false;
            this.otherOptionsDescription.Text = "Other &Options";
            // 
            // allowMultipleCropperInstances
            // 
            this.allowMultipleCropperInstances.Location = new System.Drawing.Point(19, 19);
            this.allowMultipleCropperInstances.Name = "allowMultipleCropperInstances";
            this.allowMultipleCropperInstances.Size = new System.Drawing.Size(268, 24);
            this.allowMultipleCropperInstances.TabIndex = 3;
            this.allowMultipleCropperInstances.Text = "Allow multiple &instances.";
            // 
            // appearanceTab
            // 
            this.appearanceTab.Controls.Add(this.groupBox2);
            this.appearanceTab.Controls.Add(this.groupBox1);
            this.appearanceTab.Controls.Add(this.opaityGroup);
            this.appearanceTab.Location = new System.Drawing.Point(4, 22);
            this.appearanceTab.Name = "appearanceTab";
            this.appearanceTab.Size = new System.Drawing.Size(336, 395);
            this.appearanceTab.TabIndex = 2;
            this.appearanceTab.Text = "Appearance";
            this.appearanceTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.heightInput);
            this.groupBox2.Controls.Add(this.widthInput);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonRemoveSize);
            this.groupBox2.Controls.Add(this.buttonAddSize);
            this.groupBox2.Controls.Add(this.predefinedSizeList);
            this.groupBox2.Location = new System.Drawing.Point(8, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 120);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Predefined Si&zes";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(198, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 82);
            this.label2.TabIndex = 6;
            this.label2.Text = "Use the Tab key to step through the predefined sizes.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            // 
            // buttonRemoveSize
            // 
            this.buttonRemoveSize.Location = new System.Drawing.Point(115, 49);
            this.buttonRemoveSize.Name = "buttonRemoveSize";
            this.buttonRemoveSize.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveSize.TabIndex = 5;
            this.buttonRemoveSize.Text = "&Remove";
            this.buttonRemoveSize.UseVisualStyleBackColor = true;
            this.buttonRemoveSize.Click += new System.EventHandler(this.HandleRemoveSizeClick);
            // 
            // buttonAddSize
            // 
            this.buttonAddSize.Location = new System.Drawing.Point(115, 23);
            this.buttonAddSize.Name = "buttonAddSize";
            this.buttonAddSize.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSize.TabIndex = 3;
            this.buttonAddSize.Text = "&Add";
            this.buttonAddSize.UseVisualStyleBackColor = true;
            this.buttonAddSize.Click += new System.EventHandler(this.HandleAddSizeClick);
            // 
            // predefinedSizeList
            // 
            this.predefinedSizeList.FormattingEnabled = true;
            this.predefinedSizeList.Location = new System.Drawing.Point(19, 49);
            this.predefinedSizeList.Name = "predefinedSizeList";
            this.predefinedSizeList.Size = new System.Drawing.Size(90, 56);
            this.predefinedSizeList.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.visibilityDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.hideDuringCapture);
            this.groupBox1.Controls.Add(this.hideAfterCapture);
            this.groupBox1.Location = new System.Drawing.Point(8, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Visibility / Translucent Captures";
            // 
            // visibilityDescription
            // 
            this.visibilityDescription.Location = new System.Drawing.Point(16, 25);
            this.visibilityDescription.Name = "visibilityDescription";
            this.visibilityDescription.Size = new System.Drawing.Size(284, 39);
            this.visibilityDescription.TabIndex = 0;
            this.visibilityDescription.Text = "{Resourced}";
            // 
            // hideDuringCapture
            // 
            this.hideDuringCapture.AutoSize = true;
            this.hideDuringCapture.Location = new System.Drawing.Point(115, 67);
            this.hideDuringCapture.Name = "hideDuringCapture";
            this.hideDuringCapture.Size = new System.Drawing.Size(94, 17);
            this.hideDuringCapture.TabIndex = 1;
            this.hideDuringCapture.Text = "&during capture";
            this.hideDuringCapture.UseVisualStyleBackColor = true;
            // 
            // hideAfterCapture
            // 
            this.hideAfterCapture.AutoSize = true;
            this.hideAfterCapture.Location = new System.Drawing.Point(214, 67);
            this.hideAfterCapture.Name = "hideAfterCapture";
            this.hideAfterCapture.Size = new System.Drawing.Size(86, 17);
            this.hideAfterCapture.TabIndex = 2;
            this.hideAfterCapture.Text = "&after capture";
            this.hideAfterCapture.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hide crop window";
            // 
            // opaityGroup
            // 
            this.opaityGroup.Controls.Add(this.opacityValue);
            this.opaityGroup.Controls.Add(this.showOpacityMenu);
            this.opaityGroup.Controls.Add(this.opacitySlider);
            this.opaityGroup.Controls.Add(this.opacityDescription);
            this.opaityGroup.Controls.Add(this.perPixelAlphaBlend);
            this.opaityGroup.Location = new System.Drawing.Point(8, 8);
            this.opaityGroup.Name = "opaityGroup";
            this.opaityGroup.Size = new System.Drawing.Size(316, 155);
            this.opaityGroup.TabIndex = 0;
            this.opaityGroup.TabStop = false;
            this.opaityGroup.Text = "&Opacity";
            // 
            // opacityValue
            // 
            this.opacityValue.Location = new System.Drawing.Point(16, 44);
            this.opacityValue.Name = "opacityValue";
            this.opacityValue.Size = new System.Drawing.Size(36, 24);
            this.opacityValue.TabIndex = 1;
            this.opacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // showOpacityMenu
            // 
            this.showOpacityMenu.Location = new System.Drawing.Point(20, 89);
            this.showOpacityMenu.Name = "showOpacityMenu";
            this.showOpacityMenu.Size = new System.Drawing.Size(280, 24);
            this.showOpacityMenu.TabIndex = 3;
            this.showOpacityMenu.Text = "&Show opacity menu item.";
            // 
            // opacitySlider
            // 
            this.opacitySlider.LargeChange = 1;
            this.opacitySlider.Location = new System.Drawing.Point(52, 44);
            this.opacitySlider.Maximum = 9;
            this.opacitySlider.Minimum = 1;
            this.opacitySlider.Name = "opacitySlider";
            this.opacitySlider.Size = new System.Drawing.Size(248, 45);
            this.opacitySlider.TabIndex = 2;
            this.opacitySlider.Value = 5;
            this.opacitySlider.ValueChanged += new System.EventHandler(this.HandleOpacitySliderValueChanged);
            // 
            // opacityDescription
            // 
            this.opacityDescription.Location = new System.Drawing.Point(16, 24);
            this.opacityDescription.Name = "opacityDescription";
            this.opacityDescription.Size = new System.Drawing.Size(284, 23);
            this.opacityDescription.TabIndex = 0;
            this.opacityDescription.Text = "A&djust the crop form\'s opacity level.";
            // 
            // perPixelAlphaBlend
            // 
            this.perPixelAlphaBlend.Location = new System.Drawing.Point(20, 103);
            this.perPixelAlphaBlend.Name = "perPixelAlphaBlend";
            this.perPixelAlphaBlend.Size = new System.Drawing.Size(280, 43);
            this.perPixelAlphaBlend.TabIndex = 4;
            this.perPixelAlphaBlend.Text = "Use &per pixel alpha blending. Disable if the crop form responds slowly.";
            this.perPixelAlphaBlend.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // keyboardTab
            // 
            this.keyboardTab.Controls.Add(this.hotKeySelection1);
            this.keyboardTab.Location = new System.Drawing.Point(4, 22);
            this.keyboardTab.Name = "keyboardTab";
            this.keyboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.keyboardTab.Size = new System.Drawing.Size(336, 395);
            this.keyboardTab.TabIndex = 4;
            this.keyboardTab.Text = "Keyboard";
            this.keyboardTab.UseVisualStyleBackColor = true;
            // 
            // hotKeySelection1
            // 
            this.hotKeySelection1.Location = new System.Drawing.Point(30, 30);
            this.hotKeySelection1.Name = "hotKeySelection1";
            this.hotKeySelection1.Size = new System.Drawing.Size(267, 160);
            this.hotKeySelection1.TabIndex = 0;
            // 
            // pluginsTab
            // 
            this.pluginsTab.Controls.Add(this.panel1);
            this.pluginsTab.Controls.Add(this.comboBox1);
            this.pluginsTab.Location = new System.Drawing.Point(4, 22);
            this.pluginsTab.Name = "pluginsTab";
            this.pluginsTab.Size = new System.Drawing.Size(336, 395);
            this.pluginsTab.TabIndex = 3;
            this.pluginsTab.Text = "Plug-ins";
            this.pluginsTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 362);
            this.panel1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(327, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // includeMouseCursorInCapture
            // 
            this.includeMouseCursorInCapture.Location = new System.Drawing.Point(19, 40);
            this.includeMouseCursorInCapture.Name = "includeMouseCursorInCapture";
            this.includeMouseCursorInCapture.Size = new System.Drawing.Size(268, 20);
            this.includeMouseCursorInCapture.TabIndex = 4;
            this.includeMouseCursorInCapture.Text = "Include &mouse cursor in capture.";
            // 
            // Options
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(361, 475);
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
            this.nonRectangularCapturesGroup.ResumeLayout(false);
            this.outputTemplateGroup.ResumeLayout(false);
            this.outputTemplateGroup.PerformLayout();
            this.outputFolderGroup.ResumeLayout(false);
            this.outputFolderGroup.PerformLayout();
            this.hotKeysGroup.ResumeLayout(false);
            this.optionsTabs.ResumeLayout(false);
            this.outputTab.ResumeLayout(false);
            this.capturesTab.ResumeLayout(false);
            this.otherOptionsDescription.ResumeLayout(false);
            this.appearanceTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.opaityGroup.ResumeLayout(false);
            this.opaityGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).EndInit();
            this.keyboardTab.ResumeLayout(false);
            this.pluginsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void HandleFolderChooserButtonClick(object sender, EventArgs e)
        {
            if (folder.ShowDialog() == DialogResult.OK)
                folderChooser.Text = folder.SelectedPath;
        }

        private void HandleOkClick(object sender, EventArgs e)
        {
            if(addingSize)
            {
                addingSize = false;
                return;
            }

            Configuration.Current.OutputPath = folderChooser.Text;
            if (ValidateFileName(fullImageTemplate.Text))
                Configuration.Current.FullImageTemplate = fullImageTemplate.Text;
            if (ValidateFileName(thumbImageTemplate.Text))
                Configuration.Current.ThumbImageTemplate = thumbImageTemplate.Text;

            Configuration.Current.ColorNonFormArea = colorNonFormAreaCheck.Checked;
            Configuration.Current.NonFormAreaColorArgb = backgroundColor.BackColor.ToArgb();
            Configuration.Current.UserOpacity = (double) (opacitySlider.Value*10)/100;
            Configuration.Current.ShowOpacityMenu = showOpacityMenu.Checked;
            Configuration.Current.TrapPrintScreen = trapPrintScreen.Checked;
            Configuration.Current.UsePerPixelAlpha = perPixelAlphaBlend.Checked;
            Configuration.Current.HideFormDuringCapture = hideDuringCapture.Checked;
            Configuration.Current.HideFormAfterCapture = hideAfterCapture.Checked;
            Configuration.Current.LeavePrintScreenOnClipboard = keepPrntScrnOnClipboard.Checked;
            Configuration.Current.AllowMultipleInstances = allowMultipleCropperInstances.Checked;
            Configuration.Current.IncludeMouseCursorInCapture = includeMouseCursorInCapture.Checked;

            List<CropSize> cropSize = new List<CropSize>();
            foreach (CropSize size in predefinedSizeList.Items)
                cropSize.Add(size);
            Configuration.Current.PredefinedSizes = cropSize.ToArray();

            List<object> pluginSettings = new List<object>();
            foreach (IPersistableImageFormat output in ImageCapture.ImageOutputs)
            {
                IConfigurablePlugin plugin = output as IConfigurablePlugin;
                if (plugin != null && plugin.ConfigurationForm != null)
                    plugin.ConfigurationForm.Save();
                if (plugin != null && plugin.Settings != null)
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
            MenuItem item = sender as MenuItem;
            if (item != null)
                InsertTemplate(currentTextBox, "{" + item.Text.ToLower() + "}");
            currentTextBox.Focus();
            currentTextBox.SelectionLength = 0;
        }

        private static void InsertTemplate(TextBoxBase templateBox, string template)
        {
            templateBox.SelectedText = template;
        }

        private void HandleTextBoxTextChanged(object sender, EventArgs e)
        {
            TextBox validateBox = sender as TextBox;
            if (validateBox == null)
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
                toolTip.SetToolTip(backgroundColor, string.Format("Color\nRed:{0}\nGreen{1}\nBlue:{2}", backgroundColor.BackColor.R, backgroundColor.BackColor.G, backgroundColor.BackColor.B));
            }
        }

        private void HandleOpacitySliderValueChanged(object sender, EventArgs e)
        {
            opacityValue.Text = (opacitySlider.Value*10) + "%";
        }

        private Form configForm;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configForm != null)
            {
                configForm.Hide();
                panel1.Controls.Remove(configForm);
                configForm = null;
            }

            IConfigurablePlugin plugin = comboBox1.SelectedItem as IConfigurablePlugin;
            if (plugin != null && plugin.ConfigurationForm != null)
            {
                configForm = plugin.ConfigurationForm;
                SetVisualStyleEnhanced(configForm, VisualStyleEnhanced.Yes);

                if (plugin.HostInOptions)
                    ShowHostedConfiguration();
                else
                    ShowDialogConfiguration();
            }
        }

        private static void SetVisualStyleEnhanced(Control parent, VisualStyleEnhanced enhanced)
        {
            VisualStyleFilter.Global.SetVisualStyleEnhanced(parent, enhanced);

            if (parent.HasChildren)
                foreach (Control child in parent.Controls)
                    SetVisualStyleEnhanced(child, enhanced);
        }

        private void ShowHostedConfiguration()
        {
            configForm.TopLevel = false;
            configForm.FormBorderStyle = FormBorderStyle.None;
            configForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(configForm);
            configForm.Show();
        }

        private void ShowDialogConfiguration()
        {
            configForm.StartPosition = FormStartPosition.CenterParent;
            configForm.ShowDialog(this);
        }

        private void HandleAddSizeClick(object sender, EventArgs e)
        {
            AddSize();
        }

        private void AddSize() 
        {
            if (!isNumeric.Match(widthInput.Text).Success || !isNumeric.Match(heightInput.Text).Success)
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
            TextBox box = sender as TextBox;
            if (box == null) 
                return;

            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
        }

        private void HandleSizeInputPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addingSize = true;
                AddSize();
            }
        }

        private void SizeInputTextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if(box == null)
                return;

            if (!isNumeric.Match(box.Text).Success)
                errorProvider.SetError(box, "Only numeric values are valid.");
            else
                errorProvider.SetError(box, null);
        }
    }
}