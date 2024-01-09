
public class Rover {
    public int X {get; set;}
    public int Y {get; set;}
    public char Direction {get;set;} // Only N/E/S/W
    private readonly char[] headings = new char[] { 'N', 'E', 'S', 'W' };

    public Rover(int x, int y, char direction) {
        X = x;
        Y = y;
        Direction = direction;
    }

    public string ProcessMovementCommands(Plateau plateau, char[] commands) {
        foreach (char command in commands) {
            switch (command) {
                case 'R':
                    Rotate(command);
                    break;
                case 'L':
                    Rotate(command);
                    break;
                case 'M':
                    Move(plateau);
                    break;
                default:
                    break; // Catch errors
            }
        }
        return $"{X} {Y} {Direction}";
    }

    private void Rotate(char rotation) {
        int currentIndex = Array.IndexOf(headings, Direction);
        if (rotation == 'R') {
            // Rotate clockwise
            Direction = headings[(currentIndex + 1) % headings.Length];
        } else if (rotation == 'L') {
            // Rotate anti-clockwise
            Direction = headings[(currentIndex - 1 + headings.Length) % headings.Length];
        }
    }

    // Try to perform move to new location.
    private void Move(Plateau plateau) {
        int originX = X;
        int originY = Y;
        int heading = Direction;
        int destinationY;
        int destinationX;

        switch (heading) {
            case 'N':
                destinationY = originY + 1;
                if (plateau.isValidMove(originX, destinationY)) {
                    Y = destinationY;
                    break;
                }
                Console.WriteLine("Rover: Cannot drive off plateau");
                break; // Need to catch errors
            case 'E':
                destinationX = originX + 1;
                if (plateau.isValidMove(originX, destinationX)) {
                    X = destinationX;
                    break;
                }
                Console.WriteLine("Rover: Cannot drive off plateau");
                break; // Need to catch errors
            case 'S':
                destinationY = originY - 1;
                if (plateau.isValidMove(originX, destinationY)) {
                    Y = destinationY;
                    break;
                }
                Console.WriteLine("Rover: Cannot drive off plateau");
                break; // Need to catch errors
            case 'W':
                destinationX = originX - 1;
                if (plateau.isValidMove(originX, destinationX)) {
                    X = destinationX;
                    break;
                }
                Console.WriteLine("Rover: Cannot drive off plateau");
                break; // Need to catch errors
            default:
                break; // Need to catch errors
        }

    }
}