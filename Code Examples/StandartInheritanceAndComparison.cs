using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app2
{
    public class AdvancedComparer : Comparer<FancyObject>
    {
        public override int Compare(FancyObject x, FancyObject y)
        {
            return x.Prop.ToString().CompareTo(y.Prop.ToString());
        }
    }
    public class FancyObject : Comparer<FancyObject>
    {
        public override int Compare(FancyObject x, FancyObject y)
        {
            return x.Prop.CompareTo(y.Prop);
        }

        public static void TestFancyObjectSorting()
        {
            var objs = new List<FancyObject>();
            objs.Add(new FancyObject() {Prop = 1});
            objs.Add(new FancyObject() {Prop = 2});
            objs.Add(new FancyObject() {Prop = 3});
            var check = new FancyObject();
            check.Prop = 10;
            //Check if a FancyObject with Prop equal to 10
            //exists
            //In order for this to work, OVERRIDE Equals!
            objs.Contains(check);

            var comparer = new AdvancedComparer();
            //Sort with a lambda
            //objs.Sort(( x, y) => x.Prop.CompareTo(y.Prop ));
            //Sort with a comparer
            //objs.Sort(comparer);

        }


        public int Prop { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is FancyObject)
            {
                return ((FancyObject)obj).Prop == this.Prop;
            }
            else return false;
        }
    } 


    class StandartInheritanceAndComparison
    {
    }
}
