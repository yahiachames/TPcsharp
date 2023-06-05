namespace DepCap
{
    internal class Program
    {
        static void Main(string[] args)
        {
           checked {
                int maxValue = int.MaxValue;
                Console.WriteLine("max value init {0}", maxValue);
                try{
                    maxValue++;
                    Console.WriteLine("maxvalue after ++ {0}", maxValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}