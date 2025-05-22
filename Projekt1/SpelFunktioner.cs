using System.Threading.Channels;

public class GameFunktions
{
    private int Uppgradepoints = 3;
    // Att välja Class
    public void SetClass(Player player1)
    {
        // Gör lista med alla klasser
        List<Class> Allclasses = new();
        Allclasses.Add(new Fighter());
        Allclasses.Add(new Mage());
        Allclasses.Add(new Assasin());
        Allclasses.Add(new Tank());

        int Choise = 0;

        // De alternativen som finns
        Console.WriteLine("Chose Class:");
        Console.WriteLine("1. Fighter");
        Console.WriteLine("2. Mage");
        Console.WriteLine("3. Assasin");
        Console.WriteLine("4. Tank");


        // Så man inte kan svara fel
        while (Choise < 1 || Choise > 4)
        {

            while (!int.TryParse(Console.ReadLine(), out Choise))
            {
                Console.WriteLine("Chose a class");
            }
        }
        // Sätter spelarens klass beroende på dens val
        for (int i = 0; i < 5; i++)
        {
            if (Choise == i)
            {
                player1.CharClass = Allclasses[i - 1];
            }
        }

        // Man uppgraderar medans man har poäng
        while (Uppgradepoints > 0)
        {
            // Resetar spelarens val
            Choise = 0;

            // Förklara för spelaren vad de ska göra
            Console.WriteLine($"What stats do you want to uppgrade?");
            Console.WriteLine($"You have {Uppgradepoints} points left");

            Console.WriteLine("1. Strength");
            Console.WriteLine("2. Ap");
            Console.WriteLine("3. health");
            Console.WriteLine("4. Speed");


            // Så man inte kan svara fel
            while (Choise < 1 || Choise > 4)
            {
                while (!int.TryParse(Console.ReadLine(), out Choise))
                {
                    Console.WriteLine("Chose a class");
                }
            }

            // Lägger till poäng på det man har valt
            if (Choise == 1) { player1.CharClass.Strength += 1; }
            if (Choise == 2) { player1.CharClass.Ap += 1; }
            if (Choise == 3) { player1.CharClass.Health += 1; }
            if (Choise == 4) { player1.CharClass.Speed += 1; }

            Uppgradepoints--;


        }
        // Sätter spelarens stats efter valt class och uppgraderat
        player1.SetStats();

    }


    public void Game(Creature player, List<Monster> monsters)
    {

        // Instruktioner om hur spelet fungerar
        Console.WriteLine("You will fight against 1-3 monsters");
        Console.WriteLine("To make a choise of action pic one of the numbers that will be depicted");
        Console.WriteLine("You will be able to attack a monster or heal yourself");
        Console.WriteLine("Dont die");
        Console.ReadLine();
        Console.Clear();

        // Medans spelaren är vid liv och det finns monster
        while (player.Health > 0 && monsters.Count > 0)
        {

            // Årdningen av Action

            //    Sorterar beroende på ett tall som i detta fall är fart
            PriorityQueue<Creature, int> queue = new PriorityQueue<Creature, int>();

            // Sätter in spelaren
            queue.Enqueue(player, 20 - player.MyStats["Speed"]);


            // Sätter in alla monster
            foreach (Monster monsteris in monsters)
            {
                queue.Enqueue(monsteris, 20 - monsteris.MyStats["Speed"]);
            }

            // Listan över när de ska göra sina saker
            List<Creature> battleQueue = new();


            // tar från toppen och sätter in i battle queue
            while (queue.Count > 0)
            {
                battleQueue.Add(queue.Dequeue());
            }

            // Skriver alla varelser
            Console.WriteLine($"{monsters[0].Name}>{monsters[0].Health}  |  {player.Health}<{player.Name}");
            for (int i = 0; i < monsters.Count - 1; i++)
            {
                Console.WriteLine($"{monsters[i + 1].Name}>{monsters[i + 1].Health}");
            }


            // Gör deras Action beroende på arv
            foreach (Creature creature in battleQueue)
            {
                // Om varelsen är ett monster
                if (creature is Monster)
                {
                    creature.Action(player);
                }
                // Om det är en spelare
                else
                {

                    Console.WriteLine("Who you want to attack");

                    // Skriver up alla monster med deras HP
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {monsters[i].Name}>{monsters[i].Health}");
                    }

                    // Bestämmer vem man ska attakera
                    int choice = 0;
                    while (choice < 1 || choice > monsters.Count)
                    {
                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("Write one of the options");
                        }
                    }

                    creature.Action(monsters[choice - 1]);


                }
                // När monster dör tas de bort från listan
                monsters.RemoveAll(m => m.Health <= 0);
            }
            // Reset efter rundan
            Console.ReadLine();
            Console.Clear();
        }


        // Om man vinner eller förlorar
        if (player.Health <= 0)
        {
            Console.WriteLine("You died");
            Console.ReadLine();
            Environment.Exit(0);

        }
        if (monsters.Count == 0)
        {
            Console.WriteLine("You win!");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }

}

