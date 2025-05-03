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
        for (int i = 0; i < monsters.Count; i++)
        {
            queue.Enqueue(monsters[i], 20 - monsters[i].myStats["Speed"]);
        }

        List<Creature> BattleQueue = new();

        for (int i = 0; i < queue.Count; i++)
        {
            BattleQueue.Add(queue.Peek());
        }



        for (int i = 0; i < BattleQueue.Count; i++)
        {
            BattleQueue[i].Action();
        }

 
        Console.WriteLine($"{monsters[0].Name}>{monsters[0].Health}  |  {player.Health}<{player.Name}");
        for (int i = 0; i < monsters.Count - 1; i++)
        {
            Console.WriteLine($"{monsters[i + 1].Name}>{monsters[i + 1].Health}");
        }


        Console.ReadLine();
    }
}


