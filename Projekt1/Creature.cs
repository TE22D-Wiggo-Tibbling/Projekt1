public class Creature
{
    public string Name;

    public int MaxHealth;
    public int Health;

    public int MinHealing;
    public int MaxHealing;

    public int MaxDamage;
    public int MinDamage;
    public int Damage;

    public int ActionPoint;

    public Dictionary<string, int> myStats = new Dictionary<string, int>();

    public int choice;


    public Creature()
    {
    }

    public void CalculateStats()
    {
        MinDamage = 3 + myStats["Strength"];
        MaxDamage = 7 + myStats["Strength"];

        MaxHealth = 50 + myStats["Health"] * 2;
        Health = MaxHealth;

        MinHealing = 2 + myStats["Ap"];
        MaxHealing = 5 + myStats["Ap"];
    }

    public int Attack()
    {
        return Random.Shared.Next(MinDamage, MaxDamage);
    }

    public int Heal()
    {
        return Random.Shared.Next(MinHealing, MaxHealing);
    }

    public void Target(Creature target, int damage)
    {
        target.Health -= damage;
    }

    public virtual void Action(Creature target)
    {
        Console.WriteLine($"What do you want to do");
        Console.WriteLine($"1. Attack");
        Console.WriteLine($"2. Heal");

        while (choice < 1 || choice > 2)
        {
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("1. or 2.");
            }
        }

        if (choice == 1)
        {
            int dmg;
            dmg = Attack();
            Target(target, dmg);
            Console.WriteLine($"You damage {target} for {dmg}dmg");
        }
        else
        {
            int healing;
            healing = Heal();
            Target(this, healing);
            Console.WriteLine($"you healed yourself for {healing}health");
        }
        choice=0;
    }


}