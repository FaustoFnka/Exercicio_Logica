using System;
using System.Security.Cryptography.X509Certificates;

namespace SelecaoBenner
{
    public class Program
    {
        public static void Main()
        {
            /*Console.WriteLine("Informe a quantidade de Itens:");
            var qtdItens = int.Parse(Console.ReadLine());
            */

            int qtdItens = 8;
            var MinhaRede = new Network(qtdItens);

            Console.WriteLine("\nSua rede:");
            MinhaRede.ShowNetwork();

            MinhaRede.Connect(0, 1);
            MinhaRede.Connect(0, 5);
            MinhaRede.Connect(1, 5);
            MinhaRede.Connect(1, 3);
            MinhaRede.Connect(4, 7);
            MinhaRede.Connect(4, 2);

            Console.WriteLine("\nSua rede: ");
            MinhaRede.ShowNetwork();

            Console.WriteLine("\nSua rede:");
            MinhaRede.Disconnect(4, 2);
            MinhaRede.ShowNetwork();

            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 0, 1, MinhaRede.Query(0, 1)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 1, 0, MinhaRede.Query(0, 1)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 1, 3, MinhaRede.Query(1, 3)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 3, 1, MinhaRede.Query(1, 3)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 0, 3, MinhaRede.Query(0, 3)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 3, 0, MinhaRede.Query(3, 0)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 2, 0, MinhaRede.Query(2, 0)));


        }
    }
}
