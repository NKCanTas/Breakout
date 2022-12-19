using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEffects : MonoBehaviour
{
    public int breakingBricks;
    
    private ParticleSystem breaking;

    private void Awake()
    {
        breaking = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        breaking.Emit(breakingBricks);
    }
}
