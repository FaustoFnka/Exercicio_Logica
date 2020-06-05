using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelecaoBenner
{
    /// <summary>
    /// CLASSE: NetWork 
    /// Irá controlar uma rede de conexões entre um conjunto de pontos, 
    /// No construtor da classe será criado o conjunto de pontos a ser manipulado, 
    /// um método para apresentar o consunto de ponto e suas conoexões
    /// Outro método para criar conexões entre pontos
    /// Mais um  método para desconectar pontos
    /// e ainda permitirá a consulta se existe ou não conexão entre dois pontos.
    /// </summary>
    public class Network
    {
        public int[,] ConjuntoElementos;
        public int nroElementos;

        /// <summary>
        /// CONSTRUTOR: 
        /// </summary>
        /// <param name="qtdElementos"> Quantidade de Elementos a ser criada pelo construtor</param>
        public Network(int qtdElementos)
        {
            nroElementos = qtdElementos;
            ConjuntoElementos = new int[nroElementos, nroElementos];

            for (int i = 0; i < nroElementos; i++)
            {
                for (int j = 0; j < nroElementos; j++)
                {
                    if (i == j)
                    {
                        ConjuntoElementos[i, j] = 1; //Faz a marcação de "conectado" = 1, caso seja o ponto com ele mesmo.
                    }
                    else
                    {
                        ConjuntoElementos[i, j] = 0; //Para qualquer outro ponto na criação é marcado como "disconectado" = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Methodo utilizado para imprimir a matriz de conexões.
        /// </summary>
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

        /// <summary>
        /// Metodo usado para efetuar a conexão de dois pontos.
        /// </summary>
        /// <param name="NroOrigem">Ponto Origem</param>
        /// <param name="NroDestino">Ponto Destinno</param>
        public void Connect(int NroOrigem, int NroDestino)
        {
            ConjuntoElementos[NroOrigem, NroDestino] = 1;
            ConjuntoElementos[NroDestino, NroOrigem] = 1;
        }

        /// <summary>
        /// Metodo usado para efetuar a desconeção de dois pontos
        /// </summary>
        /// <param name="NroOrigem">Ponto Origem</param>
        /// <param name="NroDestino">Poto Destino</param>
        public void Disconnect(int NroOrigem, int NroDestino)
        {
            ConjuntoElementos[NroOrigem, NroDestino] = 0;
            ConjuntoElementos[NroDestino, NroOrigem] = 0;
        }

        /// <summary>
        /// Metodo utilizado para verificar se existe conexão entre os dois pontos. 
        /// Irá chamar recursivamente a si mesmo para verificar todas as possibilidades de conexão.
        /// </summary>
        /// <param name="NroOrigem">Ponto Origem para análise</param>
        /// <param name="NroDestino">Ponto de Destino para a análise</param>
        /// <param name="iLoop"> indicador de Looping, só é necessário para chamadas recursivas do méthodo</param>
        /// <returns></returns>
        public bool Query(int NroOrigem, int NroDestino, int iLoop = 0) // o ultimo parâmetro só será enviado caso seja chamada recursiva de dentro do methodo Query.
        {
            // Se for Origem igual a Destino ou se for um ponto de conexão direto retornará True imediatamente, 
            //Caso contrário irá validar a necessidade de chamada recursiva para validar caminho com conexões extras.
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
                        //Chamada recursiva para analisar se quais as conexões diretas da Origem,
                        //Só chamara o teste recursivo verificando com o destino se for conexão com a origem.
                        if (Query(NroOrigem, i, (i + 1)))
                        {
                            //Chamada recursiva para verificar se as conexões da Origem São "escalas" válidas para o destino.
                            return Query(i, NroDestino, i);
                        }
                        else
                        {
                            //Caso a Origem não tiver conexão com o item verificado passa para o próximo item do for.
                            continue;
                        }
                    }
                    else
                    {
                        //Caso o item do for analisado for igual a Origem ou ao Destino já verificados passa direto para o próximo item do for.
                        continue;
                    }
                }
            }
            //Caso nenhuma das tentativas de "escala" forem viáveis retorna falso, identificando como rota inviável.
            return false;
        }

    }
}
