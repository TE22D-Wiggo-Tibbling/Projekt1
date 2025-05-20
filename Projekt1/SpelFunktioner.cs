using System.Threading.Channels;

public class GameFunktions
{

    public void SetClass(Player player1)
    {
        int Choise = 0;
        Console.WriteLine("Chose Class:");
        Console.WriteLine("1. Fighter");
        Console.WriteLine("2. Mage");
        Console.WriteLine("3. Assasin");
        Console.WriteLine("4. Tank");

        while (Choise < 1 || Choise > 4)
        {

            while (!int.TryParse(Console.ReadLine(), out Choise))
            {
                Console.WriteLine("Chose a class");
            }
        }

        if (Choise == 1)
        {
            player1.Klass = new Fighter();
        }
        if (Choise == 2)
        {
            player1.Klass = new Mage();
        }
        if (Choise == 3)
        {
            player1.Klass = new Assasin();
        }
        if (Choise == 4)
        {
            player1.Klass = new Tank();
        }
        player1.SetStats();
    }


    public void Game(Creature player, List<Monster> monsters)
    {

        Console.WriteLine("You will fight against 1-3 monsters");
        Console.WriteLine("To make a choise of action pic one of the numbers that will be depicted");
        Console.WriteLine("You will be able to attack a monster or heal yourself");
        Console.WriteLine("Dont die");
        Console.ReadLine();
        Console.Clear();

        while (player.Health > 0 && monsters.Count > 0)
        {

            // Årdningen av Action

            //    Sorterar beroende på ett tall som i detta fall är fart
            PriorityQueue<Creature, int> queue = new PriorityQueue<Creature, int>();

            // Sätter in spelaren
            queue.Enqueue(player, 20 - player.MyStats["Speed"]);


            // Sätter in alla monster
            foreach (Monster monsteris in monsters)
            {
                queue.Enqueue(monsteris, 20 - monsteris.MyStats["Speed"]);
            }

            List<Creature> battleQueue = new();


            // tar från toppen och sätter in i battle queue
            while (queue.Count > 0)
            {
                battleQueue.Add(queue.Dequeue());
            }


            // Skriver alla varelser
            Console.WriteLine($"{monsters[0].Name}>{monsters[0].Health}  |  {player.Health}<{player.Name}");
            for (int i = 0; i < monsters.Count - 1; i++)
            {
                Console.WriteLine($"{monsters[i + 1].Name}>{monsters[i + 1].Health}");
            }


            // Gör deras Action beroende på arv
            foreach (Creature creature in battleQueue)
            {
                if (creature is Monster)
                {
                    creature.Action(player);
                }
                else
                {

                    Console.WriteLine("Who you want to attack");

                    for (int i = 0; i < monsters.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {monsters[i].Name}>{monsters[i].Health}");
                    }

                    // Bestämmer vem man ska attakera
                    int choice = 0;
                    while (choice < 1 || choice > monsters.Count)
                    {
                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("Write one of the options");
                        }
                    }

                    creature.Action(monsters[choice - 1]);


                }
                // När monster dör tas de bort från listan
                monsters.RemoveAll(m => m.Health <= 0);
            }

            Console.ReadLine();
            Console.Clear();
        }


        // Om man vinner eller förlorar
        if (player.Health <= 0)
        {
            Console.WriteLine("You died");
            Console.ReadLine();
            Environment.Exit(0);

        }
        if (monsters.Count == 0)
        {
            Console.WriteLine("You win!");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }

}

