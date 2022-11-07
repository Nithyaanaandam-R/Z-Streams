using System;
using System.IO;

namespace ConsoleApp4
{
    public class Demo
    {
        string fileLocation = "E:\\Content\\newBinaryFile.dat";
        public void WritingFile()
        {
            try
            {
                //checking if file exists
                if (File.Exists(fileLocation))
                {
                    File.Delete(fileLocation);
                }
                FileStream fileStream = new FileStream(fileLocation, FileMode.Create,
                FileAccess.Write, FileShare.ReadWrite);
                //creating binary file using BinaryWriter
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    //writing data using different Write() methods
                    //of BinaryWriter
                    binaryWriter.Write(5253);
                    binaryWriter.Write("This is a string value.");
                    binaryWriter.Write('A');
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void ReadingFile()
        {
            try
            {
                FileStream fileStream = new FileStream(fileLocation, FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite);
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    Console.WriteLine("IntegerValue = " + binaryReader.ReadInt32());
                    Console.WriteLine("StringValue = " + binaryReader.ReadString());
                    Console.WriteLine("CharValue = " + binaryReader.Read()); //returns the encoded value if not used ReadChar()
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

namespace ConsoleApp4
{
    public class BinaryWriterDemo
    {
        public static void BinaryDemo()
        {
            Demo demoObj = new Demo();
            demoObj.WritingFile();
            demoObj.ReadingFile();
            Console.ReadLine();
        }
    }
}