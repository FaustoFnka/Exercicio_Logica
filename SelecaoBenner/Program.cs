using System;
using System.Security.Cryptography.X509Certificates;

namespace SelecaoBenner
{
    public class Program
    {
        public static void Main()
        {
            //Para o exercídio foi removida a leitura do usuário
            //Lendo do usuário tamanho da rede
            //Console.WriteLine("Informe a quantidade de Itens:");
            //var qtdItens = int.Parse(Console.ReadLine());

            //Configurando o total de pontos do exercício
            int qtdItens = 8;

            //Criando Rede
            var MinhaRede = new Network(qtdItens);

            //Imprimindo rede inicial em tela
            Console.WriteLine("\nSua rede:");

            //Apresenta em tela os pontos da rede e suas interconexões.
            MinhaRede.ShowNetwork();

            //Faz a inclusão dos pontos do exercício.
            MinhaRede.Connect(0, 1);
            MinhaRede.Connect(0, 5);
            MinhaRede.Connect(1, 5);
            MinhaRede.Connect(1, 3);
            MinhaRede.Connect(4, 7);
            MinhaRede.Connect(4, 2);

            //Irá apresentar a rede após as inclusões de conexão.
            Console.WriteLine("\nSua rede: ");
            MinhaRede.ShowNetwork();

            //Faz a desconeção de dois pontos e imprime a rede novamente para validação.
            MinhaRede.Disconnect(4, 2);
            Console.WriteLine("\nSua rede:");
            MinhaRede.ShowNetwork();

            //Fas a impressão em tela de várias vavlidações de caminhos possíveis.
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 0, 1, MinhaRede.Query(0, 1)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 1, 0, MinhaRede.Query(0, 1)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 1, 3, MinhaRede.Query(1, 3)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 3, 1, MinhaRede.Query(1, 3)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 0, 3, MinhaRede.Query(0, 3)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 3, 0, MinhaRede.Query(3, 0)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 2, 0, MinhaRede.Query(2, 0)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 3, 4, MinhaRede.Query(3, 4)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 7, 0, MinhaRede.Query(7, 0)));
            Console.WriteLine(string.Format("\n{0} está conectado a {1}? {2}", 2, 6, MinhaRede.Query(2, 6)));


        }
    }
}
