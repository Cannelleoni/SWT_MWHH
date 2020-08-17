
public class GridTiles
{
    int posX;
    int posY;

    bool isOccupied;
    bool isFloor;

    //------------------

    void setPosX(int x)
    {
        posX = x;
    }

    int getPosX()
    {
        return posX;
    }

    //------------------

    void setPosY(int y)
    {
        posY = y;
    }

    int getPosY()
    {
        return posY;
    }

    //------------------

    void setOccupied(bool value)
    {
        isOccupied = value;
    }

    bool getOccupied()
    {
        return isOccupied;
    }

    //------------------

    void setIsFloor(bool value)
    {
        isFloor = value;
    }

    bool getIsFloor()
    {
        return isFloor;
    }

}
