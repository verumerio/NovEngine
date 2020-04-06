using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchButton : MonoBehaviour
{
    SpriteRenderer sp;
    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }


    void setAlpha(float alp)
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        var color = sp.color;
        color.a = alp;
        sp.color = color;
        
    }

    void settxt(string txt)
    {

        switch (txt)
        {
            case "":
                setAlpha(0.0f);
                break;
            default:
                setAlpha(0.6f);
                break;
        }
        tm = GetComponentInChildren<TextMesh>();
        tm.text = txt;
    }
}
