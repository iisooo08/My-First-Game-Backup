using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_dialogue : MonoBehaviour
{
    public Dialogue dialogue; 
    private bool touching = false; 
    public Rigidbody2D rb; 
    public static string name; 

    private bool once = false;
    public string replacementtext;

    void Start() 
    {
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        name = gameObject.name; 
        dialogue.fromlever = false; 
        dialogue.privname = gameObject.name; 
    }

    void Update() 
    {

        if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && once == false) 
        {
            once = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
        }
        else if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && once == true)
        {
            dialogue.sentences.Clear();
            dialogue.sentences.Add(replacementtext);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
        }
    }

    void OnCollisionEnter2D() 
    {
        touching = true; 
    }

    void OnCollisionExit2D() 
    {
        touching = false; 
    }
}
