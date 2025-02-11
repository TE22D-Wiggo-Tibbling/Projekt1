public class Player : Creature
{
    public Player()
    {
        Name = "Player";
        MaxDamage = 20;
        MinDamage = 10;
    }
}

public class Monster : Creature
{
    public static List<Monster> monsters = new();
    public Monster()
    {
        monsters.Add(this);

        Name = "Monster";

        MaxDamage = 20;
        MinDamage = 10;
    }

    void Update()
    {

    }

    public static void CheckDeath()
    {
        monsters.RemoveAll(m => m.Health <= 0);
    }

    public static void UpdateAll()
    {
        monsters.ForEach(m => m.Update());
        CheckDeath();

    }
}
