using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigningCore
{
    public class Common
    {
        public static string PfxFile = @".pfx";
        public static string PfxPwd = "";
        public static string InputFile = @"data test/data.txt";
        public static string InputXmlFile = "data test/books.xml";
        public static string DiffXmlFile = "data test/diff.xml";
        public static string EncryptedXmlFile = "data test/books_enc.xml";
        public static string DecryptedXmlFile = "data test/books_dec.xml";
        public static string SignedXmlFile = "data test/books_signed.xml";
        public static string SignedFile = @"data test/signed.txt";
        public static string EncryptedFile = @"data test/encrypted.txt";
        public static string DecryptedFile = @"data test/decrypted.txt";

        public static void Show(string msg, ConsoleColor consoleColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine($"[{DateTime.UtcNow.ToString()}] {msg}");
            Console.ResetColor();
        }        

        public static void Prepare()
        {
            if (File.Exists(Common.SignedFile))
            {
                File.Delete(Common.SignedFile);
            }

            if (File.Exists(Common.DecryptedFile))
            {
                File.Delete(Common.DecryptedFile);
            }

            if (File.Exists(Common.EncryptedFile))
            {
                File.Delete(Common.EncryptedFile);
            }

            if (File.Exists(Common.SignedXmlFile))
            {
                File.Delete(Common.SignedXmlFile);
            }

            if (File.Exists(Common.DecryptedXmlFile))
            {
                File.Delete(Common.DecryptedXmlFile);
            }

            if (File.Exists(Common.EncryptedXmlFile))
            {
                File.Delete(Common.EncryptedXmlFile);
            }
            if (File.Exists(Common.DiffXmlFile))
            {
                File.Delete(Common.DiffXmlFile);
            }
        }

        public static bool CheckFileNotExists(string file)
        {
            return !File.Exists(file);
        }

        public static void CheckStringNull(string str, string className, string methodName, string msg)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new Exception($"{className}.{methodName} ... {msg} null");
        }

        public static void CheckObjectNull(object obj, string className, string methodName, string msg)
        {
            if (obj == null)
                throw new Exception($"{className}.{methodName} ... {msg} null");
        }

        public static void ShowResult(bool result, string className, string methodName)
        {
            ConsoleColor consoleColor = result ? ConsoleColor.Green : ConsoleColor.Red;
            Common.Show($"{className} -> {methodName} ... {result}", consoleColor);
        }

        public static bool CheckString(string target)
        {
            return string.IsNullOrWhiteSpace(target);
        }
    }
}
