public class Player : Creature
{



    public Player()
    {
        Name = "Player";

        MyStats["Strength"] = 10;
        MyStats["Health"] = 25;
        MyStats["Ap"] = 12;
        MyStats["Speed"] = 10;

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
            Console.WriteLine($"you healed yourself for {healing*-1}health");
        }
        Choice=0;
    }
}