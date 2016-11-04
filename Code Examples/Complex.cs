// complex.cs
using System;

namespace app2
{

    public class Complex
    {
        private int mReal;
        private int mImaginary;
        public int Real => mReal;
        public int Imaginary => mImaginary;
        

        public Complex(int mReal, int mImaginary)
        {
            this.mReal = mReal;
            this.mImaginary = mImaginary;
        }
        /// <summary>
        /// Override the + operator to add 2 complex numbers
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.mReal + c2.mReal, c1.mImaginary + c2.mImaginary);
        }
        /// <summary>
        /// Override the - operator, to subtract 2 complex numbers
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.mReal - c2.mReal, c1.mImaginary - c2.mImaginary);
        }
        
        /// <summary>
        /// Use the default equals
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Equals(c2);
        }

        /// <summary>
        /// By overloading > you should also overlad <
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator >(Complex c1, Complex c2)
        {
            return false;
        }
        public static bool operator <(Complex c1, Complex c2)
        {
            return false;
        }
         

        /// <summary>
        /// By overloading == you should also override the != operator
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Complex c1, Complex c2)
        {
            return !c1.Equals(c2);
        }
        /// <summary>
        /// Overrides the true value of complex, in case of if(complexNumber){}
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator true(Complex t) { return t.mReal != 0 && t.mImaginary!=0; }
        /// <summary>
        /// Overrides the false value of complex, in case of if(!complexNumber) {}
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator false(Complex t) { return t.mReal == 0 && t.mImaginary == 0; }

        /// <summary>
        /// Return a string with the complex number
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"{mReal} + {mImaginary}i");
        }



    }
}