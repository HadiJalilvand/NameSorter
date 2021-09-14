using NameSorter.Utility;
using System;



namespace NameSorter
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Type path file: ");
            path = Console.ReadLine();

            // Sort and write to file
            try
            {
                if (System.IO.File.Exists(path))
                {
                    FileParser fileParser = new FileParser(path);
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
      
        
    }
}
