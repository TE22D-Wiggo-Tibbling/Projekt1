public class Player : Creature
{
    int Choice;
    public Player()
    {
        Name = "Player";
        MaxDamage = 20;
        MinDamage = 10;
    }

    public void Action()
    {
        Console.WriteLine("What you wanna do?");
        Console.WriteLine($"1. Attack  ({MinDamage}-{MaxDamage} Damage)");
        Console.WriteLine($"2. Heal  ({MinHealing}-{MaxHealing} Hp)");

        
        while (Choice >= 1 && Choice <= 2)
        {
            int.TryParse(Console.ReadLine(), out Choice);
        }
        if (Choice == 1)
        {
            Attack();
        }
        else if (Choice == 2)
        {
            Heal();
        }
    }
}

