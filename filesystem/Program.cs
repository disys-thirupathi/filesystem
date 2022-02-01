using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows;
namespace filesystem{
    public class files{
        public string path = @"mydetail.txt";       
    public void fileinputs(){
            try{
                if (File.Exists(path)){
                    File.Delete(path);
                }
                ArrayList arr1 = new ArrayList();
                ArrayList list = new ArrayList();
                Console.WriteLine("Enter no of students");
                int num = Convert.ToInt32(Console.ReadLine());
                String name, age, address, email, phone;
                for (int i = 0; i < num; i++){
                    Console.WriteLine("Student #" + i + 1);
                    Console.WriteLine("Enter your name ");
                    name = "Name:\t\t" + Console.ReadLine();
                    Console.WriteLine("Enter your age ");
                    age = "\nAge: \t\t" + Console.ReadLine();
                    Console.WriteLine("Enter your address ");
                    address = "\nAddress: \t" + Console.ReadLine();
                    Console.WriteLine("Enter your email ");
                    email = "\nEmail id: \t" + Console.ReadLine();
                    Console.WriteLine("Enter your phone number ");
                    phone = "\nPhone Number:\t" + Console.ReadLine();
                    arr1.Add(name);
                    arr1.Add(age);
                    arr1.Add(address);
                    arr1.Add(email);
                    arr1.Add(phone);
                    list.Add(arr1);
                }
                using (StreamWriter writer = new StreamWriter(path, true)){
                    foreach (Object obj in arr1){
                        writer.WriteLine(obj.ToString());
                    }
                }
            }
            catch (FileNotFoundException){
                Console.WriteLine("File Not Found Error happend");
            }
            catch (IOException){
                Console.WriteLine("Enter correct inputs");
            }
            finally{
                Console.WriteLine("Executed successfully!");
            }
        }
    }
    public class readfiles : files{
        public void reading(){
            Console.WriteLine("Reading the files");
            FileInfo fin = new FileInfo(path);
            string fullfile = fin.FullName;
            try{
                StreamReader sr = new StreamReader(path);   
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
            }
            catch (FileNotFoundException){
                Console.WriteLine("File not found");
            }
            catch (FileLoadException){
                Console.WriteLine("File is unable to loaded from hard disk");
            }
            finally{
                Console.WriteLine("Read mode executed successfully");
                Console.WriteLine("\n--------------------------------");
            }
        }
    }
    public class deleterecord : readfiles{
        public void deleterec(){
            Console.WriteLine("\nDeleting records in the file");
            try{
                Console.WriteLine("Enter the student index to delete in the record from the file");
                int line_delete = Convert.ToInt32(Console.ReadLine());
  
                List<string> lines = System.IO.File.ReadLines(path).ToList();
                for (int i = 0; i < lines.Count; i++){
                    if (i == line_delete){
                        lines.RemoveAt(i);
                    }
                }
                if (File.Exists(path)){
                    File.Delete(path);
                }
                using (StreamWriter writer = new StreamWriter("mydetail.txt", true)){
                    foreach (Object obj in lines){
                        writer.WriteLine(obj.ToString());
                    }
                }
            }
            catch (FileNotFoundException){
                Console.WriteLine("File not found");
            }
            catch (FileLoadException) {
                Console.WriteLine("File is unable to loaded from hard disk");
            }
            catch (ArgumentOutOfRangeException){
                Console.WriteLine("Array element not found with the index number");
            }
            finally{
                Console.WriteLine("Deleting record executed successfully");
                Console.WriteLine("\n--------------------------------");
            }
        }
    }
    internal class Program{
        static void Main(string[] args){
            files f = new files();
            readfiles f1 = new readfiles();
            deleterecord f2 = new deleterecord();
            f.fileinputs();
            Console.WriteLine("Your information has been recorded");
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("\nReading files");
            f1.reading();
            f2.deleterec();
            Console.ReadLine();
        }
    }   
}                          
