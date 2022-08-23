using System;

namespace PJogo_da_velha
{
    internal class JogodaVelha

    {
        bool fimdejogo = false;
        char[] posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char vez = 'X';
        int quantidadepreenchida = 0;

        static void Main(string[] args)
        {
            new JogodaVelha().iniciar();


        }

        public void iniciar()
        {
            while (!fimdejogo)
            {
                mostrartabela();
                lerjogada();
                mostrartabela();
                verificarfimdejogo();
                mudarvez();
                //enquanto o jogo não tiver acabado, ele vai chamar as funções nesta ordem:
                //a tabela é mostrada, a jogada é lida(e validada)
                //a tabela é mostraa apos ser atualizada, é verificado se o jogo acabou, caso não, muda-se a vez
            }
        }


        public void mostrartabela()
        {
            Console.Clear();
            Console.WriteLine("Jogador 1: X\nJogador 2: O");
            Console.WriteLine(obtertabela());
        }

        public string obtertabela()
        {
            return
                   $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  ";
            //função que escreve a tabela do jogo da velha na tela
        }

        public void preenchercampojogada(int posicaoescohida)
        {
            int conversor = posicaoescohida - 1;
            //a contagem dos campos no programa começa em 0, logo, vai de 0 a 8. para que não
            //ocorra confusões e facilitar a leitura para o usuario, quando ele digitar, por exemplo, 
            //9, o computador vai entender que o campo escolhido é o 8

            posicoes[conversor] = vez;
            //posições no campo escolhido vai ser preenchido com o simbolo que representa o jogador

            quantidadepreenchida++;
            //se soma 1 na quantidade pde campos preenchidos toda vez que uma jogada é executada

        }

        public bool validarjogada(int posicaoescolhida)
        {

            int conversor = posicaoescolhida - 1;


            return posicoes[conversor] != 'O' && posicoes[conversor] != 'X';
            //valida a jogada. caso o campo escolhido ja tenha sido preenchido, ele retorna 
        }

        public void lerjogada()
        {
            Console.WriteLine($"Agora é a vez de {vez}, escolha uma posição entre 1 e 9 disponivel na tabela ");
            int posicaoescolhida = 0;
            //le o campo que o jogador escolheu
            try
            {
                posicaoescolhida = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("?? Por acaso isso eh um numero? Escolhe um numero de 1 a 9.");
                posicaoescolhida = int.Parse(Console.ReadLine());
                //caso o valor inserido não seja um numero
            }

            if (posicaoescolhida <= 0 || posicaoescolhida > 9 || !validarjogada(posicaoescolhida))
            {
                Console.WriteLine("Escolha uma posição disponivel entre 1 e 9.");
                posicaoescolhida = int.Parse(Console.ReadLine());

                //caso o campo escolhida seja menor que 0, maior que 9 ou não tenha sido validado

            }

            preenchercampojogada(posicaoescolhida);
            //chamando função que preenche o campo, caso tudo tenha ocorrido do jeito certo
        }

        public bool vitoriahorizontal()
        {
            bool vitorialinha1 = posicoes[0] == posicoes[1] && posicoes[1] == posicoes[2];
            bool vitorialinha2 = posicoes[3] == posicoes[4] && posicoes[4] == posicoes[5];
            bool vitorialinha3 = posicoes[6] == posicoes[7] && posicoes[7] == posicoes[8];

            return vitorialinha1 || vitorialinha2 || vitorialinha3;
            //função que mostra para o programa quais posições precisam ser preenchidas para que ocorra
            //uma vitoria em alguma linha. caso ocorra alguma, ele retorna 
        }

        public bool vitoriavertical()
        {

            bool vitoriacoluna1 = posicoes[0] == posicoes[3] && posicoes[3] == posicoes[6];
            bool vitoriacoluna2 = posicoes[1] == posicoes[4] && posicoes[4] == posicoes[7];
            bool vitoriacoluna3 = posicoes[2] == posicoes[5] && posicoes[5] == posicoes[8];

            return vitoriacoluna1 || vitoriacoluna2 || vitoriacoluna3;
            //função que mostra para o programa quais posições precisam ser preenchidas para que ocorra
            //uma vitoria nas colunas. caso ocorra alguma, ele retorna 

        }

        public bool vitoriadiagonal()
        {
            bool vitoriadiagonal1 = posicoes[0] == posicoes[4] && posicoes[4] == posicoes[8];
            bool vitoriadiagonal2 = posicoes[2] == posicoes[4] && posicoes[4] == posicoes[6];

            return vitoriadiagonal1 || vitoriadiagonal2;
            //função que mostra para o programa quais posições precisam ser preenchidas para que ocorra
            //uma vitoria na diagonal. caso ocorra alguma, ele retorna 
        }

        public void verificarfimdejogo()
        {
            if (quantidadepreenchida < 5)
                return;
            //o minimo de jogadas necessarias para que o jogo acabe é 5. então se o numero de jogadas for menor que 5, ele retorna

            if (vitoriadiagonal() || vitoriahorizontal() || vitoriavertical())
            {
                fimdejogo = true;
                Console.WriteLine($"Vitoria de {vez}!!!!");
                return;
                //se tiver alguma vitoria, ele escreve quem é o vencedor e encerra a execução
            }

            if (quantidadepreenchida == 9)
            {
                fimdejogo = true;
                Console.WriteLine($"Deu velha :(");
                // caso os 9 campos tenham sido preenchidos e não houver nenhum vencedor, significa que houve empate
            }
        }

        public void mudarvez()
        {
            if (vez == 'X')
                vez = 'O';
            else
                vez = 'X';
            //função que muda a vez do jogador. Se quando for chamada a vez for do X, ela vai mudar para o O e vice versa

        }
    }
}
