using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighscoresAV
{
    class Player
    {
        public string name;
        public int points;

        public Player(string Name, int Points)
        {
            this.name = Name;
            this.points = Points;
        }
    }
    class Program
    {
        static Player[] players = new Player[10];
        static void Main(string[] args)
        {
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("Qual o nome do player?");
                string name = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Quantos pontos o player fez?");
                        int points = Convert.ToInt32(Console.ReadLine());
                        players[i] = new Player(name, points);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Número invalido [Entre algum número valido]");
                        Console.ReadKey();
                    }
                }
                Console.Clear();
            }
            while (true)
            {
                players = BubbleSort(players);
                for (int i = players.Length - 1; i >= 1; i--)
                {
                    Console.WriteLine(players.Length - i + " - " + players[i].name + " | pontos - " + players[i].points);
                }
                Console.ReadKey();
                Console.WriteLine("Quer continuar? (S/N)");
                string answer = Console.ReadLine();
                while(answer != "S"  && answer != "N")
                {
                    Console.WriteLine("Quer continuar? (S/N) [ENTRE UMA RESPOSTA VÁLIDA]");
                    answer = Console.ReadLine();
                }
                if (answer == "N") 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Qual o nome do player?");
                    string name = Console.ReadLine();
                    Console.WriteLine("Quantos pontos o player fez?");
                    int points = Convert.ToInt32(Console.ReadLine());
                    Player newPlayer = new Player(name, points);
                    players = CheckNewPlayer(newPlayer, players);
                }
                Console.Clear();
            }
        }
        public static Player[] BubbleSort(Player[] arrayToBeSorted)
        {
            Player auxPlayer;
            for (int i = 0; i < arrayToBeSorted.Length; i++)
            {
                for (int j = 0; j < arrayToBeSorted.Length - 1; j++)
                {
                    if (arrayToBeSorted[j].points > arrayToBeSorted[j + 1].points)
                    {
                        auxPlayer = arrayToBeSorted[j];
                        arrayToBeSorted[j] = arrayToBeSorted[j + 1];
                        arrayToBeSorted[j + 1] = auxPlayer;
                    }
                }
            }
            return arrayToBeSorted;
        }
        public static Player[] CheckNewPlayer(Player newPlayer, Player[] players)
        {
            Player auxPlayer;
            for(int i = 0; i < players.Length; i++)
            {
                if(newPlayer.points > players[i].points)
                {
                    auxPlayer = players[i];
                    players[i] = newPlayer;
                    if (i != 0)
                    {
                        players[i-1] = auxPlayer;
                    }
                }
            }
            return players;
        }
    }
}
