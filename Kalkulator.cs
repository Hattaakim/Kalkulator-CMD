using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kalkulator_CMD
{
    class Kalkulator
    {
        public static double Penghitungan_Dasar(double a, double b, int opsi)
        {
            if (opsi == 1) //tambah
            {
                return a + b;
            }
            else if(opsi == 2) //kali
            {
                return a * b;
            }
            else if(opsi == 3)
            {
                return a - b;
            }
            else if(opsi == 4) //bagi
            {
                if (b == 0) throw new DivideByZeroException();
                else
                {
                    return a / b;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static double Penghitungan_Lainnya(double a, int opsi)
        {
            if (opsi == 1) //sin
            {
                return Math.Sin(a);
            }
            else if(opsi == 2) //cos
            {
                return Math.Cos(a);
            }
            else if(opsi == 3) //tan
            {
                if (a != 90)
                {
                    return Math.Tan(a);
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
