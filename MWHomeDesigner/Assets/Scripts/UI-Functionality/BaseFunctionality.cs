using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controller

public class BaseFunctionality : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
    }

    public void loadScene(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void destroyBtn(GameObject go)
    {
        Destroy(go);
    }
}
