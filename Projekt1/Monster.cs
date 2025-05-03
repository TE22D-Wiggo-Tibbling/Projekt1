
public class Monster : Creature
{
    public static List<Monster> monsters = new();
    public Monster()
    {
        monsters.Add(this);

        Name = "Monster";

        MaxDamage = 10;
        MinDamage = 5;
    }

    public virtual void Update()
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

    public void Action()
    {
        if (Health >= Health / 2)
        {
            if (Random.Shared.Next(1, 2) == 1)
            {
                Heal();
                Console.WriteLine($"{Name} heald itself for {Heal}hp");

            }
            else
            {
                Attack();
                Console.WriteLine($"{Name} Attacked you for {Attack}damage");
            }
            ActionPoint--;
            Console.ReadLine();
            
        }
    }
}




public class Orc : Monster
{
    public Orc()
    {
        Name = "Orc";
        myStats.Add("Strength", 13);
        myStats.Add("Health", 14);
        myStats.Add("Ap", 11);
        myStats.Add("Speed", 10);
    }
}

public class Goblin : Monster
{
    public Goblin()
    {
        Name = "Goblin";
        myStats.Add("Strength", 10);
        myStats.Add("Health", 10);
        myStats.Add("Ap", 14);
        myStats.Add("Speed", 14);
    }
}
