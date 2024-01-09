public class Plateau {
    public int Width { get; set; }
    public int Height { get; set; }

    public Plateau(int width, int height) {
        Width = width;
        Height = height;
    }

    public bool isValidMove(int newX, int newY) {
        if (newX < 0 || Width <= newX) {
            return false;
        }
        if (newY < 0 || Width <= newY) {
            return false;
        }
        return true;
    }
}