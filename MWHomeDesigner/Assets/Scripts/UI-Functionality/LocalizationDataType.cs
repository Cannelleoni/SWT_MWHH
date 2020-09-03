using UnityEngine;
using UnityEngine.UI;

// so the individual attributes are visible in the inspector
[System.Serializable]
public class LocalizationDataType
{
    // the english translation
    public string german;

    // the german translation
    public string english;

    // the text to change
    public Text label;
}
