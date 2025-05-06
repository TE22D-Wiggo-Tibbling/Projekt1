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


    public Dictionary<string, int> MyStats = new Dictionary<string, int>();

    public int Choice;


    public void CalculateStats()
    {
        // Calculera vad statsen gör
        MinDamage = 3 + MyStats["Strength"];
        MaxDamage = 7 + MyStats["Strength"];

        MaxHealth = 50 + MyStats["Health"] * 2;
        Health = MaxHealth;

        MinHealing = 2 + MyStats["Ap"];
        MaxHealing = 5 + MyStats["Ap"];
    }

    public int Attack()
    {
        return Random.Shared.Next(MinDamage, MaxDamage);
    }

    public int Heal()
    {
        // Negativ för att heala
        return -Random.Shared.Next(MinHealing, MaxHealing);
    }

    public void DoDamage(Creature target, int damage)
    {
        // Göra damage/heala den man vill
        target.Health -= damage;
    }

// Att välja vad man gör
// Delas up på spelare och monster
    public virtual void Action(Creature target)
    {
    }


}