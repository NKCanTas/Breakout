using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderAnimation : MonoBehaviour
{
    private Animation animationBorder;
    
    private void Awake()
    {
        animationBorder = GetComponentInParent<Animation>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        animationBorder["deactivate Borderleft"].wrapMode = WrapMode.Once;
        
        animationBorder.Play("deactivate Borderleft");
    }
}
