
public class Rover {
    public int X {get; set;}
    public int Y {get; set;}
    public char Direction {get;set;} // Only N/E/S/W

    public Rover(int x, int y, char direction) {
        X = x;
        Y = y;
        Direction = direction;
    }

    internal object Move(char[] roverCommands)
    {
        throw new NotImplementedException();
    }
}