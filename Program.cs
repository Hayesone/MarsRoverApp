namespace MarsRoverApp;

class Program {
    static void Main(string[] args) {
        
    }

    public static (int, int) PlateauInput(string plateauCoords) {
        var plateauInput = plateauCoords.Split(" ");
        int x = int.Parse(plateauInput[0]);
        int y = int.Parse(plateauInput[1]);
        return (x, y);
    }

    public static (int, int, char) RoverLandInput(string roverPositon) {
        var roverInput = roverPositon.Split(" ");
        int x = int.Parse(roverInput[0]);
        int y = int.Parse(roverInput[1]);
        char direction = char.Parse(roverInput[2]);
        return (x, y, direction);
    }
    
    public static char[] RoverCommandsInput(string commandString) {
        char[] commands = commandString.ToCharArray();
        return commands;
    }

}