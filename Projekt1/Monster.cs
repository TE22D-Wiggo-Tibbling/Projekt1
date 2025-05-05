
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




    public override void Action(Creature player)
    {
        if (Health <= MaxHealth / 2)
        {
            if (Random.Shared.Next(0, 2) == 0)
            {
                int healed = Heal();
                Target(this, healed);
                if (Health > MaxHealth) Health = MaxHealth;

                Console.WriteLine($"{Name} healed itself for {healed} HP");
            }
            else
            {
                int dmg = Attack();
                Target(player, dmg);
                Console.WriteLine($"{Name} attacked for {dmg} damage!");
            }

            ActionPoint--;
            Console.ReadLine();
        }
        else
        {
            int dmg = Attack();
            Target(player, dmg);
            Console.WriteLine($"{Name} attacked for {dmg} damage!");
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
        myStats["Speed"] = 9;

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