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

using System;
using System.IO;
using Fusion8.Cropper.Extensibility;
using NUnit.Framework;

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
    }
}