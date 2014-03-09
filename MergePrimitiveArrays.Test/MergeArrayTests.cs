using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        
        [TestMethod]
        public void TestMultipleSameValues()
        {
            var aArray = new[] { 1, 2, 2, 2, 2, 2, 2 };
            var bArray = new[] { 1, 2, 3, 3, 3, 3, 3 };

            int[] expectedArray = { 3, 2, 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }
        
        [TestMethod]
        public void TestManyInARowFromOneArray()
        {
            var aArray = new[] { 1, 2, 3, 5, 6, 7, 9 };
            var bArray = new[] { 1, 40 };

            int[] expectedArray = { 40, 9, 7, 6, 5, 3, 2, 1 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }

        [TestMethod]
        public void TestCreatedFromRandomValues()
        {
            var aArray = new[] { 9648, 12420, 32213, 59411, 108989, 137730, 295350, 339609, 427849, 428773 };
            var bArray = new[] { 96386, 108954, 117991, 149700, 163490, 223089, 235891, 258339, 365030, 373734 };

            int[] expectedArray = { 428773, 427849, 373734, 365030, 339609, 295350, 258339, 235891, 223089, 163490, 149700, 137730, 117991, 108989, 108954, 96386, 59411, 32213, 12420, 9648 };

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }
        
        [TestMethod]
        public void TestVeryLargeArrays()
        {
            const int size = 10000;

            var aArray = new int[size];
            var bArray = new int[size];

            var r = new Random();

            for (var i = 0; i < size; i++)
            {
                aArray[i] = r.Next(0, 500000);
                bArray[i] = r.Next(0, 500000);
            }
            Array.Sort(aArray);
            Array.Sort(bArray);

            var resultList = new List<int>();
            resultList.AddRange(aArray);
            resultList.AddRange(bArray);
            resultList.Sort();
            resultList.Reverse();

            int[] expectedArray = resultList.Distinct().ToArray();

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);
            
            CollectionAssert.AreEqual(
                expectedArray,
                result,
                string.Format("Expected {0}, but received {1}.", ArrayToString(expectedArray), ArrayToString(result))
                );
        }

        [TestMethod]
        public void TestNegativeValues()
        {
            var aArray = new[] { -5 };
            var bArray = new[] { -2, 5, 6, 8, 9 };

            int[] expectedArray = { 9, 8, 6, 5, -2, -5 };

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
            var result = new StringBuilder();

            foreach (var value in array)
            {
                result.Append(string.Format(", {0}", value));
            }

            return string.Format("[ {0} ]", result.ToString().Substring(2));
        }
        #endregion
    }
}
