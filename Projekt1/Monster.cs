
public class Monster : Creature
{
    public static List<Monster> monsters = new();

    public Monster()
    {
        monsters.Add(this);
        Name = "Monster"; 
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

    public override void Action()
    {
        if (Health >= MaxHealth / 2)
        {
            if (Random.Shared.Next(0, 2) == 0)
            {
                int healed = Heal();
                Health += healed;
                if (Health > MaxHealth) Health = MaxHealth;

                Console.WriteLine($"{Name} healed itself for {healed} HP");
            }
            else
            {
                int dmg = Attack();
                Console.WriteLine($"{Name} attacked for {dmg} damage!");
            }

            ActionPoint--;
            Console.ReadLine();
        }
        else
        {
            int healed = Heal();
            Health += healed;
            if (Health > MaxHealth) Health = MaxHealth;

            Console.WriteLine($"{Name} is weak and healed for {healed} HP");
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
        myStats["Strength"] = 13;
        myStats["Health"] = 14;
        myStats["Ap"] = 11;
        myStats["Speed"] = 10;

        CalculateStats();
    }
}

public class Goblin : Monster
{
    public Goblin()
    {
        Name = "Goblin";
        myStats["Strength"] = 10;
        myStats["Health"] = 10;
        myStats["Ap"] = 14;
        myStats["Speed"] = 14;

        CalculateStats();
    }
}