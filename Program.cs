namespace MarsRoverApp;

class Program {
    static void Main(string[] args) {
        
        var plateauInput = PlateauInput();
        var plateauWidth = plateauInput.Item1;
        var plateauHeight = plateauInput.Item2;
        Plateau plateau = new Plateau(plateauWidth, plateauHeight);

        List<string> roverOutcomes = new List<string>(); // List to store rover outcomes

        while (true) {
            var roverLandInput = RoverLandInput();
            var roverX = roverLandInput.Item1;
            var roverY = roverLandInput.Item2;
            var roverDirection = roverLandInput.Item3;
            Rover rover = new Rover(plateau, roverX, roverY, roverDirection);

            var roverCommands = RoverCommandsInput();
            var roverEndPosition = rover.ProcessMovementCommands(roverCommands);

            roverOutcomes.Add(roverEndPosition);

            Console.WriteLine("If you would like to land another rover press enter, else type 'done'");
            if (Console.ReadLine() == "done") {
                break;
            }
        }

        Console.WriteLine("Rover locations and headings:");
        foreach (var outcome in roverOutcomes) {
            Console.WriteLine(outcome);
        }

        Console.ReadLine(); // Temp break before close
    }

    // Currently assuming all inputs are in the correct format.
    public static (int, int) PlateauInput() {
        try {
            Console.WriteLine("Enter the width (X) and height (Y) of the plateau e.g. 'X Y':");
            string plateauCoords = Console.ReadLine();
            var plateauInput = plateauCoords.Split(" ");
            int x = int.Parse(plateauInput[0]);
            int y = int.Parse(plateauInput[1]);
            return (x, y);
        } catch (FormatException) {
            Console.WriteLine("Invalid format. Please enter with format 'X Y' e.g. '10 5'");
            return PlateauInput();
        } catch (Exception e) {
            Console.WriteLine($"An error occurred: {e.Message}");
            return PlateauInput();
        }
    }

    public static (int, int, char) RoverLandInput() {
        try {
            Console.WriteLine("Enter Rover starting position and heading e.g. 'X Y D':");
            string roverPositon = Console.ReadLine();
            var roverInput = roverPositon.Split(" ");
            int x = int.Parse(roverInput[0]);
            int y = int.Parse(roverInput[1]);
            char direction = char.Parse(roverInput[2]);
            return (x, y, direction);
        } catch (FormatException) {
            Console.WriteLine("Invalid format. Please enter with format 'X Y D' e.g. '4 5 N'");
            return RoverLandInput();
        } catch (Exception e) {
            Console.WriteLine($"An error occurred: {e.Message}");
            return RoverLandInput();
        }
    }
    
    public static char[] RoverCommandsInput() {
        
        try {
            Console.WriteLine("Enter in movement commands ('L','R','M') for Rover e.g. 'LLMLMLRRLM':");
            string commandString = Console.ReadLine();
            char[] commands = commandString.ToCharArray();

            foreach (char command in commands) {
                if (command == 'L' || command == 'M' || command == 'R') {
                    continue;
                } else {
                    throw new FormatException();
                }
            }
            return commands;
        } catch (FormatException) {
            Console.WriteLine("Invalid format. Please enter with commands 'L','R' or 'M'.");
            return RoverCommandsInput();
        } catch (Exception e) {
            Console.WriteLine($"An error occurred: {e.Message}");
            return RoverCommandsInput();
        }
    }

}            

