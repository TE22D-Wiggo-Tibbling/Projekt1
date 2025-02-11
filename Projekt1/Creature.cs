
public class Creature
{
    public string Name;

    public int Health = 100;

    public int MaxDamage;
    public int MinDamage;
    public int Damage;


    public int Attack()
    {
        Damage = Random.Shared.Next(MinDamage, MaxDamage);
        return Damage;
    }
}
