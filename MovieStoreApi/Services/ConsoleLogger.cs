namespace MovieStoreApi.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine(" [Console Log : ] " + message);
        }
    }
}
