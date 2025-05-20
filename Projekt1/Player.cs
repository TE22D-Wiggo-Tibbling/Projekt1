public class Player : Creature
{

   public Class Klass = new();

    public Player()
    {
        Name = "Player";

        MyStats["Strength"] = Klass.Strength;
        MyStats["Health"] = Klass.Health;
        MyStats["Ap"] = Klass.Ap;
        MyStats["Speed"] = Klass.Speed;

        CalculateStats();
    }

    public override void Action(Creature target)
    {

        Console.WriteLine($"What do you want to do");
        Console.WriteLine($"1. Attack  ({MinDamage}-{MaxDamage} Damage)");
        Console.WriteLine($"2. Heal  ({MinHealing}-{MaxHealing} Hp)");

        while (Choice < 1 || Choice > 2)
        {
            while (!int.TryParse(Console.ReadLine(), out Choice))
            {
                Console.WriteLine("1. or 2.");
            }
        }

        if (Choice == 1)
        {
            int dmg;
            dmg = Attack();
            DoDamage(target, dmg);
            Console.WriteLine($"You damage {target} for {dmg}dmg");
        }
        else
        {
            int healing;
            healing = Heal();
            DoDamage(this, healing);
            Console.WriteLine($"you healed yourself for {healing * -1}health");
        }
        Choice = 0;
    }
}

public class Class()
{
    public int Strength;
    public int Health;
    public int Ap;
    public int Speed;
}

public class Fighter : Class
{
    public Fighter()
    {
        Strength = 13;
        Health = 13;
        Ap = 13;
        Speed = 13;
    }
}
public class Tank : Class
{
    public Tank()
    {
        Strength = 10;
        Health = 25;
        Ap = 7;
        Speed = 8;
    }
}
public class Mage : Class
{
    public Mage()
    {
        Strength = 12;
        Health = 8;
        Ap = 18;
        Speed = 10;
    }
}
public class Assasin : Class
{
    public Assasin()
    {
        Strength = 20;
        Health = 10;
        Ap = 10;
        Speed = 20;
    }
}

