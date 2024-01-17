public class GameContext
{
    public Dictionary<string, bool> flags = new();
    public Room CurrentRoom { get; set; }

    public GameContext(Room currentRoom)
    {
        CurrentRoom = currentRoom;
    }

    public bool GetFlag(string name)
    {
        if (flags.TryGetValue(name, out bool flag))
        {
            return flag;
        }
        return false;
    }

    public void SetFlag(string name, bool value)
    {
        flags[name] = value;
    }
}