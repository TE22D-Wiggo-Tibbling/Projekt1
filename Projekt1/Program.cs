Player player = new();
Monster monster = new();

while (player.Health > 0 && monster.Health > 0)
{
    Monster.UpdateAll();
    Console.WriteLine($"{player.Name}>{player.Health}  |  {monster.Health}<{monster.Name}");
    player.Health -= monster.Damage;
    monster.Health -= player.Damage;

    monster.Attack();
    player.Attack();

    Console.ReadLine();

}