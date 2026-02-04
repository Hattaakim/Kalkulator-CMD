using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
namespace Kalkulator_CMD
{
    internal class Program
    {
        [DllImport("user32.dll")]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        private static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        private static extern bool EmptyClipboard();

        [DllImport("user32.dll")]
        private static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);
        const uint CF_UNICODETEXT = 13;

        [STAThread] //clipboard only run in single threaded apateu
        // console app is multi threaded apateu
        static void Main(string[] args)
        {
            HalamanUtama();
        }

        private static void CopyToClipboard(string text)
        {
            IntPtr ptr = Marshal.StringToHGlobalUni(text);

            OpenClipboard(IntPtr.Zero);
            EmptyClipboard();
            SetClipboardData(CF_UNICODETEXT, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }

        private static void HalamanUtama()
        {
            int pilihan_user = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Halo, selamat datang di kalkulator CMD
Silahkan masukkan pilihan operasi perhitungan anda!
[1] Penghitungan Dasar (Tambah, Kali, Kurang, Bagi)
[2] Penghitungan Lainnya (Sudut Sin Cos Tan)
[0] Keluar aplikasi");
                Console.Write("Pilihan Kamu: ");
                string pilihan = Console.ReadLine();
                if (int.TryParse(pilihan, out int choose))
                {
                    if ((choose == 1) || (choose == 2) || (choose == 0))
                    {
                        pilihan_user = choose;
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Pilihan tidak valid");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Masukan harus berupa angka!");
                    Thread.Sleep(1000);
                }
            }
            if (pilihan_user == 1)
            {
                PenghitunganDasar();
            }
            else if (pilihan_user == 2)
            {
                PenghitunganLainnya();
            }
            else
            {
                Exit_App();
            }
        }

        private static void Exit_App()
        {
            Console.Clear();
            Console.WriteLine(@"Terima kasih telah memakai aplikasi ini!

Izinkan proses sistem untuk membersihkan sampah...
Aplikasi menutup secara otomatis dalam beberapa saat...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return;
        }

        private static void PenghitunganDasar()
        {
            Console.Clear();
            Console.WriteLine(@"Silahkan pilih metode penghitungan anda!
[1] Tambah
[2] Kali
[3] Kurang
[4] Bagi");
            Console.Write("Pilihan: ");

            string pilihan = Console.ReadLine();
            int pilihanuser;
            double angka_1;
            double angka_2;

            while (true)
            {
                if (int.TryParse(pilihan, out int choose))
                {
                    pilihanuser = choose;
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Masukkan angka pertama: ");
                        string angka_1_str = Console.ReadLine();
                        if (double.TryParse(angka_1_str, out double x))
                        {
                            angka_1 = x;
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("Harap masukkan angka!");
                        Thread.Sleep(1000);
                    }

                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Masukkan angka kedua: ");
                        string angka_2_str = Console.ReadLine();
                        if (double.TryParse(angka_2_str, out double y))
                        {
                            angka_2 = y;
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("Harap masukkan angka!");
                        Thread.Sleep(1000);
                    }
                    break;
                }
            }
            try
            {
                double hasil = Kalkulator.Penghitungan_Dasar(angka_1, angka_2, pilihanuser);
                int pilihanakhir = 0;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($@"Hasil penghitungannya adalah: {hasil}
=============================================================================
Apa yang ingin anda lakukan?
[1] Copy hasil ke clipboard
[2] Kembali ke halaman utama");
                    Console.Write("Pilihan: ");
                    string pilihan_akhir = Console.ReadLine();
                    if (int.TryParse(pilihan_akhir, out int pa))
                    {
                        pilihanakhir = pa;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Pilihan tidak ada!");
                        Thread.Sleep(1000);
                    }
                }
                if (pilihanakhir == 1)
                {
                    Console.Clear();
                    CopyToClipboard($"{hasil}");
                    Console.WriteLine(@"Hasil penghitungan dicopy ke clipboard
Kembali ke halaman utama...");
                    Thread.Sleep(1000);
                    HalamanUtama();
                }
                else
                {
                    HalamanUtama();
                }

            }

            catch (DivideByZeroException)
            {
                Console.WriteLine(@"Terjadi kesalahan: membagi angka dengan 0
Aplikasi akan memulai ulang...");
                Thread.Sleep(1000);
                HalamanUtama();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine(@"Terjadi kesalahan: fungsi belum dideklarasikan
Aplikasi akan memulai ulang...");
                Thread.Sleep(1000);
                HalamanUtama();
            }

        }

        private static void PenghitunganLainnya()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Silahkan tentukan pilihan opsi penghitungan!
[1] Cari nilai dari sudut tertentu
[2] Cari sudut dari nilai tertentu");
                Console.Write("Pilihan: ");

                string pilihan = Console.ReadLine();
                if (int.TryParse(pilihan, out int pa))
                {
                    if (pa == 1)
                    {
                        Cari_Nilai_Dari_Sudut();
                        break;
                    }
                    else if (pa == 2)
                    {
                        Cari_Sudut_Dari_Nilai();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Pilihan tidak tersedia!");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Pilihan harus berupa angka!");
                    Thread.Sleep(1000);
                }
            }
        }

        private static void Cari_Sudut_Dari_Nilai()
        {
            throw new NotImplementedException();
        }

        private static void Cari_Nilai_Dari_Sudut()
        {
            double sudut = 0;
            double hasil_hitung = 0.00;
            bool is_infinity = false;
            int pilihan = 0;
            string display_jawaban = "";
            List<string> pilihan_hitung = new List<string>()
            {
                "Sin",
                "Cos",
                "Tan",
                "Cosec",
                "Secan",
                "Cotangen"
            };
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Silahkan pilih tipe sudut yang akan dicari nilainya!
[1] Sin
[2] Cos
[3] Tan
[4] Cosec (csc)
[5] Secan (sec)
[6] Cotangen (cot)");
                Console.Write("Pilihan anda: ");
                string pilihan_ = Console.ReadLine();
                if (int.TryParse(pilihan_, out int hasil))
                {
                    if (hasil <= 6 && hasil > 0)
                    {
                        pilihan = hasil;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Pilihan tidak tersedia!");
                        Thread.Sleep(1000);
                    }
                }

            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Silahkan masukkan sudut yang akan dicari nilainya!");
                Console.Write("Angka Sudut (bukan radian): ");
                string sudut_input = Console.ReadLine();
                if (double.TryParse(sudut_input, out double sudut_))
                {
                    sudut = sudut_;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Input yang anda masukkan bukanlah angka");
                    Thread.Sleep(1000);
                }
            }
            try
            {
                Console.Clear();
                hasil_hitung = Kalkulator.Nilai_Dari_Sudut(sudut, pilihan);
                Console.WriteLine($"Hasil dari {pilihan_hitung[pilihan - 1]}{sudut}° = {hasil_hitung}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Fungsi tidak didefinisikan!");
                Thread.Sleep(1000);
                Cari_Nilai_Dari_Sudut();
            }
            catch (Exception)
            {
                is_infinity = true;
                Console.WriteLine($"Hasil dari {pilihan_hitung[pilihan - 1]}{sudut}° = Tak Terhingga");
            }
            if(is_infinity == false)
            {
                display_jawaban = $"{pilihan_hitung[pilihan - 1]} ({sudut}°) = {hasil_hitung}";
            }
            else
            {
                display_jawaban = $"{pilihan_hitung[pilihan - 1]} ({sudut}°) = Tak Terhingga";
            }
                while (true)
                {
                    Console.Clear();
                    if (is_infinity == false)
                    {
                        Console.WriteLine($"Hasil dari {display_jawaban}");
                    }
                    else
                    {
                        Console.WriteLine($"Hasil dari {display_jawaban}");
                    }
                    Console.WriteLine(@"=========================================
Operasi penghitungan matematika telah selesai. Apa yang ingin anda lakukan?
[1] Copy penghitungan ke clipboard
[2] Kembali ke halaman utama");
                    Console.Write("Pilihan: ");
                    string opsi_akhir = Console.ReadLine();
                    if (int.TryParse(opsi_akhir, out int result))
                    {
                        if (result <= 2 && result > 0)
                        {
                            if (result == 1)
                            {
                                Console.Clear();
                                CopyToClipboard(display_jawaban);
                                Console.WriteLine("Jawaban telah disalin ke clipboard!");
                                Thread.Sleep(1000);
                       
                            }
                            else if (result == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Kembali ke halaman utama...");
                                Thread.Sleep(1000);
                                HalamanUtama();
                                break;
                            }
                        }
                    }
                }
        }
    }
}
