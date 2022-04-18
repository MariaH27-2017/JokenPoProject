using System;
using System.Threading;

namespace JokenPoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            JokenpoList jokenpo = new JokenpoList();
            jokenpo.Play();
            
            
            Console.ReadLine();

        }
    }

    public class JokenpoList
    {
        private class MyListItem
        {
            public string? Value { get; set; }
            public MyListItem Node { get; set; }
        }

        public int UserPoint { get; set; }
        public int BotPoint { get; set; }
        private MyListItem raiz;

        public JokenpoList()
        {
            raiz = new MyListItem();
            raiz.Value = "Pedra";

            raiz.Node = new MyListItem()
            { 
                Value = "Papel",
                Node = new MyListItem()
                {
                    Value = "Tesoura"
                }

            };

            
        }

        public string Read(int position)
        {
            MyListItem par = raiz;
            int count = 0;
            while(count < position)
            {
                par = par.Node;
                count++;
            }

            return par.Value;
        }

        public int Size()
        {
            int size = 0;
            MyListItem par = raiz;

            while (par != null)
            {
                size++;
                par = par.Node;
            }

            return size;
        }

        public void Play()
        {
            JokenpoList jokenpoList = new JokenpoList();

            Console.WriteLine($"Escolha uma opção: \r\n {jokenpoList}");

            string userValue = Console.ReadLine();

            bool invalidValue = userValue != "1" && userValue != "2" && userValue != "3";
            
            while (invalidValue == true)
            {
                Console.WriteLine("Valor invalido");
                Console.WriteLine("Informe o número 1, 2 ou 3");
                userValue = Console.ReadLine();

                invalidValue = userValue != "1" && userValue != "2" && userValue != "3";

            }

            Random randNum = new Random();

            string botValue = jokenpoList.Read(randNum.Next(3));
            userValue = jokenpoList.Read(Convert.ToInt32(userValue) - 1);

            Console.WriteLine("\r\nJO");
            Thread.Sleep(1000);
            Console.WriteLine("KEN");
            Thread.Sleep(1000);
            Console.WriteLine("PO");
            Thread.Sleep(500);

            Console.WriteLine($"\r\nVocê:{userValue} X Bot:{botValue}" );

            bool userWins = userValue == "Tesoura" && botValue == "Papel" || userValue == "Papel" && botValue == "Pedra" || userValue == "Pedra" && botValue == "Tesoura";

            if(userWins)
            {
                Console.WriteLine("Parabéns você ganhou! \\o/");
                UserPoint++;
            }
            else if (userValue == botValue)
            {
                Console.WriteLine("Empate");
                UserPoint++;
                BotPoint++;
            }
            else
            {
                Console.WriteLine("Não foi dessa vez, mas não desista");
                BotPoint++;
            }

            
            Console.WriteLine("\r\nVamos Jogar Novamente!\r\n");

            Console.WriteLine("---- Placar -------");
            Console.WriteLine($"Você:{UserPoint} vs Bot:{BotPoint}");


            Play();

        }

        public override string ToString()
        {
            int n = 1;
            string result = string.Empty;

            MyListItem par = raiz;

            while(par != null)
            {
                result = $"{result}\r\n {n} - {par.Value} ";
                par = par.Node;
                n++;
            }

            return $"{result}";
        }

    }
}
