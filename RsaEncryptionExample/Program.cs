using System;
using System.Security.Cryptography;
using System.Text;

namespace RsaEncryptionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //1024 is the length of the key
            var cryptoServiceProvider = new RSACryptoServiceProvider(1024);
            //Generation of private key
            var privateKey = cryptoServiceProvider.ExportParameters(true);
            //Generation of public key
            var publicKey = cryptoServiceProvider.ExportParameters(false);

            string publicKeyString = GetKeyString(publicKey);
            string privateKeyString = GetKeyString(privateKey);

            Console.WriteLine("Public Key: ");
            Console.WriteLine(publicKeyString);
            Console.WriteLine("___________________");

            Console.WriteLine("PrivateKey: ");
            Console.WriteLine(privateKeyString);
            Console.WriteLine("___________________");

            Console.WriteLine("Enter text to encrypt: ");
            string textToEncrypt = Console.ReadLine();
            Console.WriteLine("___________________");


            Console.WriteLine("Text to encrypt: ");
            Console.WriteLine(textToEncrypt);
            Console.WriteLine("___________________");

            //Encryption with public key
            string encryptedText = Encrypt(textToEncrypt, publicKeyString);
            Console.WriteLine("Encrypted text: ");
            Console.WriteLine(encryptedText);
            Console.WriteLine("___________________");

            //Decryption with private key
            string decryptedText = Decrypt(encryptedText, privateKeyString);
            Console.WriteLine("Decrypted text: ");
            Console.WriteLine(decryptedText);
        }

        public static string GetKeyString(RSAParameters publicKey)
        {
            var stringWriter = new System.IO.StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, publicKey);
            return stringWriter.ToString();
        }

        public static string Encrypt(string textToEncrypt, string publicKeyString)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    rsa.FromXmlString(publicKeyString.ToString());
                    var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string Decrypt(string textToDecrypt, string privateKeyString)
        {
            var bytesToDecrypt = Encoding.UTF8.GetBytes(textToDecrypt);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    //Server decrypting data with set private key
                    rsa.FromXmlString(privateKeyString);        
                    var resultBytes = Convert.FromBase64String(textToDecrypt);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
    }
}
