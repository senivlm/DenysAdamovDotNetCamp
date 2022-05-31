using Assignment4;
// не перехоплені винятки
int arrayLength = 10;

Vector v = new Vector(arrayLength);

v.InitShuffle();
Console.WriteLine(v);
try
{
    v.QuickSort();
    Console.WriteLine(v);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
