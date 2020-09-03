public class GridTiles
{
    // is the element a floor element?
    bool isFloor = false;

    // the tiles get instantiated with a default value of false
    public GridTiles() {  bool isFloor = false; }

    // the setter for isFloor
    public void setIsFloor(bool value) { isFloor = value; }

    // the getter for isFloor
    public bool getIsFloor() { return isFloor; }
    
}
