public class Game
{
    public void Run(Room currentRoom)
    {
        Console.Clear();
        GameContext context = new GameContext(currentRoom);
        Console.ForegroundColor = ConsoleColor.White;
        currentRoom.RunAction("examine", context);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("> ");
            string val = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (val.Length == 1)
            {
                if (currentRoom.ConnectedRooms.TryGetValue(val, out Room nextRoom))
                {
                    currentRoom = nextRoom;
                    currentRoom.RunAction("examine", context);
                }
                else
                {
                    Console.WriteLine("You can't walk that way!");
                }
            }
            else if (val.Length > 1)
            {
                if (currentRoom.RunAction(val, context))
                {
                    continue;
                }
                Console.WriteLine("You can't do that!");

            }
        }
    }
}