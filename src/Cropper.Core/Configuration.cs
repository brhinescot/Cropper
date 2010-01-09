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

		private static readonly string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SR.ConfigurationPath);
		private static readonly string portableConfigPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "cropper.portable");
		private static readonly string portableOutputPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Cropper Captures");
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
                    if (File.Exists(portableConfigPath))
                    {
                        cropperSettings = LoadConfiguration(portableConfigPath);
                        cropperSettings.OutputPath = portableOutputPath;
                    }
                    else
                    {
                        cropperSettings = LoadConfiguration(configPath);
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
				throw new ArgumentNullException("path", SR.ExceptionConfigPathNull);

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
            if (File.Exists(portableConfigPath))
                SaveConfiguration(cropperSettings, portableConfigPath);
            else
                SaveConfiguration(cropperSettings, configPath);
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
		        throw new ArgumentNullException("path", SR.ExceptionConfigPathNull);

		    if (null == settings)
		        throw new ArgumentNullException("settings", SR.ExceptionConfigObjectNull);

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
            
		    return;
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
	            if (plugin != null && plugin.Settings != null)
	                types.Add(plugin.Settings.GetType());
	        }
	        return types.ToArray();
	    }

	    #endregion
	}
}