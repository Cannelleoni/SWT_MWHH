using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationChanger : MonoBehaviour
{
    // the language to localize to
    static bool langEng = true;

    [Header("Texts")]
    // the translation data can be inserted in the inspector
    // each scene has its own set of translations
    [SerializeField] List<LocalizationDataType> instances = new List<LocalizationDataType>();

    [Header("Buttons")]
    // the appropiate button for quitting the game in german
    [SerializeField] GameObject quitGer;
    // the buttons for changing the language
    [SerializeField] Button langEngBtn, langGerBtn;
    // their button sprites
    [SerializeField] Sprite checkUnpressed, checkPressed;

    void Start()
    {
        // at the beginning the language is set to english
       changeL11(langEng);
    }

    public void changeToEng()
    {
        // the language gets set to english
        changeL11(true);
    }

    public void changeToGer()
    {
        // the language gets set to german
        changeL11(false);
    }

    void changeL11(bool lang)
    {
        if (lang)
        {
            foreach (LocalizationDataType l in instances)
            {
                // all translations described in the inspector get run through
                l.label.text = l.english;
            }
            // the german quit button gets hidden so the english quit button can be seen below
            quitGer.SetActive(false);
            // to signalize wich language button got clicked their sprites change
            langEngBtn.image.overrideSprite = checkPressed;
            langGerBtn.image.overrideSprite = checkUnpressed;
            // language is set to english
            langEng = true;
        }
        else
        {
            foreach (LocalizationDataType l in instances)
            {
                // all translations described in the inspector get run through
                l.label.text = l.german;
            }
            // the german quit button appears so the english quit button can't be seen below
            quitGer.SetActive(true);
            // to signalize wich language button got clicked their sprites change
            langEngBtn.image.overrideSprite = checkUnpressed;
            langGerBtn.image.overrideSprite = checkPressed;
            // language is set to german
            langEng = false;
        }
    }
    
}
