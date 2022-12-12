using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBreakout : MonoBehaviour
{
    public delegate void Balls(Vector2 Baller);
    
    public event Action<Vector2> Ballreacting;

    private Rigidbody2D rb;
    private Collider2D[] colliders;

    //private float bouncefromBrick = 3f;
    private float speed = 2f;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateManager.GameState targetstate)
    {
        switch (targetstate)
        {
            case GameStateManager.GameState.ready:
                break;
            
            case GameStateManager.GameState.playing:
                
                break;
            
            case GameStateManager.GameState.win:
                break;
            
            case GameStateManager.GameState.lose:
                //if Befehl machen, der bei 3 mal den Trigger begeht das Spiel zurücksetzen (Z.75)   
                break;
            
            default: break;
        }
    }
    
    void Start()
    {
        rb.velocity = (Vector2.up + Vector2.up + Vector2.right) * speed;
        OnGameStateChanged(GameStateManager.GameState.playing);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            float hitdistance = transform.position.x - col.transform.position.x;

            float hitdistancenormalized = hitdistance / col.collider.bounds.extents.x;

            Vector2 newDirection = rb.velocity.normalized;
            newDirection.x += hitdistancenormalized;
            newDirection.Normalize();

            rb.velocity = newDirection * rb.velocity.magnitude;
        }
        Ballreacting?.Invoke(col.GetContact(0).point);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        transform.position = Vector3.zero;

        rb.velocity = (Vector2.up + Vector2.up + Vector2.right) * speed;
        
        //if Befehl machen, der bei 3 mal den Trigger begeht das Spiel zurücksetzen (Z.30)

        //OnGameStateChanged(GameStateManager.GameState.lose);
    }
}
