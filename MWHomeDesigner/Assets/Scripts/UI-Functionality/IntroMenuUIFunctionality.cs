using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenuUIFunctionality : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject menuCloseButton;
    public void loadScene(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
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
}
