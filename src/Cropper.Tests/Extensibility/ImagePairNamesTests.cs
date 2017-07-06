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
        public void GetHashCode_throws_an_exception_if_FullSize_is_null()
        {
            string thumbnail = "thumbnail";

            ImagePairNames pair = new ImagePairNames();
            pair.Thumbnail = thumbnail;

            Assert.Throws<NullReferenceException>(() => pair.GetHashCode());
        }

        [Test]
        public void GetHashCode_throws_an_exception_if_Thumbnail_is_null()
        {
            string fullSize = "fullSize";

            ImagePairNames pair = new ImagePairNames();
            pair.FullSize = fullSize;

            Assert.Throws<NullReferenceException>(() => pair.GetHashCode());
        }

        [Test]
        public void Evaluating_equals_throws_an_exception_if_the_object_is_not_an_ImagePairNames()
        {
            ImagePairNames pair = new ImagePairNames();
            object obj = new object();

            Assert.Throws<InvalidCastException>(() => pair.Equals(obj));
        }
    }
}