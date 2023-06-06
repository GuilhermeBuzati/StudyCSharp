int[] ages = new int[5];

ages[0] = 30;
ages[1] = 40;
ages[2] = 17;
ages[3] = 18;
ages[4] = 21;

Console.WriteLine($"Length array {ages.Length}");


int totalAge = 0;
for(int i = 0; i < ages.Length; i++)
{
    int age = ages[i];
    Console.WriteLine($"Index [{i}] = {age}");

    totalAge += age;
}

int average = totalAge / ages.Length;

Console.WriteLine($"Average age {average}");