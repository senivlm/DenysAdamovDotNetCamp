using Assignment5;

Vector v = new Vector(16);

v.InitShuffle();
Console.WriteLine(v);

//v.MergeSort();

int[] arr = new int[256];

v.MergeSortHalfLength(ref arr);
Vector v2 = new Vector(arr);
Console.WriteLine(v2);