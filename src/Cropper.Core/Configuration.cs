#region Using Directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper.Core
{
	public static class Configuration
	{
		#region Member Variables

		private static readonly string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SR.ConfigurationPath);
		private static readonly string PortableConfigPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "cropper.portable");
		private static readonly string PortableOutputPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Cropper Captures");
		private static Settings cropperSettings;
	    private static ConfigurationPersistence<Settings> configurationPersistence;

		#endregion		

		#region .ctor

	    #endregion

		#region Methods

		public static Settings Current
		{
			get
			{
				if (cropperSettings == null)
				{
                    if (File.Exists(PortableConfigPath))
                    {
                        cropperSettings = LoadConfiguration(PortableConfigPath);
                        cropperSettings.OutputPath = PortableOutputPath;
                    }
                    else
                    {
                        cropperSettings = LoadConfiguration(ConfigPath);
                        if (!Directory.Exists(cropperSettings.OutputPath))
                            cropperSettings.OutputPath = Settings.DefaultOutputPath;
                    }
				}
				return cropperSettings;
			}
		}

        /// <summary>
        /// Lazily creates a single instance of the <see cref="ConfigurationPersistence" /> class so that the configuration can be saved when the user logs off, restarts, or shuts down.
        /// </summary>
	    private static ConfigurationPersistence<Settings> ConfigurationPersistence
	    {
	        get
	        {
	            if (configurationPersistence == null)
	            {
                    configurationPersistence = new ConfigurationPersistence<Settings>(Settings.XmlRootName, Settings.RootNamespace, GetAdditionalTypes());
	            }

	            return configurationPersistence;
	        }
	    }

		/// <summary>
		/// Loads the configuration file.
		/// </summary>
		/// <remarks>The <see cref="Settings"/> class is xml deserialized from disk.</remarks>
		/// <param name="path"></param>
		/// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null; nothing 
        /// in Visual Basic.</exception>
		private static Settings LoadConfiguration(string path)
		{
			if (null == path)
				throw new ArgumentNullException(nameof(path), SR.ExceptionConfigPathNull);

			try
			{
			    if (!File.Exists(path))
			        return new Settings();

                return ConfigurationPersistence.Load(path);
			}
			catch (SerializationException)
			{
				//If the file can't be deserialized, just return a new, default one.
				//
				return new Settings();
			}
			catch (InvalidCastException)
			{
				//If the file can't be deserialized, just return a new, default one.
				//
				return new Settings();
			}
			catch (InvalidOperationException)
			{
				//If the file can't be deserialized, just return a new, default one.
				//
				return new Settings();
			}
			catch (IOException)
			{
				//If the file can't be deserialized, just return a new, default one.
				//
				return new Settings();
			}
		}

	    /// <summary>
		/// Client exposed save method.
		/// </summary>
		public static void Save()
	    {
	        SaveConfiguration(cropperSettings, File.Exists(PortableConfigPath) ? PortableConfigPath : ConfigPath);
	    }

		/// <summary>
		/// Save the configuration settings to a file.
		/// </summary>
		/// <remarks>The <see cref="Configuration"/> class is binary serialized to disk.</remarks>
		/// <param name="settings">The configuration object to save.</param>
		/// <param name="path">The path where the file should be saved.</param>
		/// <returns>true if successful, false if not.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="settings"/> or <paramref name="path"/> 
        /// is null; nothing in Visual Basic.</exception>
		private static void SaveConfiguration(Settings settings, string path)
		{
		    if (null == path)
		        throw new ArgumentNullException(nameof(path), SR.ExceptionConfigPathNull);

		    if (null == settings)
		        throw new ArgumentNullException(nameof(settings), SR.ExceptionConfigObjectNull);

		    EnsureConfigDirectory(path);

		    try
		    {
		        ConfigurationPersistence.Save(path, settings);
		    }
		    catch (IOException)
		    {
		        //An error occured, let the client know.
		        //
		    }
		    catch (InvalidOperationException)
		    {
		        //An error occured, let the client know.
		        //
		    }
		}

	    private static void EnsureConfigDirectory(string path)
	    {
	        if (!Directory.Exists(Path.GetDirectoryName(path)))
	            Directory.CreateDirectory(Path.GetDirectoryName(path));
	    }

	    private static Type[] GetAdditionalTypes()
	    {
	        List<Type> types = new List<Type>();
	        foreach (IPersistableImageFormat format in ImageCapture.ImageOutputs)
	        {
	            IConfigurablePlugin plugin = format as IConfigurablePlugin;
	            if (plugin?.Settings != null)
	                types.Add(plugin.Settings.GetType());
	        }
	        return types.ToArray();
	    }

	    #endregion
	}
}