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
using NUnit.Framework;

namespace Fusion8.Cropper.Extensibility
{
    [TestFixture]
    public class ImagePairNamesTests
    {
        [Test]
        public void Constructor_parameters_are_not_altered()
        {
            string fullSize = "fullSize";
            string thumbnail = "thumbnail";

            ImagePairNames pair = new ImagePairNames(fullSize, thumbnail);

            Assert.AreEqual(fullSize, pair.FullSize);
            Assert.AreEqual(thumbnail, pair.Thumbnail);
        }

        [Test]
        public void Two_ImagePairNames_are_not_equal_if_FullSize_differs()
        {
            string thumbnail = "thumbnail";

            ImagePairNames left = new ImagePairNames("left", thumbnail);
            ImagePairNames right = new ImagePairNames("right", thumbnail);

            Assert.IsFalse(left == right);
            Assert.IsTrue(left != right);
            Assert.IsFalse(left.Equals(right));
        }

        [Test]
        public void Two_ImagePairNames_are_not_equal_if_Thumbnail_differs()
        {
            string fullSize = "fullSize";

            ImagePairNames left = new ImagePairNames(fullSize, "left");
            ImagePairNames right = new ImagePairNames(fullSize, "right");

            Assert.IsFalse(left == right);
            Assert.IsTrue(left != right);
            Assert.IsFalse(left.Equals(right));
        }

        [Test]
        public void Two_ImagePairNames_are_equal_if_FullSize_and_Thumbnail_match()
        {
            string fullSize = "fullSize";
            string thumbnail = "thumbnail";

            ImagePairNames left = new ImagePairNames(fullSize, thumbnail);
            ImagePairNames right = new ImagePairNames(fullSize, thumbnail);

            Assert.IsTrue(left == right);
            Assert.IsFalse(left != right);
            Assert.IsTrue(left.Equals(right));
        }

        [Test]
        public void Evaluating_equals_throws_an_exception_if_the_left_FullSize_is_null()
        {
            Type expected = typeof(NullReferenceException);
            string thumbnail = "thumbnail";

            ImagePairNames left = new ImagePairNames();
            left.Thumbnail = thumbnail;
            ImagePairNames right = new ImagePairNames();

            try
            {
                bool result = left == right;
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.GetType());
            }

            try
            {
                bool result = left != right;
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.GetType());
            }

            try
            {
                bool result = left.Equals(right);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.GetType());
            }
        }

        [Test]
        public void Evaluating_equals_throws_an_exception_if_the_left_Thumbnail_is_null()
        {
            Type expected = typeof(NullReferenceException);
            string fullSize = "fullSize";

            ImagePairNames left = new ImagePairNames();
            left.FullSize = fullSize;
            ImagePairNames right = new ImagePairNames();

            try
            {
                bool result = left == right;
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.GetType());
            }

            try
            {
                bool result = left != right;
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.GetType());
            }

            try
            {
                bool result = left.Equals(right);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.GetType());
            }
        }

        [Test]
        public void GetHashCode_is_the_combined_HashCode_of_FullSize_and_Thumbnail()
        {
            string fullSize = "fullSize";
            string thumbnail = "thumbnail";
            int expected = fullSize.GetHashCode() + thumbnail.GetHashCode();

            ImagePairNames pair = new ImagePairNames(fullSize, thumbnail);

            Assert.AreEqual(expected, pair.GetHashCode());
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetHashCode_throws_an_exception_if_FullSize_is_null()
        {
            string thumbnail = "thumbnail";

            ImagePairNames pair = new ImagePairNames();
            pair.Thumbnail = thumbnail;

            pair.GetHashCode();
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetHashCode_throws_an_exception_if_Thumbnail_is_null()
        {
            string fullSize = "fullSize";

            ImagePairNames pair = new ImagePairNames();
            pair.FullSize = fullSize;

            pair.GetHashCode();
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void Evaluating_equals_throws_an_exception_if_the_object_is_not_an_ImagePairNames()
        {
            ImagePairNames pair = new ImagePairNames();
            object obj = new object();

            pair.Equals(obj);
        }
    }
}