using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artificial_dialogue : MonoBehaviour
{
    public bool art_start = false; 
    public bool art_end = false; 
    public Dialogue dialogue; 
    public Rigidbody2D rb; 
    public static bool once = false; 
    private bool entered = false; 

    void Start() 
    {
        dialogue.privname = gameObject.name; 
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(art_start == true && once == false) 
        {
            once = true; 
            ArtificialDialogueStart(); 
        }
        if(entered == true && DialogueManager.isopen_int == 0) 
        {
            art_end = true; 
            entered = false; 
        }
    }

    public void ArtificialDialogueStart() 
    {
        entered = true; 
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; 
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
    }
}
