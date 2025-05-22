// Gör alla instanser
Player player = new();
List<Monster> monsters = new();
GameFunktions game = new();

// Väljer hur många och vilka monser man ska möta
for (int i = 0; i < Random.Shared.Next(1, 4); i++)
{
    int choice = Random.Shared.Next(3);

    // Väljer mellan de tre monstrena
    Monster newMonster = choice switch
    {
        0 => new Goblin(),
        1 => new Orc(),
        2 => new Djivan()
    };
    monsters.Add(newMonster);
}

// Spelaren väljer Class
game.SetClass(player);

//spelet
game.Game(player, monsters);