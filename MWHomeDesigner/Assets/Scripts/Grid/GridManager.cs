using UnityEngine;

public class GridManager : MonoBehaviour
{
    // the singleton of this class
    static GridManager GM;
    
    // how many tiles have been placed
    static int tileCounter = 0;

    // uniform, because the underlying grid is a rectangle
    static GridTiles[,] gridContainer;
    // default maximum size of the grid
    public static Vector2Int gridContainerSize { get; } = new Vector2Int(16, 16);


    private void Awake()
    {
        // the singleton gets set to an instance of this class
        GM = this;
    }

    void Start()
    {
        // the grid gets initialized and filled with default values
        createCustomArray(gridContainerSize.x, gridContainerSize.y);
        // the 2D button grid is made
        GridViewGenerator.generate2DView(gridContainerSize.x, gridContainerSize.y);


    }

    // the setter for tileCounter
    public static void setTileCounter(int i) { tileCounter = i; }

    // the getter for tileCounter
    public static int getTileCounter() { return tileCounter; }

    // the getter for gridContainer
    public static GridTiles[,] getGridContainer() { return gridContainer; }
    

    // gets called when game scene is entered for custom floor setup
    // when called use gridContainerSize
    void createCustomArray(int xDim, int yDim)
    {
        // array gets initialized
        gridContainer = new GridTiles[xDim, yDim];

        for(int g = 0; g < xDim; g++)
        {
            for(int h = 0; h < yDim; h++)
            {
                // all elements become an instance of GridTiles
                getGridContainer()[g, h] = new GridTiles();
            }
        }
        
    }
}
