using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenuUIFunctionality : MonoBehaviour
{
    public void loadScene(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
