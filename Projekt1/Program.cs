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

    while (battle)
    {

        // Årdningen av Action
        PriorityQueue<Creature, int> queue = new PriorityQueue<Creature, int>();
        queue.Enqueue(player, 20 - player.myStats["Speed"]);


        foreach (Monster monsteris in monsters)
        {
            queue.Enqueue(monsteris, 20 - monsteris.myStats["Speed"]);
        }

        List<Creature> BattleQueue = new();


        while (queue.Count > 0)
        {
            BattleQueue.Add(queue.Dequeue());
        }



        foreach (Creature creature in BattleQueue)
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
        }




        Console.WriteLine($"{monsters[0].Name}>{monsters[0].Health}  |  {player.Health}<{player.Name}");
        for (int i = 0; i < monsters.Count - 1; i++)
        {
            Console.WriteLine($"{monsters[i + 1].Name}>{monsters[i + 1].Health}");
        }


        Console.ReadLine();
        Console.Clear();
    }
}


