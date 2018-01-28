using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuFade : MonoBehaviour
{
    public Image im;
    float fadeTime = 3f;
    

    void Start()
    {
       im.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
    }


}
