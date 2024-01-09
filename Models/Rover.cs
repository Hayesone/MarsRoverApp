
public class Rover {
    public Plateau OperatingArea {get; set;}
    public int X {get; set;}
    public int Y {get; set;}
    public char Direction {get;set;} // Only N/E/S/W
    private readonly char[] headings = new char[] { 'N', 'E', 'S', 'W' };

    public Rover(Plateau plateau, int x, int y, char direction) {
        OperatingArea = plateau;
        X = x;
        Y = y;
        Direction = direction;

        OperatingArea.AddRover(this);
    }

    public string ProcessMovementCommands(char[] commands) {
        foreach (char command in commands) {
            switch (command) {
                case 'R':
                    Rotate(command);
                    break;
                case 'L':
                    Rotate(command);
                    break;
                case 'M':
                    Move();
                    break;
                default:
                    throw new ArgumentException($"Error invalid command: {command}");
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

    // Try to perform move to new location. If move is invalid it doesn't move.
    private void Move() {
        Plateau plateau = OperatingArea;
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
                break;
            case 'E':
                destinationX = originX + 1;
                if (plateau.isValidMove(originX, destinationX)) {
                    X = destinationX;
                    break;
                }
                break;
            case 'S':
                destinationY = originY - 1;
                if (plateau.isValidMove(originX, destinationY)) {
                    Y = destinationY;
                    break;
                }
                break;
            case 'W':
                destinationX = originX - 1;
                if (plateau.isValidMove(originX, destinationX)) {
                    X = destinationX;
                    break;
                }
                break;
            default:
                throw new ArgumentException($"Error invalid heading: {heading}");
        }

    }
}