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
        int landingX = rover.X;
        int landingY = rover.Y;
        foreach (Rover landedRover in LandedRovers) {
            if (landingX == landedRover.X && landingY == landedRover.Y) {
                throw new RoverLandingException("A rover cannot land on another rover!");
            }
        }
        LandedRovers.Add(rover);
    }

    public bool isMoveOutOfBounds(int newX, int newY) {
        if (newX < 0 || Width <= newX) {
            Console.WriteLine("Rover: Cannot drive off plateau");
            return true;
        }
        if (newY < 0 || Width <= newY) {
            Console.WriteLine("Rover: Cannot drive off plateau");
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