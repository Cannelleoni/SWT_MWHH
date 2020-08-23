using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIFunctionality : MonoBehaviour
{
    [SerializeField] GameObject parent;

    public void finishFloorLayout()
    {
        GridManager.isDecidingFloorLayout = false;

        // make the 2d buttons disappear
        Destroy(parent);



        // generate 3d dgrid
        GridManager.createGrid3D();

        // enable furniture picking

        // destroy itself
        Destroy(gameObject);
    }
}
