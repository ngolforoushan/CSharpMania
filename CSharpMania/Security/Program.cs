using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Security {
    class Program {
        static void Main(string[] args) {
            loop();
        }

        static void loop() {
            Console.WriteLine("Select...");
            Console.WriteLine("1.Password Hash");
            Console.WriteLine("2.Salt");
            Console.WriteLine("3.");
            Console.WriteLine("4.");
            var sel = Convert.ToInt32(Console.ReadLine());

            switch (sel) {
                case 1:
                    PasswordHash();
                    break;
                case 2:
                    SaltGenerator(8);

                    break;
                case 3:

                    break;
                case 4:

                    break;
                default:
                    break;
            }
        }

        private static void SaltGenerator(int size)
        {
            var rng_algo = RandomNumberGenerator.Create();
            var salt = new byte[size];
            rng_algo.GetBytes(salt);
            Console.WriteLine("salt==>{0}",Convert.ToBase64String(salt));
            loop();
        }

        static void PasswordHash()
        {
            var alg = SHA512.Create();
            var passwordDictionary = new Dictionary<string, string>();
            HashIt("jijo", passwordDictionary);
            HashIt("milo", passwordDictionary);
            HashIt("test", passwordDictionary);

            var res = "157C0B9613EBD4CDA756D6607A6EB69020E6935B452D69416C3B5340239F6A3055C02811908E64EED0E1455AC75961D59906BB9DC2DD6424E4CD0D8479B998AD";
            Console.WriteLine("Password was {0}",passwordDictionary[res]);
            loop();

        }

        private static void HashIt(string psw, Dictionary<string, string> passwordDictionary)
        {
            var alg = SHA512.Create();
            passwordDictionary.Add(BitConverter.ToString(
                                alg.ComputeHash(
                                        Encoding.UTF8.GetBytes(
                                                psw
                                            )
                                    )
                            ).Replace("-", ""), psw);
        }
    }
}