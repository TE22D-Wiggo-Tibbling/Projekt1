
public class Monster : Creature
{
    public static List<Monster> monsters = new();
    public Monster()
    {
        monsters.Add(this);

        Name = "Monster";

        MaxDamage = 10;
        MinDamage = 5;
    }

    public virtual void Update()
    {

    }

    public static void CheckDeath()
    {
        monsters.RemoveAll(m => m.Health <= 0);
    }

    public static void UpdateAll()
    {
        monsters.ForEach(m => m.Update());
        CheckDeath();

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


public class Orc : Monster{

}

public class Goblin : Monster{
    
}
