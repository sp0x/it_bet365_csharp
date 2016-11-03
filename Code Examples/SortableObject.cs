using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app2
{
    ublic class SortableObject : IEqualityComparer<SortableObject>
    {
        private int ComparedField;
        public string name;

        public SortableObject(int val)
        {
            ComparedField = val;
        }

        /// <summary>
        /// In case of SortableObject implementing IEquatable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SortableObject other)
        {
            return ComparedField == other.ComparedField;
        }


        /// <summary>
        /// In case of implementing equality comparer (IEqualityComparer<SortableObject>)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(SortableObject x, SortableObject y)
        {
            return x.ComparedField == y.ComparedField; ;
        }

        /// <summary>
        /// In case of implementing equality comparer (IEqualityComparer<SortableObject>)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(SortableObject obj) //
        {
            return ComparedField.GetHashCode();
        }

        /// <summary>
        ///  In case of IEquatable or in general to check if SortableObject exists in a list
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other) //
        {
            if (!(other is SortableObject)) return false;
            return ComparedField == (other as SortableObject)?.ComparedField;
        }


    }
}
