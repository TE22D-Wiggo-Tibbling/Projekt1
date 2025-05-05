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

    public new void Action()
    {
        Console.WriteLine("What you wanna do?");
        Console.WriteLine($"1. Attack  ({MinDamage}-{MaxDamage} Damage)");
        Console.WriteLine($"2. Heal  ({MinHealing}-{MaxHealing} Hp)");

        Choice = 0;
        while (Choice < 1 || Choice > 2)
        {
            Console.Write("Enter 1 or 2: ");
            int.TryParse(Console.ReadLine(), out Choice);
        }

        if (Choice == 1)
        {
            int dmg = Attack();
            Console.WriteLine($"You dealt {dmg} damage!");
        }
        else if (Choice == 2)
        {
            int healed = Heal();
            Health += healed;
            if (Health > MaxHealth) Health = MaxHealth;
            Console.WriteLine($"You healed {healed} HP! Current HP: {Health}");
        }
    }
}