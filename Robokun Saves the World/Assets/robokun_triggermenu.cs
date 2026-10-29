using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robokun_triggermenu : MonoBehaviour
{
    public static bool open = false;
    public GameObject menu;
    private Rigidbody2D rb; 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            open = !open;
            menu.SetActive(open);
        }
        if(open == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
        }
        else
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY; 
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX; 
            rb.constraints = RigidbodyConstraints2D.FreezeRotation; 
        }
    }
}
