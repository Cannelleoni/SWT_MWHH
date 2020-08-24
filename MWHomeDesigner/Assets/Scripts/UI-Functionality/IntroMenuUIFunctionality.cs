using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenuUIFunctionality : BaseFunctionality
{
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject menuCloseButton;
    [SerializeField] AudioSource buttonClickSound;

    public void loadScene(int levelToLoad)
    {
        buttonClickSound.Play();
        SceneManager.LoadScene(levelToLoad);
    }

    public void toggleMenu()
    {
        buttonClickSound.Play();
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
        buttonClickSound.Play();
        settingsUI.SetActive(true);
        menuCloseButton.SetActive(false);
    }

    public void deactivateSettings()
    {
        buttonClickSound.Play();
        settingsUI.SetActive(false);
        menuCloseButton.SetActive(true);
        
    }

    public void quitGame()
    {
        buttonClickSound.Play();
        Application.Quit();
    }
}
