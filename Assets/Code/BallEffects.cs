using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BallEffects : MonoBehaviour
{
    public int BurstofFirework;
    
    private BallBreakout balling;
    private ParticleSystem Firework;

    private void Awake()
    {
        //GetComponentInChild guckt in Unity nach untere Hirachien, InParent zuerst sich selbst, dann Hirachie nach oben
        balling = GetComponentInParent<BallBreakout>();
        Firework = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        balling.Ballreacting += Balled;
    }

    private void OnDisable()
    {
        balling.Ballreacting -= Balled;
    }

    private void Balled(Vector2 collisionpoint)
    {
        Firework.Emit(BurstofFirework);
    }
}
