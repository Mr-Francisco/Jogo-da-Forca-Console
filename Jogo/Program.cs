using System.Runtime.InteropServices;
using System.Text;

namespace Exercicios
{
    public class Forca
    {
        private static string CaminhoDeDados = @"C:\Users\PC\Desktop\PROJECTOS\Teste\Teste2\Text2.txt";

        public static void Main()

        {

            int Retorno=0;


            string? Resposta;
           

            Console.Clear();
            System.Console.WriteLine("Benvindo ao jogo da Forca  ");
              Console.WriteLine("Queris continuar se sim prima 'S' ");
          
            Resposta = Console.ReadLine();
            if (Resposta is null)
                Resposta = "N";

            while (Resposta.ToUpper() == "S")
            {

                Retorno = Jogos();
                Console.Clear();
                if (Retorno == 0)
                    Console.Write("Voce Perdeu !");
                else if (Retorno == 1)
                    Console.Write("Voce Venceu !");
                else
                    Console.Write("Nao Sei");


                Console.Write("Quer continuar ? sem prima s ");
                    Resposta = Console.ReadLine();
            if (Resposta is null)
                Resposta = "N";


            }










          

           

        }



        public static List<string> Lista()
        {
            List<string> Dados = new();

            string[] dados = File.ReadAllLines(CaminhoDeDados);
            Random random = new();


            int r1 = random.Next(1, 10);
            foreach (string c in dados)
            {
                if (c.StartsWith(r1.ToString()))
                {
                    Dados.Add(c.Trim());

                }
            }

            return Dados;


        }

        public static int Jogos()
        {
            string Tema;
            string Questao;
            int count = 1;
            int Tentativas = 3;
            List<string> Dados = Lista();
            Tema = Dados[0];
            int posicao = 0;



            string[] quetao = Dados[count].Replace(" ", "").Split("-");
            Questao = quetao[count];
            char[] caracterCertos = Questao.ToArray();
            char[] caracterNaoPreenchido = new char[caracterCertos.Length];
            char caracterDigitado;
            for (int i = 0; i < caracterNaoPreenchido.Length; i++)
            {
                caracterNaoPreenchido[i] = '_';
            }
            int Acertos = 0;

            while (Acertos <= caracterCertos.Length)
            {
                Console.Clear();
                Console.WriteLine("Tema: {0} \n\nDireito a {1} Tentativas ", Tema, Tentativas);
                Console.WriteLine();

                for (int j = 0; j < caracterCertos.Length; j++)
                {
                    Console.Write(caracterNaoPreenchido[j]);
                }
                Console.WriteLine();
                Console.Write("Digite o caracter : ");

                caracterDigitado = Convert.ToChar(Console.ReadLine());
                if (caracterDigitado == caracterCertos[Acertos])
                {
                    caracterNaoPreenchido[posicao] = caracterDigitado;
                    posicao++;
                    Acertos++;
                    Tentativas = 3;



                }
                else
                {
                    if (Tentativas > 0)
                    {
                        Tentativas--;
                    }
                    else

                    {
                       
                        return 0;

                    }




                }


                if (Acertos == caracterCertos.Length - 1)
                    return 1;
               

            }


            return 0;
            
        
         } 

    }
}