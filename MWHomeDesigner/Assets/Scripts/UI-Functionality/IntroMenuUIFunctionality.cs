using UnityEngine;


public class IntroMenuUIFunctionality : BaseFunctionality
{
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject menuCloseButton;
    [SerializeField] AudioSource buttonClickSound;

    public void playBtnClickSound()
    {
        buttonClickSound.Play();
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

    public void activateSettings()
    {
        settingsUI.SetActive(true);
        menuCloseButton.SetActive(false);
    }

    public void deactivateSettings()
    {
        settingsUI.SetActive(false);
        menuCloseButton.SetActive(true);
        
    }

    
}
