Player player = new();
// Monster monster = new();

// while (player.Health > 0 && monster.Health > 0)
// {
//     Monster.UpdateAll();
//     Console.WriteLine($"{player.Name}>{player.Health}  |  {monster.Health}<{monster.Name}");
//     player.Health -= monster.Damage;
//     monster.Health -= player.Damage;

//     monster.Attack();
//     player.Attack();

//     Console.ReadLine();


// }


bool battle = true;
List<Monster> monsters = new();
for (int i = 0; i < Random.Shared.Next(1,4); i++)
{
    monsters.Add(new());
}

while (true)  //spelet
{

    while (battle)
    {
        for (int m = 0; m < monsters.Count; m++)
        {
            
        Monster.UpdateAll();
        player.Attack();
        monsters[m].Attack();
        player.Health -= monsters[m].Damage;
        monsters[m].Health -= player.Damage;


        }
        Console.WriteLine($"{monsters[0].Name}>{monsters[0].Health}  |  {player.Health}<{player.Name}");
        for (int i = 0; i < monsters.Count-1; i++)
        {
            Console.WriteLine($"{monsters[i+1].Name}>{monsters[i+1].Health}"); 
        }


        Console.ReadLine();
    }
}