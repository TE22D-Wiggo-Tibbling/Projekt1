Player player = new();

player.Action();
Console.ReadLine();


bool battle = true;
List<Monster> monsters = new();
for (int i = 0; i < Random.Shared.Next(1, 4); i++)
{
    monsters.Add(new());
}

while (true)  //spelet
{

    while (battle)
    {

        // Årdningen av Action
        PriorityQueue<Creature, int> queue = new PriorityQueue<Creature, int>();
        queue.Enqueue(player, 20-player.myStats["Speed"]);
        for (int i = 0; i < monsters.Count; i++)
        {
            queue.Enqueue(monsters[i], 20-monsters[i].myStats["Speed"]);
        }

        List<Creature> BattleQueue = new();

        for (int i = 0; i < queue.Count; i++)
        {
            BattleQueue.Add(queue.Peek());
        }


for (int i = 0; i < BattleQueue.Count; i++)
{
    BattleQueue[i].
}

        for (int m = 0; m < monsters.Count; m++)
        {

            Monster.UpdateAll();
            player.Attack();
            monsters[m].Attack();
            player.Health -= monsters[m].Damage;
            monsters[m].Health -= player.Damage;


        }
        Console.WriteLine($"{monsters[0].Name}>{monsters[0].Health}  |  {player.Health}<{player.Name}");
        for (int i = 0; i < monsters.Count - 1; i++)
        {
            Console.WriteLine($"{monsters[i + 1].Name}>{monsters[i + 1].Health}");
        }


        Console.ReadLine();
    }
}


