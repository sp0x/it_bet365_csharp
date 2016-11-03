using System;

namespace app2
{
    public abstract class Entity
    {
        public abstract void BeforeSave();
        public void Save()
        {
            BeforeSave();
        }

        public void DoSomeWriting()
        {
            this.Write();
            
        }
        /// <summary>
        /// Write something with this entity.
        /// 
        /// </summary>
        public virtual void Write()
        {
            Console.WriteLine("Write from entity");
        }
    }

    public class Person : Entity
    {
        protected string mSomeField;
        /// <summary>
        /// Function only visible in children of Person
        /// </summary>
        protected void PersonalStuff()
        {
            Write();
        }

        public override void Write()
        {
            //We're in child Person
            Console.WriteLine("Write from person");
            //base is Entity
            base.Write();

        }

        public void Initialize()
        {
            throw new Exception("This is just a stub!");
            mSomeField = "A";
        }
       

        public static string GetNextFreeName()
        {
            return "James";
        }
        public string Name { get; set; } = GetNextFreeName();
        //C# default constructor is .ctor

        public Person(int age)
        {
            
        }
        public Person(string name)
        {
            this.Name = name;
        }

        public override void BeforeSave()
        {
            Console.WriteLine("Cleanup!");
        }
    }

    public class Employee : Person
    {
        public void Initialize()
        {
            base.Initialize();
            this.mSomeField = "B";
        }
        public Employee() : base(0)
        {
            PersonalStuff();
        }
        public Employee(string name) : base(name)
        {
            
        }
    }
}