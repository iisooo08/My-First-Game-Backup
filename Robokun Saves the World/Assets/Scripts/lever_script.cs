using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class lever_script : MonoBehaviour 
{
    public GameObject barrier; 
    private bool touching = false; 
    public Dialogue dialogue; 
    public Rigidbody2D rb; 
    public string sentences_2; 
    private List<string> temp = new List<string>(); 
    public Animator anim; 
    public static string name;  
    private static bool locked = false; 
    public bool inconvo1 = false; 
    public bool inconvo2 = false; 


    void Start() 
    {
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        anim = gameObject.GetComponent<Animator>(); 
        name = gameObject.name; 
        dialogue.fromlever = true; 
        dialogue.privname = gameObject.name; 
    }

    void Update() 
    {
        if(locked == true)
        {
            barrier.SetActive(false);
        }
        if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && anim.GetBool("down") == false && locked == false)  
        {
            inconvo1 = true; 
            print("inconvo1"); 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
        }

        else if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && anim.GetBool("down") == true) 
        {
            inconvo2 = true; 
            print("inconvo2"); 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
        }

        if(inconvo1 == true && choice_funct.outcome == true && DialogueManager.end_dialogue == 1) 
        {
            //pull the lever down 
            anim.SetBool("down", true); 
            locked = true; 
            barrier.SetActive(false);
            inconvo1 = false; 
            dialogue.sentences.Clear(); 
            dialogue.sentences.Add(sentences_2); 
        }

        else if(inconvo2 == true && choice_funct.outcome == true && DialogueManager.end_dialogue == 1) 
        {
            //push the lever up 
            inconvo2 = false; 
        }
    }

    void OnCollisionEnter2D() //make sure to check if robokun made contact 
    {
        touching = true; 
    }
    
    void OnCollisionExit2D() 
    {
        touching = false; 
    }
}