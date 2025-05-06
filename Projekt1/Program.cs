using System.Security.Cryptography.X509Certificates;

Player player = new();
GameFunktions game = new();
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
    game.Game(player, monsters);
}
