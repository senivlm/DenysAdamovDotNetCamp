
using Assignment3;

//TODO: Add matrix class
int arraySize = 10;
Vector v = new Vector(arraySize);

v.InitRandom(1, 2);
v.CountingSort();

Pair[] pairs = v.CalculateFrequence();

Pair pair1 = pairs[0];
Pair pair2 = pairs[0];

bool areEqual = pair1 == pair2;

areEqual = pair1.Equals(pair2);


var type = pair2.GetType();

bool isPal = v.IsPalindrome;

Console.WriteLine(v);
v.ReverseStandard();
Console.WriteLine(v);
v.ReverseCustom();
Console.WriteLine(v);

try
{
    v[-2] = 10;
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

var longestSeqData = v.GetLongestSequenceData();
Console.WriteLine(longestSeqData);
int a = 1;