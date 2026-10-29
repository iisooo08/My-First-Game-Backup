using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_script : MonoBehaviour
{
    private bool touching = false; 
    public Dialogue dialogue; 
    public Rigidbody2D rb; 
    public string sentences_2; 
    public string choice_sentence; 
    private List<string> temp = new List<string>(); 
    public static string name; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        name = gameObject.name; 
        dialogue.fromlever = false; 
        dialogue.privname = gameObject.name; 
    }

    // Update is called once per frame
    void Update()
    {
        if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && room1_story.plant == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
        }
        else if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && room1_story.plant == true)
        {
            dialogue.sentences.Clear(); 
            dialogue.sentences.Add(sentences_2); 
            dialogue.sentences.Add(choice_sentence); 
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
