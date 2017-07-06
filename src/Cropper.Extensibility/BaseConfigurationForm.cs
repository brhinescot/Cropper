#region Using Directives

using System;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    /// Represents the base configuration form for plug-ins that implement the <see cref="IConfigurablePlugin"/> interface.
    /// </summary>
    /// <remarks>
    /// The form is presented to the user via the <see cref="IConfigurablePlugin.ConfigurationForm"/> property.
    /// </remarks>
    /// <example>
    /// <para>
    /// The following example shows how to use the <see cref="BaseConfigurationForm"/> to obtain 
    /// configuration data from the user.</para>
    /// <code>
    ///     private Options configurationForm;
    /// 
    ///     public BaseConfigurationForm ConfigurationForm
    ///     {
    ///         get
    ///         {
    ///             if (configurationForm == null)
    ///             {
    ///                 configurationForm = new Options();
    ///                 configurationForm.OptionsSaved += HandleConfigurationFormOptionsSaved;
    ///                 configurationForm.Format = PluginSettings.Format;
    ///                 configurationForm.ImageQuality = PluginSettings.ImageQuality;
    ///             }
    ///             return configurationForm;
    ///         }
    ///     }
    /// 
    ///     private void HandleConfigurationFormOptionsSaved(object sender, EventArgs e)
    ///     {
    ///         PluginSettings.Format = configurationForm.Format;
    ///         PluginSettings.ImageQuality = configurationForm.ImageQuality;
    ///     }
    /// </code>
    /// <para>
    /// The Options class in the example is derived from <see cref="BaseConfigurationForm"/> and contains two additional
    /// properties:
    /// <code>
    /// public class Options : BaseConfigurationForm
    /// {
    ///     public ClipboardOutputFormat Format{get;set;}
    ///     public int ImageQuality{get;set;}
    /// }
    /// </code></para>
    /// </example>
    public partial class BaseConfigurationForm : Form
    {
        #region Member Fields

        public event EventHandler OptionsSaved;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationForm"/>
        /// </summary>
        public BaseConfigurationForm()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Save the plug-in's settings.
        ///</summary>
        public void Save()
        {
            OnOptionsSaved(EventArgs.Empty);
        }

        protected virtual void OnOptionsSaved(EventArgs e)
        {
            EventHandler handler = OptionsSaved;
            if (handler != null)
                handler(this, e);
        }
    }
}