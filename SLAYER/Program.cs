using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;
namespace crng
{
    class cryp
    {
        static void TimeAction(string description, int iterations, Action func)
        {
            var watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Console.Write(description);

            Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
        }

        static byte[] GetRandomBytes(int count)
        {
            var bytes = new byte[count];
            (new Random()).NextBytes(bytes);
            return bytes;
        }
        
        static void Main(string[] args)
        {
            //creating instances of cryptographic methods
            var md5 = new MD5CryptoServiceProvider();
            var sha1 = new SHA1CryptoServiceProvider();
            var sha256 = new SHA256CryptoServiceProvider();
            var sha384 = new SHA384CryptoServiceProvider();
            var sha512 = new SHA512CryptoServiceProvider();
            var ripemd160 = new RIPEMD160Managed();

            var source = GetRandomBytes(1000 * 1024);
            
            var algorithms = new Dictionary<string, HashAlgorithm>();
            algorithms["md5"] = md5;
                       
            algorithms["sha1"] = sha1;
            algorithms["sha256"] = sha256;
            algorithms["sha384"] = sha384;
            algorithms["sha512"] = sha512;
            algorithms["ripemd160"] = ripemd160;

            foreach (var pair in algorithms)
            {
                Console.WriteLine("Hash Length for {0} is {1}",
                    pair.Key,
                    pair.Value.ComputeHash(source).Length);
            }

            foreach (var pair in algorithms)
            {
                TimeAction(pair.Key + " calculation", 1000, () =>{ pair.Value.ComputeHash(source); });
            }

           
            Console.WriteLine(endpoint(sha512, source));
            Console.ReadKey();
        }
        static string endpoint(SHA512CryptoServiceProvider sha512,byte[] source)
        {

            byte[] hash = sha512.ComputeHash(source);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }
            return hashString;


           
        }
    }
    
    

}
