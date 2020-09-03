using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteSwap : MonoBehaviour
{
    // the argument gets it's sprite changed to "tileFilled"
    public static void buttonFilled(GameObject go) { go.GetComponent<Button>().image.overrideSprite = Resources.Load<Sprite>("tileFilled"); }

    // the argument gets it's sprite changed to "tileUnfilled"
    public static void buttonNotFilled(GameObject go) {  go.GetComponent<Button>().image.overrideSprite = Resources.Load<Sprite>("tileUnfilled"); }
}
