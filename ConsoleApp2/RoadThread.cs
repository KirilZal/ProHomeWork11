namespace ConsoleApp2
{
    class RoadThread
    {
      public static int turn = 1; 
       private static readonly object obBlock = new object();

       public static void Method (string message, int counter)
        {
            while (true)
            {
                Monitor.Enter (obBlock);
                try
                {
                    if (turn == counter)
                    {
                        Console.WriteLine(message);
                        turn++;
                        break;
                    }

                }
                finally
                {
                    Monitor.Exit (obBlock);
                }
                Thread.Yield();
            }
        }



            
       
    }
}
