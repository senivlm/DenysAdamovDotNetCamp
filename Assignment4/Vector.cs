
namespace Assignment4
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


