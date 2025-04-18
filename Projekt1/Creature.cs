
public class Creature
{
    public string Name;

    public int MaxHealth;
    public int Health = MaxHealth;

    public int MinHealing;
    public int MaxHealing;
        
    public int MaxDamage;
    public int MinDamage;
    public int Damage;

    public Dictionary<string, int> myStats = new Dictionary<string, int>();


 
    public Creature(){
        // Stats
        myStats.Add("Strength", 12);
        myStats.Add("Health", 12);
        myStats.Add("Ap", 12);
        myStats.Add("Speed", 12);

        MinDamage = 3 + myStats["Strength"];    
        MaxDamage = 7 + myStats["Strength"];

        MaxHealth = 50 + myStats["Health"] * 2;

        MinHealing = 2 + myStats["Ap"];
        MaxHealing = 5 + myStats["Ap"];
    }

    public int Attack()
    {
        return Random.Shared.Next(MinDamage, MaxDamage);

    }

    public int Heal()
    {
        return Random.shared.Next(MinHealing, MaxHealing);
    }

    public void Action(){
    if(Health=>Health/2)
    {
    if(random.Shared.next(1,2)=1)
    {
        Heal();
    }
    else
    {
        Attack();
    }
    }
    }


}
