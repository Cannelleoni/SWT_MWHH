using UnityEngine;
using UnityEngine.UI;

public class GameUIFunctionality : BaseFunctionality
{
    [SerializeField] GameObject tileTip;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject menuCloseButton;
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

    public void toggleMenu()
    {
        if (menuUI.activeSelf)
        {
            menuButton.SetActive(true);
            menuCloseButton.SetActive(false);
            menuUI.SetActive(false);
        }
        else
        {
            menuButton.SetActive(false);
            menuCloseButton.SetActive(true);
            menuUI.SetActive(true);
        }
    }

    public void hideTileTip()
    {
        tileTip.SetActive(false);
    }

    public void showTileTip()
    {
        tileTip.SetActive(true);
    }

    //public void switchScene(int levelNum)
    //{
    //    SceneManager.LoadScene(levelNum);
    //}
}
