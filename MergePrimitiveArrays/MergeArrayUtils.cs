namespace MergePrimitiveArrays
{
    public class MergeArrayUtils
    {
        public static int[] MergeAndReorder(int[] a, int[] b)
        {
            var mergedArray = new int[a.Length + b.Length];
            var mergeArrayCounter = 0;
            var duplicateCounter = 0;

            var aCounter = a.Length - 1;
            var bCounter = b.Length - 1;

            var valueToSet = 0;

            do
            {
                if (aCounter > -1 && bCounter > -1)
                {
                    valueToSet = a[aCounter] > b[bCounter]
                    ? a[aCounter--]
                    : b[bCounter--];
                }
                else if (aCounter == 1)
                {
                    valueToSet = b[bCounter--];
                }
                else if (bCounter == -1)
                {
                    valueToSet = a[aCounter--];
                }

                if (mergeArrayCounter > 0 && mergedArray[mergeArrayCounter - 1] == valueToSet)
                {
                    duplicateCounter++;
                    continue;
                }
                mergedArray[mergeArrayCounter++] = valueToSet;

            } while (aCounter > -1 || bCounter > -1);

            var newLength = mergedArray.Length - duplicateCounter;
            var truncatedMergedArray = new int[newLength];
            for (var i = 0; i < newLength; i++)
            {
                truncatedMergedArray[i] = mergedArray[i];
            }

            return truncatedMergedArray;
        }

        public static void Main(string[] args)
        {
        }
    }
}
