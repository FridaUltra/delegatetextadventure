public class Content
{
    public static Room CreateGame()
    {
        Room inside = new Room("Inside house");
        inside.AddAction("examine", (context) =>
        {
            Console.WriteLine("You are in a room. There is a door to the south and a hidden hatch under the carpet.");
            return true;
        });

        Room garden = new Room("Garden");
        garden.AddAction("examine", (context) =>
        {
            string lighterStatus = context.GetFlag("lighterTaken") ? "" : " There is a lighter on the ground.";
            Console.WriteLine("You are in a garden. There is a door to the north." + lighterStatus);
            return true;
        });
        garden.AddAction("get", (context) =>
        {
            if (context.GetFlag("lighterTaken"))
            {
                Console.WriteLine("You already took the lighter!");
                return false;
            }
            Console.WriteLine("You take the lighter.");
            context.SetFlag("lighterTaken", true);
            return true;
        });

        Room cellar = new Room("Cellar");
        cellar.AddAction("examine", (context) =>
        {
            if (context.GetFlag("lighterOn"))
            {
                Console.WriteLine("You are in a cellar. Above you is a trapdoor. In front of you is a chest.");
            }
            else
            {
                Console.WriteLine("You are in a pitch black room. You can't see anything.");
            }
            return true;
        });
        cellar.AddAction("use lighter", (context) =>
        {
            if (context.GetFlag("lighterOn"))
            {
                Console.WriteLine("You stop using the lighter.");
                context.SetFlag("lighterOn", false);
                return false;
            }
            if (!context.GetFlag("lighterTaken"))
            {
                Console.WriteLine("You don't have a lighter!");
                return false;
            }
            Console.WriteLine("You light the lighter.");
            context.SetFlag("lighterOn", true);
            return true;
        });

        inside.ConnectRoom("s", garden);
        inside.ConnectRoom("d", cellar);
        garden.ConnectRoom("n", inside);
        cellar.ConnectRoom("u", inside);

        return inside;
    }
}