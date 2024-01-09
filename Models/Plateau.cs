using System.Data;
using MarsRoverApp.Exceptions;

public class Plateau {
    public int Width { get; set; }
    public int Height { get; set; }
    private List<Rover> LandedRovers = new List<Rover>();

    public Plateau(int width, int height) {
        Width = width;
        Height = height;
    }

    public void AddRover(Rover rover) {
        try{
            int landingX = rover.X;
            int landingY = rover.Y;
            bool outOfBounds = isMoveOutOfBounds(landingX, landingY);

            if (outOfBounds) {
                throw new RoverLandingException("Rover: Not safe to land there.");
            }
            foreach (Rover landedRover in LandedRovers) {
                if (landingX == landedRover.X && landingY == landedRover.Y) {
                    throw new RoverLandingException("Rover: Not safe to land on another.");
                }
            }
            LandedRovers.Add(rover);
        } catch (RoverLandingException) {
            Console.WriteLine("It's not safe to land there. Please choose different landing coords 'X Y'.");
            string newCoordsInput = Console.ReadLine();
            var newCoords = newCoordsInput.Split(" ");
            int newX = int.Parse(newCoords[0]);
            int newY = int.Parse(newCoords[1]);
            rover.X = newX;
            rover.Y = newY;
            AddRover(rover);
        }
        
    }

    public bool isMoveOutOfBounds(int newX, int newY) {
        if (newX < 0 || Width < newX) {
            Console.WriteLine("Rover: Cannot go outside the plateau.");
            return true;
        }
        if (newY < 0 || Width < newY) {
            Console.WriteLine("Rover: Cannot go outside the plateau.");
            return true;
        }
        return false; // not out of bounds
    }

    public bool isMoveBlocked(int newX, int newY) {
        foreach (Rover rover in LandedRovers) {
            if (newX == rover.X && newY == rover.Y) {
                Console.WriteLine("Cannot move here, another rover is there!");
                return true;
            }
        }
        return false; // not blocked
    }

    public bool isValidMove(int newX, int newY) {
        bool isBlocked = isMoveBlocked(newX, newY);
        bool isOutOfBounds = isMoveOutOfBounds(newX, newY);

        if (isBlocked || isOutOfBounds) {
            return false;
        } else {
            return true; // valid move
        }
    }
}