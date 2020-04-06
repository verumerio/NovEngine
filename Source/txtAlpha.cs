using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class txtAlpha : MonoBehaviour
{
    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void setAlpha(float alp)
    {
        var color = gameObject.GetComponentInParent<SpriteRenderer>().color;
        color.a = alp;
        tm.color = color;
    }
}
