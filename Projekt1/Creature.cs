
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

    public int Heal()
    {
        Healing = Random.shared.Next(MinHealing, MaxHealing);
        return Healing
    }

    public void Action(){
    if(Health=>Health/2)
    {
    if(random.Shared.next(1,2)=1)
    {
        Health++
    }
    else
    {
        random.shared.next(1,3)
    }
    }
    }


}
