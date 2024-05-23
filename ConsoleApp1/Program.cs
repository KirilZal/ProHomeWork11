using System.Text;

namespace ConsoleApp1
{
  class Program
    {
        private static readonly object LockObject=new object();

        static void ReadWrite(string inputFile,string outputFile)
        {
            Console.OutputEncoding=Encoding.Unicode;
            StreamWriter writer = null;
            try
            {
                if (File.Exists(inputFile))
                {

                    string content = File.ReadAllText(inputFile);
                    lock (LockObject)
                    {
                        writer = new StreamWriter(outputFile, true);
                        writer.Write(content);
                        Console.WriteLine("дані записанні");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ne poluchilos");

            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
                 
        }
        static void Main(string[] args)
        {
            string directoryPath = @"C:\HEJ";
            string file1Path = Path.Combine(directoryPath, "ping.txt");
            string file2Path = Path.Combine(directoryPath, "tic.txt");
            string outPath = Path.Combine(directoryPath, "file1.txt");
            Thread thread = new Thread(() =>ReadWrite(file1Path,outPath));
            Thread thread1= new Thread(() =>ReadWrite(file2Path,outPath));
            thread.Start();
            thread1.Start();
            thread.Join();
            thread1.Join();
            Console.WriteLine("Дані успішно записані в файл output.txt");

        }
    }
}
