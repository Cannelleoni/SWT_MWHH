using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// View

public class ButtonSpriteSwap : MonoBehaviour
{
    public static void buttonFilled(GameObject go)
    {
        go.GetComponent<Button>().image.overrideSprite = Resources.Load<Sprite>("tileFilled");
    }

    public static void buttonNotFilled(GameObject go)
    {
        go.GetComponent<Button>().image.overrideSprite = Resources.Load<Sprite>("tileUnfilled");
    }
}
