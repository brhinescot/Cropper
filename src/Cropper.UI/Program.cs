#region Using Directives

using System;
using System.Threading;
using System.Windows.Forms;
using Fusion8.Cropper.Core;

#endregion

namespace Fusion8.Cropper
{
	/// <summary>
	/// Summary description for Program.
	/// </summary>
	public sealed class Program
	{
		private Program() {}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
            bool isFirstInstance;
            Mutex mutex = new Mutex(false, "Local\\Cropper", out isFirstInstance);
            if (Configuration.Current.AllowMultipleInstances || isFirstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            
                MainCropForm mainCropForm = new MainCropForm();
            
                mainCropForm.Closed += HandleMainCropFormClosed;
				Application.Run();
                GC.KeepAlive(mutex);
            }
		}

		private static void HandleMainCropFormClosed(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}