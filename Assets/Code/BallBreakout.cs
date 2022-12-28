using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

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

    private void Update()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            rb.velocity = (Vector2.up + Vector2.up + (Vector2.right * Random.Range(-1, 1))) * speed;

            if (Random.Range(-1, 1) == 0)
            {
                rb.velocity = (Vector2.up + Vector2.up) * speed; 
            }
        }
    }

    void Start()
    {
        Update();
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

        if (col.gameObject.CompareTag("Deathzone"))
        {
            transform.position = Vector3.down + Vector3.down + Vector3.down;

            rb.velocity = (Vector2.up +  Vector2.up + (Vector2.right * Random.Range(-1, 1))) * speed;
            
            if (Random.Range(-1, 1) == 0)
            {
                rb.velocity = (Vector2.up + Vector2.up) * speed; 
            }
        
            //if Befehl machen, der bei 3 mal den Trigger begeht das Spiel zurücksetzen (Z.30)

            //OnGameStateChanged(GameStateManager.GameState.lose);
        }
       
    }
}
