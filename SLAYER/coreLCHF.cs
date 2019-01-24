using System;
using System.Security.Cryptography;
using System.Diagnostics;
namespace cryptoServRNG
{
    class coreLCHF
    {
        static byte[] GetRandomBytes(int count)
        {
            var bytes = new byte[count];
            (new Random()).NextBytes(bytes);
            return bytes;
        }

        static string endpoint(RIPEMD160Managed ripmd160, byte[] source)
        {

            byte[] hash = ripmd160.ComputeHash(source);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }
            return hashString;
        }
        static void TIMEmACHINE(int iterations)
        {
            var watch = new Stopwatch();
            RIPEMD160Managed rip160;
            watch.Start();
            for (int i = 0; i < iterations; i++)
                {
                    Console.WriteLine(endpoint((rip160 = new RIPEMD160Managed()), GetRandomBytes(1000 * 1024)));
                }
                watch.Stop();
            Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
        }
        static void Main(string[] args)
        {
            int iterations = 10000;
            TIMEmACHINE(iterations);
            Console.ReadKey();
        }
        
    }
}
