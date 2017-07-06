#region Using Directives

using NUnit.Framework;

#endregion

namespace Fusion8.Cropper.Core
{
    [TestFixture]
    public class CropSizeTests
    {
        [Test]
        public void CompareTo_uses_Height()
        {
            int expected = -1;
            int width = 119;

            CropSize left = new CropSize(width, 0);
            CropSize right = new CropSize(width, 1);

            Assert.AreEqual(expected, left.CompareTo(right));
        }

        [Test]
        public void CompareTo_uses_Width()
        {
            int expected = -1;
            int height = 104;

            CropSize left = new CropSize(0, height);
            CropSize right = new CropSize(1, height);

            Assert.AreEqual(expected, left.CompareTo(right));
        }

        [Test]
        public void Constructor_parameters_are_not_altered()
        {
            int width = 119;
            int height = 104;

            CropSize size = new CropSize(width, height);

            Assert.AreEqual(width, size.Width);
            Assert.AreEqual(height, size.Height);
        }

        [Test]
        public void Evaluating_equals_returns_false_if_the_object_is_not_a_CropSize()
        {
            CropSize size = new CropSize();
            object obj = new object();

            Assert.IsFalse(size.Equals(obj));
        }

        [Test]
        public void GetHashCode_uses_Width_and_Height()
        {
            int width = 119;
            int height = 104;
            int expected = width + 29 * height;

            CropSize size = new CropSize(width, height);

            Assert.AreEqual(expected, size.GetHashCode());
        }

        [Test]
        public void ToString_returns_width_x_height()
        {
            int width = 119;
            int height = 104;
            string expected = width + " x " + height;

            CropSize size = new CropSize(width, height);

            Assert.AreEqual(expected, size.ToString());
        }

        [Test]
        public void Two_CropSize_are_equal_if_Width_and_Height_match()
        {
            int width = 119;
            int height = 104;

            CropSize left = new CropSize(width, height);
            CropSize right = new CropSize(width, height);

            Assert.IsTrue(left.Equals(right));
            Assert.IsTrue(left.Equals((object) right));
        }

        [Test]
        public void Two_CropSize_are_not_equal_if_Height_differs()
        {
            int width = 119;

            CropSize left = new CropSize(width, 0);
            CropSize right = new CropSize(width, 1);

            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(left.Equals((object) right));
        }

        [Test]
        public void Two_CropSize_are_not_equal_if_Width_differs()
        {
            int height = 104;

            CropSize left = new CropSize(0, height);
            CropSize right = new CropSize(1, height);

            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(left.Equals((object) right));
        }

        [Test]
        public void Two_CropSize_CompareTo()
        {
            int expected = 0;
            int width = 119;
            int height = 104;

            CropSize left = new CropSize(width, height);
            CropSize right = new CropSize(width, height);

            Assert.AreEqual(expected, left.CompareTo(right));
        }
    }
}