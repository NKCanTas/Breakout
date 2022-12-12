using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    private int brickHealth;
    public int initialHealth = 1;
    private int damage = 1;
    private BrickSpawner spawner;


    public void OnEnable()
    {
        brickHealth = initialHealth;
    }

    public void Damage(int damage)
    {

        brickHealth -= damage;

        if (brickHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetSpawner(BrickSpawner brickSpawner)
    {
        spawner = brickSpawner;
    }

        private void OnCollisionEnter2D(Collision2D col)
    {
        Damage(damage);
    }
}
