using System.Security.Cryptography.X509Certificates;

Player player = new();


bool battle = true;
List<Monster> monsters = new();

for (int i = 0; i < Random.Shared.Next(1, 4); i++)
{
    int choice = Random.Shared.Next(2);

    Monster newMonster = choice switch
    {
        0 => new Goblin(),
        1 => new Orc()
    };

    monsters.Add(newMonster);
}

while (true)  //spelet
{

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


