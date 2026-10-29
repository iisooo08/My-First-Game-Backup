using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidespeak : MonoBehaviour
{
    public Rigidbody2D rb; 
    public GameObject robokun; 
    public Dialogue dialogue; 
    public int direction; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        robokun = GameObject.Find("robokun_front"); 
        name = gameObject.name; 
        dialogue.fromlever = false; 
        dialogue.privname = gameObject.name; 
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject == robokun) 
        {
            if(direction == 0) //push top 
            {
                robokun.transform.position = new Vector2(robokun.transform.position.x, robokun.transform.position.y + 0.5f); 
            }
            else if(direction == 1) //push bottom 
            {
                robokun.transform.position = new Vector2(robokun.transform.position.x + 0.5f, robokun.transform.position.y - 0.5f); 
            }
            else if(direction == 2) //push right 
            {
                robokun.transform.position = new Vector2(robokun.transform.position.x + 0.5f, robokun.transform.position.y); 
            }
            else if(direction == 3) //push left 
            {
                robokun.transform.position = new Vector2(robokun.transform.position.x - 0.5f, robokun.transform.position.y); 
            }
            
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
        }
    }
}
