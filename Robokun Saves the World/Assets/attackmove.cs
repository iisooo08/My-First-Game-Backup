using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackmove : MonoBehaviour
{
    public Vector2 spawnmove; 
    public Vector2 movement; 
    public float movespeed; 
    private Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 
    }
    
    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); 
    }
}
