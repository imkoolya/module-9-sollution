class LastNameSorter
{
    public delegate void SortEventHandler(List<string> lastNameList);
    public event SortEventHandler Sorted;

    public void Sort(List<string> lastNameList, int sortType)
    {
        try
        {
            if (sortType == 1)
                lastNameList.Sort();
            else if (sortType == 2)
                lastNameList.Sort((x, y) => y.CompareTo(x));
            else
                throw new InvalidSortTypeException("Неверный тип сортировки!");

            Sorted?.Invoke(lastNameList);
        }
        catch (InvalidSortTypeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
}

class InvalidSortTypeException : Exception
{
    public InvalidSortTypeException(string message) : base(message) { }
}

class Program
{
    static void Main(string[] args)
    {
        List<string> lastNameList = new List<string>
            {
                "Иванов",
                "Петров",
                "Сидоров",
                "Алексеев",
                "Козлов"
            };

        LastNameSorter lastNameSorter = new LastNameSorter();
        lastNameSorter.Sorted += LastNameSorter_Sorted;

        Console.WriteLine("Выберите тип сортировки:");
        Console.WriteLine("1 - Сортировка по алфавиту (А-Я)");
        Console.WriteLine("2 - Сортировка по алфавиту в обратном порядке (Я-А)");

        try
        {
            int sortType = int.Parse(Console.ReadLine());

            lastNameSorter.Sort(lastNameList, sortType);
        }
        catch (FormatException)
        {
            Console.WriteLine("Неверный формат числа!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Введено слишком большое число!");
        }
        finally
        {
            Console.WriteLine("Программа завершена.");
        }
    }

    private static void LastNameSorter_Sorted(List<string> lastNameList)
    {
        Console.WriteLine("Отсортированный список фамилий:");
        foreach (string lastName in lastNameList)
        {
            Console.WriteLine(lastName);
        }
    }
}