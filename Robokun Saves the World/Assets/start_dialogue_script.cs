using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_dialogue_script : MonoBehaviour
{
    public static bool once = true; 
    public Dialogue dialogue; 
    public Rigidbody2D rb; 

    public bool specialcase;
    public GameObject nextobject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        name = gameObject.name; 
        dialogue.fromlever = false; 
        dialogue.privname = gameObject.name; 
        if(specialcase == true)
        {
            nextobject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(once == true) 
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
            once = false; 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
        }
    }
}
