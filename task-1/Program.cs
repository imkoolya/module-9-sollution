public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {

    }
}
class Program
{
    static void Main(string[] args)
    {
        var exceptions = new Exception[]
        {
            new DivideByZeroException(),
            new ArgumentNullException(),
            new IndexOutOfRangeException(),
            new CustomException("Собственное исключение"),
            new InvalidOperationException()
        };
        foreach (var exception in exceptions)
        {
            try
            {
                throw exception;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Обнаружено деление на ноль!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Передано значение null!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Индекс вне диапазона!");
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Собственное исключение: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен!");
            }
        }
    }
}