public class Creature
{
    public string Name { get; protected set; }

    protected int MaxHealth;
    public int Health { get; protected set; }

    protected int MinHealing;
    protected int MaxHealing;

    protected int MaxDamage;
    protected int MinDamage;
    protected int Damage;

    protected Wepon wepon = new();


    public Dictionary<string, int> MyStats { get; protected set; } = new Dictionary<string, int>();

    protected int Choice;


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

    protected int Attack()
    {
        return Random.Shared.Next(MinDamage, MaxDamage) + wepon.AdditionalDamage;
    }

    protected int Heal()
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