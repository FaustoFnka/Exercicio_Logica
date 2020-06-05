using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelecaoBenner
{
    /// <summary>
    /// CLASSE NetWork 
    /// Irá controlar uma rede de conexões entre um conjunto de pontos, 
    /// onde poderá ser criado o conjunto, 
    /// um método para criar conexões 
    /// e permitirá a consulta se existe ou não conexão.
    /// </summary>
    public class Network
    {
        public int[,] ConjuntoElementos;
        public int nroElementos;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="qtdElementos"> Quantidade de Elementos a ser criada pelo construtor</param>
        public Network(int qtdElementos)
        {
            nroElementos = qtdElementos;
            ConjuntoElementos = new int[nroElementos, nroElementos];

            //ShowNetwork();


            for (int i = 0; i < nroElementos; i++)
            {
                for (int j = 0; j < nroElementos; j++)
                {
                    if (i == j)
                    {
                        ConjuntoElementos[i, j] = 1;
                        //Console.WriteLine(String.Format("i= {0}, j= {1} = {2}", i, j, ConjuntoElementos[i, j]));
                    }
                    else
                    {
                        ConjuntoElementos[i, j] = 0;
                        //Console.WriteLine(String.Format("i= {0}, j= {1} = {2}", i, j, ConjuntoElementos[i, j]));
                    }
                }
            }
        }

        public void ShowNetwork()
        {
            for (int i = 0; i < nroElementos; i++)
            {
                for (int j = 0; j < nroElementos; j++)
                {
                    //Console.WriteLine(String.Format("[{0}] [{1}] = {2}",i,j, ConjuntoElementos[i,j]));
                    Console.Write(String.Format("{0} ", ConjuntoElementos[i, j]));
                }
                Console.Write("\n");
            }
        }

        public void Connect(int NroOrigem, int NroDestino)
        {
            ConjuntoElementos[NroOrigem, NroDestino] = 1;
            ConjuntoElementos[NroDestino, NroOrigem] = 1;
        }

        public void Disconnect(int NroOrigem, int NroDestino)
        {
            ConjuntoElementos[NroOrigem, NroDestino] = 0;
            ConjuntoElementos[NroDestino, NroOrigem] = 0;
        }

        public bool Query(int NroOrigem, int NroDestino, int iLoop = 0) // o ultimo parâmetro só será enviado caso seja chamada recursiva de dentro do methodo Query.
        {
            if (ConjuntoElementos[NroOrigem, NroDestino] == 1 || NroOrigem == NroDestino)
            {
                return true;
            }
            else
            {
                for (int i = iLoop; i < nroElementos; i++)
                {
                    if (i != NroOrigem && i != NroDestino)
                    {
                        if (Query(NroOrigem, i, (i + 1)))
                        {
                            Console.WriteLine(string.Format("O numero {0}, é ligado a {1}, verificando se {1} é ligado a {2}", NroOrigem, i, NroDestino));
                            return Query(i, NroDestino, i);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return false;
        }

    }
}
