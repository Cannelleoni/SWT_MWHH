using UnityEngine;

// Model

public class GridManager : MonoBehaviour
{
    static GridManager GM;

    // needs getter & setter
    public static bool isDecidingFloorLayout = true;
    // replace with counter
    public static int tileCounter = 0;

    // uniform, because the underlying grid is a rectangle
    static GridTiles[,] gridContainer;
    // default max size
    public static Vector2Int gridContainerSize { get; } = new Vector2Int(16, 16);

    

    private void Awake()
    {
        GM = this;
    }

    void Start()
    {
        createCustomArray(gridContainerSize.x, gridContainerSize.y);
        GridViewGenerator.generate2DView(gridContainerSize.x, gridContainerSize.y);
        //createGrid3D();

    }

    public static void setTileCounter(int i)
    {
        tileCounter = i;
    }

    public static int getTileCounter()
    {
        return tileCounter;
    }

    public static GridTiles[,] getGridContainer()
    {
        return gridContainer;
    }

    // first preset room & floor layout
    void createPresetArray01(int xDim, int yDim)
    {

    }

    // second preset room & floor layout
    void createPresetArray02(int xDim, int yDim)
    {

    }

    // gets called when game scene is entered for custom floor setup
    // when called use gridContainerSize
    void createCustomArray(int xDim, int yDim)
    {
        gridContainer = new GridTiles[xDim, yDim];

        for(int g = 0; g < xDim; g++)
        {
            for(int h = 0; h < yDim; h++)
            {
                getGridContainer()[g, h] = new GridTiles();
            }
        }
        
    }
    
   
    
}
