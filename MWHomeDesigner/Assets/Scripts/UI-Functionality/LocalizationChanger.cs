using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationChanger : MonoBehaviour
{
    static bool langEng = true;

    [Header("Texts")]
    [SerializeField] List<LocalizationDataType> instances = new List<LocalizationDataType>();

    [Header("Buttons")]
    [SerializeField] GameObject quitEng, quitGer;
    [SerializeField] Button langEngBtn, langGerBtn;
    [SerializeField] Sprite checkUnpressed, checkPressed;

    void Start()
    {
       changeL11(langEng);
    }

    public void changeToEng()
    {
        changeL11(true);
    }

    public void changeToGer()
    {
        changeL11(false);
    }

    void changeL11(bool lang)
    {
        if (lang)
        {
            foreach (LocalizationDataType l in instances)
            {
                l.label.text = l.english;
            }
            // swap sprite
            quitGer.SetActive(false);
            langEngBtn.image.overrideSprite = checkPressed;
            langGerBtn.image.overrideSprite = checkUnpressed;
            langEng = true;
        }
        else
        {
            foreach (LocalizationDataType l in instances)
            {
                l.label.text = l.german;
            }
            // swap sprite
            quitGer.SetActive(true);
            langEngBtn.image.overrideSprite = checkUnpressed;
            langGerBtn.image.overrideSprite = checkPressed;
            langEng = false;
        }
    }
    
}
