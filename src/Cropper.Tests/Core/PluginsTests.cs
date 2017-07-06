#region Using Directives

using NUnit.Framework;

#endregion

namespace Fusion8.Cropper.Core
{
    [TestFixture]
    public class PluginsTests
    {
        [Test]
        [Ignore("To support http://cropper.codeplex.com/Thread/View.aspx?ThreadId=76727 Plugins.ParsePluginDirectory needs to be Application.StartupPath. Under that value the Plugins class will not find any of the plugin assemblies.")]
        public void An_assembly_that_contains_only_an_abstrat_implementation_of_the_IPersistableImageFormat_interface_does_not_crash_the_application()
        {
            Plugins.Load();
        }
    }
}