using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class BossMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float bossspead = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = ((Vector2.up * Random.Range(-1, 1)) * (1 / 2)) * bossspead;
        
        if (Random.Range(-1, 1) == 0)
        {
            rb.velocity = Vector2.up * (1 / 2) * bossspead;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Deathzone"))
        {
            transform.position = Vector3.zero;
            
            rb.velocity = ((Vector2.up * Random.Range(-1, 1)) * (1 / 2)) * bossspead;
        
            if (Random.Range(-1, 1) == 0)
            {
                rb.velocity = Vector2.up * (1 / 2) * bossspead;
            }
            
        }
    }
}
