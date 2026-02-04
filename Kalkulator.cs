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

        //Math.Sin/Cos/Tan cuma terima radian, bukan sudut
        public static double Nilai_Dari_Sudut(double a, int opsi)
        {
            double radian_ = ConvertToRadian(a);
            if (opsi == 1) //sin
            {
                return Math.Sin(radian_);
            }
            else if (opsi == 2)
            {
                if (a != 90)
                {
                    return Math.Cos(radian_);
                }
                else
                {
                    return 0;
                }
            }
            else if (opsi == 3)
            {
                if (a != 90)
                {
                    return Math.Tan(radian_);
                }
                else
                {
                    throw new Exception();
                }
            }
            else if (opsi == 4) //cosec
            {
                return 1 / Math.Sin(radian_);
            }
            else if (opsi == 5)
            {
                if (a != 90)
                {
                    return 1 / Math.Cos(radian_);
                }
                else
                {
                    throw new Exception();
                }
            }
            else if (opsi == 6)
            {
                if (a != 90)
                {
                    return 1 / Math.Tan(radian_);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static double ConvertToRadian(double angleDegrees)
        {
            return angleDegrees * (Math.PI / 180);
        }

        private static double ConvertToDegree(double radian)
        {
            return radian * (180 / Math.PI);
        }
    }
}
