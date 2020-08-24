using UnityEngine;
using UnityEngine.UI;

public class GameUIFunctionality : BaseFunctionality
{
    [SerializeField] GameObject parent, finishBtn;
    [SerializeField] Button captureBtn;

    public void finishFloorLayout()
    {
        GridManager.isDecidingFloorLayout = false;

        // make the 2d buttons disappear
        Destroy(parent);

        // generate 3d dgrid
        GridManager.createGrid3D();

        // enable furniture picking

        // enable captureBtn
        captureBtn.interactable = true;

        // destroy itself
        Destroy(finishBtn);
    }

    //public void switchScene(int levelNum)
    //{
    //    SceneManager.LoadScene(levelNum);
    //}
}
