using UnityEngine;

public class GridViewGenerator : MonoBehaviour
{
    // the singleton of this class
    static GridViewGenerator GVG;

    // the 2D button prefab, its parent, the 3D cube prefab and its parent
    [SerializeField] GameObject tile2D, tile2DParent, tile3D, tile3DParent;

    private void Awake()
    {
        // the singleton is an instance of this class
        GVG = this;
    }

    // instantiates 2D button prefab tile grid
    // the arguments are the size of the grid
    public static void generate2DView(int xDim, int yDim)
    {
        // the position of the 2D parent for better readability
        Vector3Int position = new Vector3Int((int) GVG.tile2DParent.transform.position.x, (int) GVG.tile2DParent.transform.position.y, 0);

        // the uppermost left tile position
        float startPosX = -270f;
        float startPosY = 270f;
        // the offset between the tiles
        // only one since they're squares
        int offset = 36;

        // go through all elements of the underlying grid structure
        for (int i = 0, nr = 0; i < yDim; i++)
        {
            for (int j = 0; j < xDim; j++, nr++)
            {
                // instance's name = i + delimeter + j
                // so internal index can be known via name
                // altough that isn't necessary anymore because of onClick events it's useful to know in the hierarchy
                
                // instantiate prefab
                GameObject tile = Instantiate(GVG.tile2D, position, Quaternion.identity, GVG.tile2DParent.transform);
                // set the local position
                tile.transform.localPosition = new Vector3(startPosX + i * offset, startPosY - j * offset, 0);
                // set it's name
                tile.name = i + "_" + j;

            }
        }
    }

    // generate the 3D grid 
    // the parameters xDim & yDim are the grid size
    public static void createGrid3D(int xDim, int yDim)
    {
        // go through all the elements of the underlying grid structure
        for (int i = 0; i < yDim; i++)
        {
            for (int j = 0; j < xDim; j++)
            {
                // if it's a floor tile instantiate a 3D cube prefab
                if (GridManager.getGridContainer()[i, j].getIsFloor() == true)
                {
                    GameObject tile = Instantiate(GVG.tile3D, new Vector3(i, 0, j), Quaternion.identity, GVG.tile3DParent.transform);
                    // the local position gets slightly mirrored because of the camera rotation
                    tile.transform.localPosition = new Vector3Int(i, 0, -j);
                    // the 3D cube name so the index can be known through a raycast
                    tile.name = i + "_" + j;
                }
            }
        }
    }
}
