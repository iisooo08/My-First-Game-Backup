using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateway_script : MonoBehaviour
{
    public static int collided = -2; 
    public int temp; 
    // Start is called before the first frame update
    void Start()
    {
        collided = -2; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        if(hitInfo.name == "robokun_front") 
        {
            collided = temp; 
        }
    }
}
