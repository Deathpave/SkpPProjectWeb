using System;
using System.Text;

namespace LibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SkpDbLib.Managers.Security sec = new SkpDbLib.Managers.Security();
            SkpDbLib.Managers.Files files = new SkpDbLib.Managers.Files();

            Console.WriteLine("Testing encryption");

            // encrypts data
            string encryptionTest = "Alle elsker kage!";
            byte[] textToEncrypt = Encoding.UTF8.GetBytes(encryptionTest);

            byte[] saltbyte = Convert.FromBase64String(sec.GenerateSalt());

            string base64 = sec.Encrypt(textToEncrypt, saltbyte);
            Console.WriteLine(base64);

            Console.WriteLine("\nTesting decryption");

            // decrypts data
            string plain = sec.Decrypt(Convert.FromBase64String(base64), saltbyte);
            Console.WriteLine(plain);

            Console.WriteLine("\nTesting hashing");

            string plainhash = sec.Hash(Encoding.UTF8.GetBytes(encryptionTest));
            string decrypthash = sec.Hash(Encoding.UTF8.GetBytes(plain));
            Console.WriteLine("Plainhash : " + plainhash);
            Console.WriteLine("Decrypthash : " + decrypthash);


            Console.WriteLine("\nTesting File handling");
            // creates file, and saves salt and "connection string" to it
            string salt = sec.GenerateSalt();
            string data = "Connection string goes here";
            string encryptedData = sec.Encrypt(Encoding.UTF8.GetBytes(data), Convert.FromBase64String(salt));
            string combined = salt + "\n" + encryptedData;
            files.WriteStringToFile(@"C:\Users\MartinRiehnMadsen\Desktop\SkpDbTest\TestRead.txt", combined);
            Console.WriteLine("File have been written!");

            // reads the file, and splits the data so it can be decrypted
            string content = files.ReadFileToString(@"C:\Users\MartinRiehnMadsen\Desktop\SkpDbTest\TestRead.txt");
            string[] splits = content.Split('\n');
            salt = splits[0];
            string decrypteddata = sec.Decrypt(Convert.FromBase64String(splits[1]), Convert.FromBase64String(salt));
            Console.WriteLine(decrypteddata);


            SkpDbLib.Managers.Db db = new SkpDbLib.Managers.Db();
            sec.Dispose();
            files.Dispose();
            db.Dispose();


            // creates and sends an email
            // cannot debug due to not being able to access zbc mail server
            //SkpDbLib.Managers.Message message = new SkpDbLib.Managers.Message();
            //Console.WriteLine("\nTesting email sending");
            //message.SendMessage(SkpDbLib.Messages.Mediatype.Email, "Testing Email provided for assignment\nHave a nice day!", "mart112f@zbc.dk");
            //Console.WriteLine("Email have been sent");

            Console.ReadLine();
        }
    }
}
