
DuplicatesTask.PrintDuplicates();

public static class DuplicatesTask
{
    public static void PrintDuplicates()
    {
        const int size = 1000000;
        var random = new Random();
        var numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next(0, 1000000);
        }

        var seen = new HashSet<int>();
        var duplicates = new HashSet<int>();

        foreach (var number in numbers)
        {
            if (!seen.Add(number))
            {
                duplicates.Add(number);
            }
        }

        Console.WriteLine($"Total numbers generated: {size}");
        Console.WriteLine($"Total duplicates found: {duplicates.Count}");
        Console.WriteLine("All duplicates: ");


        Console.Write("Do you want to print all duplicates? (y/n): ");
        var input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
            Console.WriteLine("All duplicates:");
            foreach (var dup in duplicates)
            {
                Console.WriteLine(dup);
            }
        }
        else
        {
            Console.WriteLine("20 duplicates:");
            foreach (var dup in duplicates.Take(20))
            {
                Console.WriteLine(dup);
            }
        }

    }
}

