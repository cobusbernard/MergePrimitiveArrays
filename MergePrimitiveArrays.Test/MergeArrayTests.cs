using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergePrimitiveArrays.Test
{
    [TestClass]
    public class MergeArrayTests
    {
        [TestMethod]
        public void TestPlainMerge()
        {
            var aArray = new[] { 1, 3, 5 };
            var bArray = new[] { 2, 4, 6 };

            int[] expectedArray = { 1, 2, 3, 4, 5, 6 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void TestOneArraySingleValue()
        {
            var aArray = new[] { 1 };
            var bArray = new[] { 2, 5, 6, 8, 9 };

            int[] expectedArray = { 1, 2, 5, 6, 8, 9 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void TestBothArraysSingleValueDifferent()
        {
            var aArray = new[] { 1 };
            var bArray = new[] { 2 };

            int[] expectedArray = { 1, 2 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void TestBothArraysSingleValueSame()
        {
            var aArray = new[] { 1 };
            var bArray = new[] { 1 };

            int[] expectedArray = { 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void TestBothArraysSameValues()
        {
            var aArray = new[] { 1, 2, 3 };
            var bArray = new[] { 1, 2, 3 };

            int[] expectedArray = { 1, 2, 3 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(expectedArray, result);
        }

    }
}
