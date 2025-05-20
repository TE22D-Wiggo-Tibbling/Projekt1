public class Player : Creature
{
    // Klass här för monster inte använder det
    public Class Klass = new();

    // Flyttat att sätta statsen för man ska kunna välja klass
    public Player()
    {
        Name = "Player";
    }

    // Använder detta för att räkna stats efter välja klass
    public void SetStats()
    {
        MyStats["Strength"] = Klass.Strength;
        MyStats["Health"] = Klass.Health;
        MyStats["Ap"] = Klass.Ap;
        MyStats["Speed"] = Klass.Speed;

        CalculateStats();
    }

    // Det spelaren gör
    public override void Action(Creature target)
    {

        Console.WriteLine($"What do you want to do");
        // Skriva hur mycket damage
        Console.WriteLine($"1. Attack  ({MinDamage}-{MaxDamage} Damage)");
        // Skriva hur mycket healing
        Console.WriteLine($"2. Heal  ({MinHealing}-{MaxHealing} Hp)");

        // Så att man inte kan svara med ett ogiltigt svar
        while (Choice < 1 || Choice > 2)
        {
            while (!int.TryParse(Console.ReadLine(), out Choice))
            {
                Console.WriteLine("1. or 2.");
            }
        }

        // Om man attakerar
        if (Choice == 1)
        {
            int dmg;
            dmg = Attack();
            DoDamage(target, dmg);
            Console.WriteLine($"You damage {target} for {dmg}dmg");
        }
        // Om man healar
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

// Förälder klass
public class Class()
{
    public int Strength;
    public int Health;
    public int Ap;
    public int Speed;
}

// Fighter SubClass
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
// Tank SubClass
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
// Mage SubClass
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
// Assasin SubClass
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

