namespace MarsRoverApp;

class Program {
    static void Main(string[] args) {
        
        Console.WriteLine("Enter the width and height of the plateau e.g. 'X Y':");
        var plateauInput = PlateauInput(Console.ReadLine());
        var plateauWidth = plateauInput.Item1;
        var plateauHeight = plateauInput.Item2;
        Plateau plateau = new Plateau(plateauWidth, plateauHeight);

        Console.WriteLine("Enter Rover starting position and heading e.g. 'X Y D':");
        var roverLandInput = RoverLandInput(Console.ReadLine());
        var roverX = roverLandInput.Item1;
        var roverY = roverLandInput.Item2;
        var roverDirection = roverLandInput.Item3;
        Rover rover = new Rover(roverX, roverY, roverDirection);

        Console.WriteLine("Enter in movement commands for Rover e.g. 'LLMLMLRRLM':");
        var roverCommands = RoverCommandsInput(Console.ReadLine());
        var roverEndPosition = rover.Move(roverCommands);
        

        
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