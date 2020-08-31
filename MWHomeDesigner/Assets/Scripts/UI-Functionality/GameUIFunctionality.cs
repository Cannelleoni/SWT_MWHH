using UnityEngine;
using UnityEngine.UI;

// Controller

public class GameUIFunctionality : BaseFunctionality
{
    [SerializeField] GameObject tileTip;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject menuCloseButton;
    [SerializeField] GameObject parent, finishBtn;
    [SerializeField] Button captureBtn;

    public static GameUIFunctionality GUIF;

    private void Awake()
    {
        GUIF = this;
    }

    public void finishFloorLayout()
    {
        GridManager.isDecidingFloorLayout = false;

        // make the 2d buttons disappear
        Destroy(parent);

        // generate 3d dgrid
        GridViewGenerator.createGrid3D(GridManager.gridContainerSize.x, GridManager.gridContainerSize.y, Resources.Load<GameObject>("tile3D"), Resources.Load<GameObject>("3DGridContainer"));

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

    public static void hideTileTip()
    {
        GUIF.tileTip.SetActive(false);
    }

    public static void showTileTip()
    {
        GUIF.tileTip.SetActive(true);
    }
}
