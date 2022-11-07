using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ConsoleApp4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string FilePath = @"E:\MyFile.txt";
            FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);
            fileStream.Close();

            fileStream = new FileStream(FilePath, FileMode.Append);                 //output stream
            byte[] bdata = Encoding.Default.GetBytes("C# Is an Object Oriented Programming Language \n");
            fileStream.Write(bdata, 0, bdata.Length);
            fileStream.Close();



            //StreamWriter and StreamReader

            fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);      //input stream

            string data;
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                data = streamReader.ReadToEnd();
            }
            Console.WriteLine(data);
            Console.ReadLine();



            StreamWriter sw = new StreamWriter(FilePath, true);

            Console.WriteLine("Enter the Text that you want to write on File");
            string str = Console.ReadLine();


            sw.WriteLine(str);          // To write the data into the stream

            sw.Flush();             // Clears all the buffers

            sw.Close();             // To close the stream        

            int a, b, result;
            a = 15;
            b = 20;
            result = a + b;

            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine("Sum of {0} + {1} = {2}", a, b, result);
            }

            //Binary Files;
            Console.Clear();
            Console.WriteLine("Writing to and operating on a binary file \n ");
            BinaryWriterDemo.BinaryDemo();

            //Serializing and Deserializing
            Console.Clear();
            Console.WriteLine("Serializing - convert object into a form that can be written into a stream.");
            Console.WriteLine("Deserializing - get back the serialized object and store it in memory. \n "); 
            Employee.Serializer();
            Employee.Deserializer();
        }
    }
}