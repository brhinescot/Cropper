#region Using Directives

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper.Core
{
	/// <summary> 
	/// Summary description for Plugins.
	/// </summary>
	public sealed class Plugins : MarshalByRefObject
	{
		#region Member Variables

		private const string PluginFolder = @"plugins";
		private const string PluginExtensionFilter = "*.dll";
		private const string PluginInterfaceName = "IPersistableImageFormat";

		#endregion

		private Plugins() { }

		public static ImageOutputCollection Load()
		{
			ImageOutputCollection imageOutputCollection = new ImageOutputCollection();

			foreach (string path in LoadValidAssemblies())
			{
				try
				{
				    Assembly assembly = Assembly.LoadFrom(path);
				    IPersistableImageFormat imageFormatPlugin = ExamineAssembly(assembly);
					if (imageFormatPlugin != null)
						imageOutputCollection.Add(imageFormatPlugin);
				}
				catch (FileLoadException e)
				{
					Debug.WriteLine(e.Message);
				}
			}
			return imageOutputCollection;
		}

		private static IPersistableImageFormat ExamineAssembly(Assembly assembly)
		{
			IPersistableImageFormat imageFormatPlugin = null;

			try
			{
				//Enumerate through the assembly object
				//
				foreach (Type testType in assembly.GetTypes())
				{
					//Look for public types and ignore abstract classes
					//
					if (testType.IsPublic && testType.Attributes != TypeAttributes.Abstract)
					{
						//Does the type implement the proper interface
						//
						if ((testType.GetInterface(PluginInterfaceName, true)) != null && testType.IsClass && !testType.IsAbstract)
						{
							object pluginObject = assembly.CreateInstance(testType.FullName);
							imageFormatPlugin = (IPersistableImageFormat)pluginObject;
						}
					}
				}
			}
			catch (ReflectionTypeLoadException) { }
			catch (FileLoadException) { }
			return imageFormatPlugin;
		}

		private static string[] ParsePluginDirectory()
		{
			string[] pluginPaths = new string[0];
			string directory = (Path.Combine(Application.StartupPath, PluginFolder));
			if (Directory.Exists(directory))
				pluginPaths = Directory.GetFileSystemEntries(directory, PluginExtensionFilter);

			return pluginPaths;
		}

		private static string[] LoadValidAssemblies()
		{
			// Create a temporary app domain so that we can unload assemblies
			//
			AppDomain domain = AppDomain.CreateDomain("TempDomain" + Guid.NewGuid());
			domain.SetupInformation.ApplicationBase = Environment.CurrentDirectory;

			string[] validAssemblies = new string[] { };

			try
			{
				// Find the name of this assembly and load it into the domain
				//
				AssemblyName objName = Assembly.GetExecutingAssembly().GetName(false);
				domain.Load(objName);

				// Create an instance of this type 
				// in the temporary domain
				//
				BindingFlags binding = BindingFlags.CreateInstance |
															 BindingFlags.NonPublic | BindingFlags.Instance;

				ObjectHandle handle = domain.CreateInstanceFrom(
					objName.CodeBase, typeof(Plugins).ToString(), false,
					binding, null, null, null, null);

				Plugins helper = (Plugins)handle.Unwrap();

				validAssemblies = helper.DiscoverPluginAssembliesHelper();
			}
			catch (BadImageFormatException) { }
			catch (FileNotFoundException) { }
			catch (SecurityException) { }
			finally
			{
				// Unload any unwanted assemblies
				//
				AppDomain.Unload(domain);
			}
			return validAssemblies;
		}

		// Should not be made static even though no memebr fields are ever accessed.
		private string[] DiscoverPluginAssembliesHelper()
		{
			ArrayList assemblies = new ArrayList();
			foreach (string pluginPath in ParsePluginDirectory())
			{
				try
				{
					Assembly assembly = Assembly.LoadFile(pluginPath);
					//Enumerate through the assembly object
					//
					foreach (Type type in assembly.GetTypes())
					{
						//Look for public types and ignore abstract classes
						//
						if (type.IsPublic && type.Attributes != TypeAttributes.Abstract)
							if ((type.GetInterface(PluginInterfaceName, false)) != null)
								assemblies.Add(pluginPath);
					}
				}
				catch (ReflectionTypeLoadException) { }
				catch (FileLoadException) { }
			}

			return (string[])assemblies.ToArray(typeof(string));
		}
	}
}
