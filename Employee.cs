using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp4
{
    [Serializable]
    public class Employee
    {
        public string Name;

        public string Phone;

        public string DoB;

        public string Department;

        public int Salary;

        public static void Serializer()
        {
            
            Employee emp = new Employee
            {
                
                Name = "Aaron",
                Phone = "90012365",
                DoB = "24.09.1982",
                Department = "DevOps",
                Salary = 32000,
            
            };

            BinaryFormatter bf = new BinaryFormatter();     //serializing data to binary

            FileStream fsout = new FileStream("employee.binary", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            
            using (fsout)  
            {  
                bf.Serialize(fsout, emp);  
                Console.WriteLine("Object Serialized");  
            }
            
        }

        public static void Deserializer()
        {
            Employee emp = new Employee();
            BinaryFormatter bf = new BinaryFormatter();     //desrialixing from binary 

            FileStream fsin = new FileStream("employee.binary", FileMode.Open, FileAccess.Read, FileShare.None);

            using (fsin)
            {
                emp = (Employee)bf.Deserialize(fsin);
                Console.WriteLine("Object Deserialised");
                emp.Display();
            }

        }

        public void Display()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Phone : {this.Phone}");
            Console.WriteLine($"DoB : {this.DoB}");
            Console.WriteLine($"Department : {this.Department}");
            Console.WriteLine($"Salary: {this.Salary}");
        }

    }

    
}