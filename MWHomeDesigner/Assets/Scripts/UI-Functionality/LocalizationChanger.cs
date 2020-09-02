using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationChanger : MonoBehaviour
{
    static bool langEng = true;

    [SerializeField] LocalizationDataType[] instances;
    [SerializeField] GameObject quitEng, quitGer;

    void Start()
    {
       // changeL11(langEng);
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
            langEng = false;
        }
    }
    
}
