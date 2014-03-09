using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergePrimitiveArrays.Test
{
    [TestClass]
    public class MergeArrayTests
    {
        [TestMethod]
        public void TestPlainMerge()
        {
            var aArray = new[] { 1, 4, 6, 7, 10 };
            var bArray = new[] { 2, 5, 6, 8, 9 };

            int[] expectedArray = {1, 2, 4, 5, 6, 7, 8, 9, 10};

            var result = MergeArrayUtils.MergeAndReorder(aArray, bArray);

            CollectionAssert.AreEqual(expectedArray, result);
        }
    }
}
