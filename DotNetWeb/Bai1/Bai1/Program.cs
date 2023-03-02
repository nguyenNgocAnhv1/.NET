namespace main
{
    class main
    {
        public static void Main(string[] args)
        {
            var x = 5;
            switch (x)
            {
                case 5:
                    Console.WriteLine("hello");
                case 6:
                    Console.WriteLine("6");
                    break;
                default:
                    Console.WriteLine("dèault");
                    break;
            }
        }
    }
}