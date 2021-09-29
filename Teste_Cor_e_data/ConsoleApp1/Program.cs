using System;
using System.Security.Cryptography;
using System.Text;
using ColorHelper;
namespace ConsoleApp1
{

    class Program
    {
        public static byte[] GetHash(string inputString) //metodo para retornar o hash com base na string recebida
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        static void Main()
        {

            Console.WriteLine("Digite uma string para sua cor!");
            DateTime utcDate = DateTime.UtcNow; 
            string input_str = Console.ReadLine();
            input_str += utcDate; //a data de criação(formato UTC) é colocada na string para gerar o hash e cor


            using (SHA256 mySHA256 = SHA256.Create()) //utilizando o metodo sha256 para encriptar a string recebida
            {
                StringBuilder sb = new StringBuilder(); //declarando o stringbuilder 
                byte[] b_hash = GetHash(input_str);

                foreach (byte b in b_hash) //cada byte recebido do b_hash vira um caracter hexadecimal em utf-16
                    sb.Append(b.ToString("x2"));

                string hash = sb.ToString();

                Console.WriteLine("String: " + input_str);
                Console.WriteLine("Hash: " + hash);
                RGB rgb = new RGB(b_hash[0], b_hash[1], b_hash[2]);
                HEX hex = ColorConverter.RgbToHex(rgb);
                Console.WriteLine("Cor gerada:" + hex);

                Console.WriteLine("{0:MM/dd/yyy HH:mm:ss.fff}",utcDate);
                

            }
        }
    }
}
