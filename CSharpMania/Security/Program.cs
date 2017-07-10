using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Security
{
    class Program
    {
        static void Main(string[] args)
        {
            loop();
        }

        static void loop()
        {
            Console.WriteLine("Select...");
            Console.WriteLine("1.Password Hash");
            Console.WriteLine("2.Salt");
            Console.WriteLine("3.Rijandael");

            var sel = Convert.ToInt32(Console.ReadLine());

            switch (sel)
            {
                case 1:
                    PasswordHash();
                    break;
                case 2:
                    SaltGenerator(8);
                    break;
                case 3:
                    SymetricEncription();
                    break;
                default:
                    break;
            }
        }

        private static void SymetricEncription()
        {
            Console.WriteLine("Please insert data...");
            var plain_data = Console.ReadLine();
            Rijandael(plain_data);

        }

        private static void Rijandael(string data)
        {
            var rijandael_alg = Aes.Create();
            rijandael_alg.BlockSize = 128;
            rijandael_alg.KeySize = 256;
            rijandael_alg.Padding = PaddingMode.PKCS7;
            rijandael_alg.Mode = CipherMode.CBC;


            rijandael_alg.GenerateKey();
            var key = rijandael_alg.Key;
            Console.WriteLine("#######################################################");
            Console.WriteLine("Encription");
            Console.WriteLine("----------");
            Console.WriteLine("IV:{0}", Convert.ToBase64String(rijandael_alg.IV));
            Console.WriteLine("Key:{0}",Convert.ToBase64String(rijandael_alg.Key));
            var byte_data = Encoding.UTF8.GetBytes(data);
            var crypted_data = rijandael_alg.CreateEncryptor()
                .TransformFinalBlock(byte_data, 0, byte_data.Length);
            Console.WriteLine("Cipher Text: {0}",Convert.ToBase64String(crypted_data));

            Console.WriteLine("Decription");
            Console.WriteLine("----------");
            Console.WriteLine("Plain Text: {0}",Encoding.UTF8.GetString(rijandael_alg.CreateDecryptor().TransformFinalBlock(crypted_data,0,crypted_data.Length)));
            Console.WriteLine("#######################################################");
            Console.WriteLine();
            loop();
        }

        private static void SaltGenerator(int size)
        {
            var rng_algo = RandomNumberGenerator.Create();
            var salt = new byte[size];
            rng_algo.GetBytes(salt);
            var str_salt = Convert.ToBase64String(salt);
            Console.WriteLine("salt==>{0}", str_salt);
            var sha_algo = SHA512.Create();
            var res = sha_algo.ComputeHash(Encoding.UTF8.GetBytes("mypassword" + str_salt + "#s9$An>k"));
            Console.WriteLine("Salted,Hased password=>{0}", Convert.ToBase64String(res));
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
            Console.WriteLine("Password was {0}", passwordDictionary[res]);
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