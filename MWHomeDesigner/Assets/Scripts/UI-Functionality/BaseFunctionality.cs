using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseFunctionality : MonoBehaviour
{
    // the player can quit the build game
    public void quitGame() { Application.Quit(); }

    // the level specified by the build index gets loaded
    public void loadScene(int levelToLoad) { SceneManager.LoadScene(levelToLoad); }

    // the given GameObject gets destroyed by á button through an onclick event
    public void destroyBtn(GameObject go) { Destroy(go);  }
}
