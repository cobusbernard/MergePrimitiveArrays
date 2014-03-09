using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergePrimitiveArrays.Test
{
    [TestClass]
    public class MergeArrayTests
    {
        #region Tests
        [TestMethod]
        public void TestPlainMerge()
        {
            var aArray = new[] { 1, 3, 5 };
            var bArray = new[] { 2, 4, 6 };

            int[] expectedArray = { 6, 5, 4, 3, 2, 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }

        [TestMethod]
        public void TestOneArraySingleValue()
        {
            var aArray = new[] { 1 };
            var bArray = new[] { 2, 5, 6, 8, 9 };

            int[] expectedArray = { 9, 8, 6, 5, 2, 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }

        [TestMethod]
        public void TestBothArraysSingleValueDifferent()
        {
            var aArray = new[] { 1 };
            var bArray = new[] { 2 };

            int[] expectedArray = { 2, 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray, 
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }

        [TestMethod]
        public void TestBothArraysSingleValueSame()
        {
            var aArray = new[] { 1 };
            var bArray = new[] { 1 };

            int[] expectedArray = { 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }

        [TestMethod]
        public void TestBothArraysSameValues()
        {
            var aArray = new[] { 1, 2, 3 };
            var bArray = new[] { 1, 2, 3 };

            int[] expectedArray = { 3, 2, 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }

        #endregion

        #region Helper Methods
        private string ArrayToString(int[] array)
        {
            var result = array.Aggregate("", (current, value) => current + string.Format(", {0}", value));

            return string.Format("[ {0} ]",result.Substring(2));
        }
        #endregion
    }
}
