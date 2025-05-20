
public class Monster : Creature
{



// Monster AI
    public override void Action(Creature Player)
    {
        // Kan bara heala när de är under helften hp
        if (Health <= MaxHealth / 2)
        {
            if (Random.Shared.Next(0, 2) == 0)
            {
                int Healed = Heal();
                DoDamage(this, Healed);
                if (Health > MaxHealth) Health = MaxHealth;

                Console.WriteLine($"{Name} healed itself for {Healed*-1} HP");
            }
            else
            {
                int Dmg = Attack();
                DoDamage(Player, Dmg);
                Console.WriteLine($"{Name} attacked for {Dmg} damage!");
            }

            Console.ReadLine();
        }
        else
        {
            int Dmg = Attack();
            DoDamage(Player, Dmg);
            Console.WriteLine($"{Name} attacked for {Dmg} damage!");
            Console.ReadLine();
        }
    }
}



// Två typer av monster med olika stats
public class Orc : Monster
{
    public Orc()
    {
        Name = "Orc";
        MyStats["Strength"] = 13;
        MyStats["Health"] = 14;
        MyStats["Ap"] = 11;
        MyStats["Speed"] = 9;

        CalculateStats();
    }
}

public class Goblin : Monster
{
    public Goblin()
    {
        Name = "Goblin";
        MyStats["Strength"] = 10;
        MyStats["Health"] = 10;
        MyStats["Ap"] = 14;
        MyStats["Speed"] = 14;

        CalculateStats();
    }
}

public class Djivan : Monster
{
    public Djivan()
    {
        Name = "Djivan";
        MyStats["Strength"] = 20;
        MyStats["Health"] = 20;
        MyStats["Ap"] = 20;
        MyStats["Speed"] = 20;

        CalculateStats();
    }
}