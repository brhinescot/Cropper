#region Using Directives

using System;
using System.IO;
using Fusion8.Cropper.Extensibility;
using NUnit.Framework;

#endregion

namespace Fusion8.Cropper.Core
{
    [TestFixture]
    public class FileNameTemplateTests
    {
        [Test]
        public void DefaultFullImageTemplate_is_CropperCaptureincremnt_by_default()
        {
            string expected = "CropperCapture[{increment}]";

            Assert.AreEqual(expected, FileNameTemplate.DefaultFullImageTemplate);
        }

        [Test]
        public void DefaultThumbImageTemplate_is_CropperCaptureincremntThumbnail_by_default()
        {
            string expected = "CropperCapture[{increment}]Thumbnail";

            Assert.AreEqual(expected, FileNameTemplate.DefaultThumbImageTemplate);
        }

        [Test]
        public void Domain_is_replaced()
        {
            string outputPath = Configuration.Current.OutputPath;
            string domain = Environment.UserDomainName;
            string extension = "ext";
            string expectedFullSize = Path.Combine(outputPath, domain + "." + extension);
            string expectedThumbnail = Path.Combine(outputPath, domain + "Thumbnail." + extension);

            Configuration.Current.FullImageTemplate = "{domain}";
            Configuration.Current.ThumbImageTemplate = "{domain}Thumbnail";
            ImagePairNames names = new FileNameTemplate().Parse(extension);

            Assert.AreEqual(expectedFullSize, names.FullSize);
            Assert.AreEqual(expectedThumbnail, names.Thumbnail);
        }

        [Test]
        public void Extension_is_replaced()
        {
            string outputPath = Configuration.Current.OutputPath;
            string extension = "ext";
            string expectedFullSize = Path.Combine(outputPath, extension + "." + extension);
            string expectedThumbnail = Path.Combine(outputPath, extension + "Thumbnail." + extension);

            Configuration.Current.FullImageTemplate = "{extension}";
            Configuration.Current.ThumbImageTemplate = "{extension}Thumbnail";
            ImagePairNames names = new FileNameTemplate().Parse(extension);

            Assert.AreEqual(expectedFullSize, names.FullSize);
            Assert.AreEqual(expectedThumbnail, names.Thumbnail);
        }

        [Test]
        public void Machine_is_replaced()
        {
            string outputPath = Configuration.Current.OutputPath;
            string machine = Environment.MachineName;
            string extension = "ext";
            string expectedFullSize = Path.Combine(outputPath, machine + "." + extension);
            string expectedThumbnail = Path.Combine(outputPath, machine + "Thumbnail." + extension);

            Configuration.Current.FullImageTemplate = "{machine}";
            Configuration.Current.ThumbImageTemplate = "{machine}Thumbnail";
            ImagePairNames names = new FileNameTemplate().Parse(extension);

            Assert.AreEqual(expectedFullSize, names.FullSize);
            Assert.AreEqual(expectedThumbnail, names.Thumbnail);
        }

        [Test]
        public void Parse_starts_the_increment_at_1()
        {
            string outputPath = Configuration.Current.OutputPath;
            string extension = "ext";
            string expectedFullSize = Path.Combine(outputPath, "CropperCapture[1]." + extension);
            string expectedThumbnail = Path.Combine(outputPath, "CropperCapture[1]Thumbnail." + extension);

            ImagePairNames names = new FileNameTemplate().Parse(extension);

            Assert.AreEqual(expectedFullSize, names.FullSize);
            Assert.AreEqual(expectedThumbnail, names.Thumbnail);
        }

        [Test]
        public void User_is_replaced()
        {
            string outputPath = Configuration.Current.OutputPath;
            string user = Environment.UserName;
            string extension = "ext";
            string expectedFullSize = Path.Combine(outputPath, user + "." + extension);
            string expectedThumbnail = Path.Combine(outputPath, user + "Thumbnail." + extension);

            Configuration.Current.FullImageTemplate = "{user}";
            Configuration.Current.ThumbImageTemplate = "{user}Thumbnail";
            ImagePairNames names = new FileNameTemplate().Parse(extension);

            Assert.AreEqual(expectedFullSize, names.FullSize);
            Assert.AreEqual(expectedThumbnail, names.Thumbnail);
        }
    }
}