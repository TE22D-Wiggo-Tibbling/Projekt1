
public class Creature
{
    public string Name;

    public int Health = 100;

        
    public int MaxDamage;
    public int MinDamage;
    public int Damage;

    public Dictionary<string, int> myStats = new Dictionary<string, int>();


    // Stats:
    // Strength
    // Speed
    // Health
    // Ap
    public Creature(){
        myStats.Add("Strength", 12);
        myStats.Add("Speed", 12);
        myStats.Add("Health", 12);
        myStats.Add("Ap", 12);
    }

    public int Attack()
    {
        Damage = Random.Shared.Next(MinDamage, MaxDamage);
        return Damage;
    }


}
