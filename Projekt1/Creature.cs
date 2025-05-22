public class Creature
{

    // Namn
    public string Name { get; protected set; }

    // Max Hp
    protected int MaxHealth;

    // Nuvarande HP
    public int Health { get; protected set; }
    // Minsta man kan heala
    protected int MinHealing;
    // Högsta man kan heala
    protected int MaxHealing;

    // Högsta man kan skada
    protected int MaxDamage;
    // Minsta man kan skada
    protected int MinDamage;
    // Damagen man gör
    protected int Damage;

    // Vapnet man använder
    protected Wepon Weapon = new();

    // Används för att sätta stats
    public Dictionary<string, int> MyStats { get; protected set; } = new Dictionary<string, int>();

    // Valen som görs
    protected int Choice;


    public void CalculateStats()
    {
        // Calculera vad statsen gör
        MinDamage = 3 + MyStats["Strength"]+ Weapon.AdditionalDamage;
        MaxDamage = 7 + MyStats["Strength"]+ Weapon.AdditionalDamage;

        MaxHealth = 50 + MyStats["Health"] * 2;
        Health = MaxHealth;

        MinHealing = 2 + MyStats["Ap"];
        MaxHealing = 5 + MyStats["Ap"];
    }

    protected int Attack()
    {
        // Sätter spelarens damage
        return Random.Shared.Next(MinDamage, MaxDamage);
    }

    protected int Heal()
    {
        // Negativ för att heala
        return -Random.Shared.Next(MinHealing, MaxHealing);
    }

    public void DoDamage(Creature target, int damage)
    {
        // Göra damage/heala den man valde
        target.Health -= damage;
    }

    // Att välja vad man gör
    // Delas up på spelare och monster
    public virtual void Action(Creature target)
    {
    }


}