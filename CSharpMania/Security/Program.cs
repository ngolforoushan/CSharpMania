using System;

namespace Security {
    class Program {
        static void Main(string[] args) {
            loop();
        }

        static void loop() {
            Console.WriteLine(@ "QSelect...");
            Console.WriteLine("Password Hash");
            Console.WriteLine("1.Simple Task");
            Console.WriteLine("2.");
            Console.WriteLine("3.");
            Console.WriteLine("4.");
            var sel = Convert.ToInt32(Console.ReadLine());

            switch (sel) {
                case 1:
                    PasswordHash();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                default:
                    break;
            }
        }
        static void PasswordHash() {
            System.Console.WriteLine("Passwor is newTestPscm");
            System.Console.WriteLine("Hash is..");
            
        }
    }
}