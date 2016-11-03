using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using app2.Education; //Show me all the classes in Education
using static app2.Education.Student; 
//Show me all the static methods in Education.Student

namespace app2
{
    
    class Program
    {
        
        public delegate bool ProcessCheck(out bool finalValue);
        static void onClassFinished()
        {
            Study();

            MemoryStream mx = new MemoryStream(new byte[]
            {
                1,2,3,4,5,6,7,8,9,10
            });
            using (mx)
            {
                byte[] buffer = new byte[10];
                mx.Read(buffer, 0, 10);
            }
        }

        static void onClassHasDoneWork()
        {
            //thread 1
            Console.WriteLine("Class is working!");
        }


        public static void ExampleWithComparisons()
        {
            FancyObject.TestFancyObjectSorting();
        }

        static void Main(string[] args)
        {
            ExampleWithComparisons();

            try
            {
                var pEntity = new Person("James");
                pEntity.DoSomeWriting();
            }
            catch (Exception ex)
            {
                ex = ex;
            }

            onClassFinished();
            
            var userInput = Console.ReadLine();
            ProcessCheck userPickedFunction = null;

            if (userInput == "op1")
            {
                userPickedFunction = op1;
            }
            
            else if (userInput == "op2")
            {
                userPickedFunction = op2;
            }
            bool finalResult;
            if (userPickedFunction(out finalResult))
            {
                
            }
            

            var newObject = new System.Diagnostics.Process();
            var anotherObject = new Program();
            
            string pString = newObject.ToString();

        }

        class TestFinalize2 : TestFinalize
        {
            ~TestFinalize2()
            {
                
            }
        }
        class TestFinalize : IDisposable
        {
            ~TestFinalize()
            {
                var s = new MemoryStream();
            }

            public void Dispose()
            {
                
            }
        }
        public class Book
        {
            decimal price;
            string title;
            bool isAvailable;
            public static object bookSource = new object();

            public Book(string x)
            {
                
            }
            

            public bool IsAvailable => initialAvailability()==1;
  
            public const int AverageRating =3 ;

            public int initialAvailability()
            {
                var x = AverageRating;

                return 2;
            }

            private Book()
            {
                
            }
            protected internal Book(decimal p, string t)
            {
                price = p;
                title = t;
            }
            public void Print()
            {
                Console.WriteLine("{0} {1}",price, title);
            }
        }


        private static void dostuff(int a, int b)
        {
            
        }

        private static void dostuff(int a, string b)
        {
            
        }
        static int Method(int a = 5, bool x = true)
        {
            if (x) return a += 1;
            return a;
        } 
        static int Method()
        {
            return 5;
        }


        private static bool op2(out bool finalvalue)
        {
            
            throw new NotImplementedException();
        }

        private static bool op1(out bool finalvalue)
        { 
            finalvalue = true;
            return false;
        }
    }
}
