
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



    public Creature()
    {
        // Stats


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

    public virtual void Action()
    {
    }


}
