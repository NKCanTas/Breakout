using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEffects : MonoBehaviour
{
    public int breakingBricks;
    
    private BallBreakout balling;
    private ParticleSystem breaking;

    private void Awake()
    {
        balling = GetComponentInParent<BallBreakout>();
        breaking = GetComponent<ParticleSystem>();
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
        breaking.Emit(breakingBricks);
    }
}
