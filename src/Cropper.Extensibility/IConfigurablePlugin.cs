namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    ///     Represents the contract for plug-ins that use the built in configuration support.
    /// </summary>
    public interface IConfigurablePlugin : IPersistableImageFormat
    {
        /// <summary>
        ///     Gets the plug-in's impementation of the <see cref="BaseConfigurationForm" /> used for setting plug-in specific
        ///     options.
        /// </summary>
        BaseConfigurationForm ConfigurationForm { get; }

        /// <summary>
        ///     Gets a value indicating if the <see cref="ConfigurationForm" /> is to be hosted in the options dialog or shown in
        ///     its own dialog window.
        /// </summary>
        bool HostInOptions { get; }

        /// <summary>
        ///     Gets or sets an object containing the plug-in's settings.
        /// </summary>
        /// <remarks>
        ///     <para>This property is set during startup with the settings contained in the applications configuration file.</para>
        ///     <para>The object returned by this property is serialized into the applications configuration file on shutdown.</para>
        /// </remarks>
        object Settings { get; set; }
    }
}