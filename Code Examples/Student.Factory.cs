namespace app2.Education
{
    public partial class Student
    {
        public class Factory
        {
            public static Student Create()
            {
                return new Student();
            }
        }
    }
}