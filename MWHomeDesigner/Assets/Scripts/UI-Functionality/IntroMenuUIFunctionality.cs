using UnityEngine;

public class IntroMenuUIFunctionality : BaseFunctionality
{
    // the main menu
    [SerializeField] GameObject menuUI;
    // the settings menu
    [SerializeField] GameObject settingsUI;
    // the main menu open button
    [SerializeField] GameObject menuButton;
    // the main menu close button
    [SerializeField] GameObject menuCloseButton;

    // for turning the main menu on and off again
    public void toggleMenu()
    {
        // if the main menu is already active turn it off
        if (menuUI.activeSelf)
        {
            // the button for turning it back on gets activated
            menuButton.SetActive(true);
            // the closing button gets deactivated
            menuCloseButton.SetActive(false);
            // the menu itself gets deactivated
            menuUI.SetActive(false);
        }
        else
        {
            // the button for turning it on gets deactivated
            menuButton.SetActive(false);
            // the button for closing the menu gets activated
            menuCloseButton.SetActive(true);
            // the menu itself turns on
            menuUI.SetActive(true);
        }
    }

    // the settings menu gets activated
    public void activateSettings()
    {
        // the settings menu itself gets activated
        settingsUI.SetActive(true);
        // the main menu closing button gets deactivated as not to hide the settings menu closing button
        menuCloseButton.SetActive(false);
    }

    // the settings menu gets turned off
    public void deactivateSettings()
    {
        // the settings menu itself gets turned off
        settingsUI.SetActive(false);
        // the main menu closing button becomes visible
        menuCloseButton.SetActive(true);
        
    }

    
}
