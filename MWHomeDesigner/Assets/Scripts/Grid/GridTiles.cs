
public class GridTiles
{
    int posX = 0;
    int posY = 0;

    bool isOccupied = false;
    bool isFloor = false;

    int rotationY = 0;

    //------------------

    public GridTiles()
    {
        int posX = 0;
        int posY = 0;

        bool isOccupied = false;
        bool isFloor = false;

        int rotationY = 0;
    }

    //------------------

    public void setPosX(int x)
    {
        posX = x;
    }

    public int getPosX()
    {
        return posX;
    }

    //------------------

    public void setPosY(int y)
    {
        posY = y;
    }

    public int getPosY()
    {
        return posY;
    }

    //------------------

    public void setOccupied(bool value)
    {
        isOccupied = value;
    }

    public bool getOccupied()
    {
        return isOccupied;
    }

    //------------------

    public void setIsFloor(bool value)
    {
        isFloor = value;
    }

    public bool getIsFloor()
    {
        return isFloor;
    }

    //------------------

    public void setRotY(int y)
    {
        rotationY = y;
    }

    public int getRotY()
    {
        return rotationY;
    }

}
