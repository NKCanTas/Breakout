using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
     private float movespeed = 10f;
        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * (horizontal * Time.deltaTime * movespeed);
            
        }
}
