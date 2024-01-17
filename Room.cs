public class Room
{
    public string Name { get; set; }
    public Dictionary<string, Room> ConnectedRooms = new();
    public Dictionary<string, Func<GameContext, bool>> actions = new();

    public Room(string name)
    {
        Name = name;
    }

    public void ConnectRoom(string direction, Room room)
    {
        ConnectedRooms[direction] = room;
    }

    public void AddAction(string name, Func<GameContext, bool> action)
    {
        actions[name] = action;
    }

    public bool RunAction(string name, GameContext context)
    {
        if (actions.TryGetValue(name, out Func<GameContext, bool>? action))
        {
            if (action == null)
            {
                return false;
            }
            return action(context);
        }
        return false;
    }
}
