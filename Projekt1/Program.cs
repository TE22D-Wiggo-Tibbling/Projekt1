using System.Security.Cryptography.X509Certificates;

Player player = new();
List<Monster> monsters = new();

for (int i = 0; i < Random.Shared.Next(1, 4); i++)
{
    int choice = Random.Shared.Next(3);

    Monster newMonster = choice switch
    {
        0 => new Goblin(),
        1 => new Orc(),
        2 => new Djivan()
    };
    monsters.Add(newMonster);
}

while (true)  //spelet
{
    GameFunktions.Game(player, monsters);
}