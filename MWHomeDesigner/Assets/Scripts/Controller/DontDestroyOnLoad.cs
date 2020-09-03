using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the GameObject with this component will be present in the next scene
public class DontDestroyOnLoad : MonoBehaviour
{
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
