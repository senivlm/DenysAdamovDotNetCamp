using System.IO;

namespace Assignment5
{
    internal class Vector
    {
        private int[] array;
        public Vector(int[] arr)
        {
            array = arr;
        }
        public Vector(int n) : this(new int[n])
        { }
        public Vector() : this(new int[0])
        { }
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
            set => array[index] = value;
        }
        public bool IsPalindrome
        {
            get
            {
                bool isPalindrome = true;
                for (int i = 0; i < array.Length / 2; i++)
                {
                    if (array[i] != array[array.Length - 1 - i])
                    {
                        isPalindrome = false;
                        break;
                    }
                }
                return isPalindrome;
            }
        }
        /// <summary>
        /// Initializes array with random numbers from specified range inclusively
        /// </summary>
        public void InitRandom(int start, int end)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(start, end + 1);
            }
        }
        /// <summary>
        /// Initializes array with unique numbers from 1 to array.Length in random order
        /// </summary>
        public void InitShuffle()
        {
            int r;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                r = random.Next(1, array.Length + 1);
                while (IsNumberPresent(r, i))
                {
                    r = random.Next(1, array.Length + 1);
                }
                array[i] = r;
            }
        }
        public Pair[] CalculateFrequence()
        {
            Pair[] pairs = new Pair[array.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }
            int uniqueNumbers = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isNumberPresentInPairs = false;
                for (int j = 0; j < uniqueNumbers; j++)
                {
                    if (pairs[j].Number == array[i])
                    {
                        isNumberPresentInPairs = true;
                        pairs[j].Frequence++;
                        break;
                    }
                }
                if (!isNumberPresentInPairs)
                {
                    pairs[uniqueNumbers].Number = array[i];
                    pairs[uniqueNumbers].Frequence = 1;
                    uniqueNumbers++;
                }
            }
            Pair[] pairsShortened = new Pair[uniqueNumbers];
            for (int i = 0; i < uniqueNumbers; i++)
            {
                pairsShortened[i] = pairs[i];
            }
            return pairsShortened;
        }
        public void ReverseStandard()
        {
            Array.Reverse(array); 
        }
        public void ReverseCustom()
        {
            int[] reversedArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reversedArray[i] = array[array.Length - 1 - i];
            }
            array = reversedArray;
        }
        public (int number, int length, int startIndex) GetLongestSequenceData()
        {
            int number = 0;
            int length = 0;
            int startIndex = 0;

            int currentNumber = 0;
            int currentLength = 0;
            int currentStartIndex = 0;
            if (array.Length > 0)
            {
                currentNumber = array[0];
                currentLength = 1;
                currentStartIndex = 0;
            }
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == currentNumber)
                {
                    currentLength++;
                }
                if (array[i] != currentNumber || i == array.Length - 1)
                {
                    if (currentLength > length)
                    {
                        number = currentNumber;
                        length = currentLength;
                        startIndex = currentStartIndex;
                    }
                    if (array[i] != currentNumber)
                    {
                        currentNumber = array[i];
                        currentLength = 1;
                        currentStartIndex = i;
                    }
                }
            }
            return (number, length, startIndex);
        }
        public void BubbleSort()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] < array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp; 
                        isSorted = false;
                    }
                    if (isSorted)
                    {
                        break;
                    }
                }
            }
        }
        public void CountingSort()
        {
            if (array.Length > 0)
            {
                int max = array[0];
                int min = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }

                int[] temp = new int[max-min+1];

                for (int i = 0; i < array.Length; i++)
                {
                    temp[array[i] - min]++;
                }
                int k = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    for (int j = 0; j  < temp[i]; j++)
                    {
                        array[k] = i + min;
                        k++;
                    }
                }
            }
        }
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void QuickSort()
        {
            QuickSort(0, array.Length - 1);
        }
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void QuickSort(int start, int end)
        {
            if (start < end)
            {
                if (start >= 0 && start < array.Length
                    && end >= 0 && end < array.Length)
                {
                    int pivotIndex = Partition(start, end);
                    QuickSort(start, pivotIndex - 1);
                    QuickSort(pivotIndex + 1, end);
                }
                else if (!(start >= 0 && start < array.Length))
                {
                    throw new ArgumentOutOfRangeException(nameof(start), "Start position is out of array bounds");
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(end), "End position is out of array bounds");
                }
            }
        }
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void QuickSort(int start, int end, int pivotIndex)
        {
            int temp = array[end];
            array[end] = array[pivotIndex];
            array[pivotIndex] = temp;
            QuickSort(start, end);
        }
        private int Partition(int start, int end)
        {
            int pivot = array[end]; 
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            int temp2 = array[end];
            array[end] = array[i+1];
            array[i+1] = temp2;
            return i + 1;
        }
        public void MergeSort()
        {
            MergeSort(ref this.array, 0, array.Length - 1);
        }
        public void MergeSort(ref int[] array, int start, int end)
        {
            if (start < end)
            {
                int middle = start + (end - start) / 2;
                MergeSort(ref array, start, middle);       //check for inclusiveness
                MergeSort(ref array, middle + 1, end);
                Merge(ref array, start, end);
            }
        }
        private void Merge(ref int[] array, int start, int end)
        {
            int middle = start + (end - start) / 2;
            int[] leftArray = new int[(end - start) / 2 + 1];
            int[] rightArray = new int[(end - start + 1) - leftArray.Length];

            for (int i = 0; i < rightArray.Length; i++) 
            {
                leftArray[i] = array[i + start];
                rightArray[i] = array[i + middle + 1];
            }
            if (leftArray.Length > rightArray.Length)
            {
                leftArray[^1] = array[leftArray.Length - 1 + start];
            }

            for (int k = 0, i = 0, j = 0; k < end - start + 1; k++)
            {
                if (leftArray[i] < rightArray[j])
                {
                    array[k + start] = leftArray[i];
                    i++;
                    if (i == leftArray.Length)
                    {
                        for (k += 1; j < rightArray.Length; k++, j++)
                        {
                            array[k + start] = rightArray[j];
                        }
                        break;
                    }
                }
                else
                {
                    array[k + start] = rightArray[j];
                    j++;
                    if (j == rightArray.Length)
                    {
                        for (k+=1; i < leftArray.Length; k++, i++) 
                        {
                            array[k + start] = leftArray[i];
                        }
                        break;
                    }
                }
            }
        }
        public void MergeSortHalfLength(ref int[] outputData)
        {
            MergeSortHalfLength(this.array, ref outputData);
        }

        /// <summary>
        /// Sorts input data using half-size arrays. Works only for size 16
        /// </summary>
        /// <param name="inputData">
        /// Simulation of input file
        /// </param>
        /// <param name="outputData">
        /// Simulation of output file
        /// </param>
        public void MergeSortHalfLength(int[] inputData, ref int[] outputData)
        {// одночасно завантажувати 2 масиви не можна. Не вистачає оперативки. Треба окремо посортувати. Я на занятті покажу. 
            int[] dataLeftHalf = new int[inputData.Length / 2];
            int[] dataRightHalf = new int[inputData.Length - dataLeftHalf.Length];

            for (int i = 0; i < dataRightHalf.Length; i++)
            {
                dataLeftHalf[i] = inputData[i];
                dataRightHalf[i] = inputData[i + dataLeftHalf.Length];
            }
            if (dataLeftHalf.Length > dataRightHalf.Length)
            {
                dataLeftHalf[^1] = inputData[dataLeftHalf.Length - 1];
            }

            MergeSort(ref dataLeftHalf, 0, dataLeftHalf.Length - 1);
            MergeSort(ref dataRightHalf, 0, dataRightHalf.Length - 1);
            int?[] intermediateArray = new int?[outputData.Length / 2];
            for (int i = 0; i < intermediateArray.Length; i++)
            {
                intermediateArray[i] = null;
            }
            MergeSortTwoArrays(ref outputData, ref intermediateArray, dataLeftHalf, dataRightHalf, 0, dataLeftHalf.Length - 1); // what if left is larger?
        }
        private void MergeSortTwoArrays(ref int[] outputArray, ref int?[] intermediateArray, int[] arrayLeft, int[] arrayRight, int start, int end)
        {
            if (start <= end)
            {
                int middle = start + (end - start) / 2;

                int[] sortedPart = new int[outputArray.Length / 2];//new int[end - start + 1];
                // for start = 0, end = length-1, r and l lengths are equal
                for (int i = 0; i < middle + 1 - start; i++) //+1?
                {
                    sortedPart[i] = arrayLeft[i + start]; //sortedPart[i] = arrayLeft[i + start];//////////// what when we take only one?
                    sortedPart[i + middle + 1 - start] = arrayRight[i + start]; // = arrayRight[i + start];
                }
                for (int i = 0; i < (end + 1)/(middle - start + 1); i++)
                {
                    if (intermediateArray[i] != null)
                    {
                        //sortedPart[i + middle + 1] = (int)intermediateArray[i];/////////////
                        //sortedPart[i + middle - start] = (int)intermediateArray[i];///////////// // may decrease num of iter | done?
                        sortedPart[^(i+1)] = (int)intermediateArray[i];
                    }
                }
                MergeSort(ref sortedPart, 0, sortedPart.Length - 1);

                int[] fullySorted = new int[middle - start + 1];//sortedPart.Length / 2]; // what if length is odd?
                for (int i = 0; i < fullySorted.Length; i++)
                {
                    fullySorted[i] = sortedPart[i];
                    //sortedPart[i] = sortedPart[i + middle + 1];////////////////
                }
                //for (int i = 0; i < sortedPart.Length/((end - start + 1)/(middle - start + 1)); i++) // what if length is odd?
                for (int i = 0; i < sortedPart.Length - fullySorted.Length; i++)
                {
                    intermediateArray[i] = sortedPart[i + middle - start + 1];// was without -start // may change to [^]
                    //arrayLeft[^(i + middle + 2)] = sortedPart[i + middle + 1];
                    //arrayRight[^(i + middle + 2)] = sortedPart[i + middle + 2];
                }
                if (start == end)
                {
                    sortedPart[0] = arrayRight[^1];
                    intermediateArray[^1] = arrayRight[^1]; // now ar a marker
                }
                AppendToFile(ref outputArray, fullySorted, start); // ref fullySorted? //how to pass start? // here or outside the scope?
                int newStart = start + (end - start) / 2 + 1; // /4 or smth else?
                if (intermediateArray[^1] == null)
                {
                    MergeSortTwoArrays(ref outputArray, ref intermediateArray, arrayLeft, arrayRight, newStart, end);
                }
                else
                {
                    MergeSort(ref sortedPart, 0, intermediateArray.Length - 1);
                    AppendToFile(ref outputArray, sortedPart, newStart);
                }
            }
        }
        private void AppendToFile(ref int[] outputArray, int[] array, int position)
        {
            for (int i = 0; i < array.Length; i++)
            {
                outputArray[position] = array[i];
                position++;
            }
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < array.Length; i++)
            {
                str += array[i] + " ";
            }
            return str;
        }
        /// <summary>
        /// Inner method for InitShuffle
        /// </summary>
        private bool IsNumberPresent(int number, int lastIndexToIterate)
        {
            bool isPresent = false;
            for (int i = 0; i < lastIndexToIterate; i++)
            {
                if (array[i] == number)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }
    }
}


