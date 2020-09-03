using UnityEngine;
using UnityEngine.UI;

public class GameUIFunctionality : BaseFunctionality
{
    // the GameObject containing the tile placement tip
    [SerializeField] GameObject tileTip;
    // the main menu
    [SerializeField] GameObject menuUI;
    // the settings menu
    [SerializeField] GameObject settingsUI;
    // the main menu oening button
    [SerializeField] GameObject menuButton;
    // the main menu closing button
    [SerializeField] GameObject menuCloseButton;
    // the parent of the 2D button grid and the check button for finishing the floor layout mode
    [SerializeField] GameObject parent, finishBtn;
    // the button for taking the player into the screenshot scene, disabled before finishing the floor layout mode
    [SerializeField] Button captureBtn;

    // the singleton of this class
    public static GameUIFunctionality GUIF;

    private void Awake()
    {
        // the singleton gets set to an instance of this class
        GUIF = this;
    }

    // for when the player is done with the floor layout mode
    public void finishFloorLayout()
    {
        // make the 2D button grid disappear
        Destroy(parent);
        // generate the 3D dgrid according to the 2D layout
        GridViewGenerator.createGrid3D(GridManager.gridContainerSize.x, GridManager.gridContainerSize.y);
        // enable the screenshot button for going to the screenshot scene
        captureBtn.interactable = true;
        
    }

    // for turning the main menu on and off again
    public void toggleMenu()
    {
        // if the main menu is on turn it off
        if (menuUI.activeSelf)
        {
            // the button for turning it on again gets activated
            menuButton.SetActive(true);
            // the button for closing the menu gets deactivated
            menuCloseButton.SetActive(false);
            // the main menu itself gets turned off
            menuUI.SetActive(false);
        }
        else
        {
            // the button for turning the main menu on gets deactivated
            menuButton.SetActive(false);
            // the button responsible for closing it gets activated
            menuCloseButton.SetActive(true);
            // and the main menu itself gets turned on
            menuUI.SetActive(true);
        }
    }

    // for turning the tool tip off again
    public static void hideTileTip() { GUIF.tileTip.SetActive(false); }

    // for turning the tool tip on again
    public static void showTileTip() { GUIF.tileTip.SetActive(true); }
}
