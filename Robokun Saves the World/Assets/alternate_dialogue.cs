using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this has two dialogues one for no item and the other for with item 
//optionally, it can trigger additional scripts when necessary 

public class alternate_dialogue : MonoBehaviour
{
    private bool touching = false; 
    public Dialogue dialogue; 
    public Rigidbody2D rb; 
    public string sentences_2; 
    private List<string> temp = new List<string>(); 
    public static string name; 

    public string requirement;
    public bool nextstep;
    public GameObject nextobj;

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
        if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && !GameObject.Find("Tempinvent_items").GetComponent<Tempinvent_items>().CheckifinList(requirement))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
        }
        else if(touching == true && Input.GetKeyDown("return") && DialogueManager.isopen_int == 0 && GameObject.Find("Tempinvent_items").GetComponent<Tempinvent_items>().CheckifinList(requirement))
        {
            dialogue.sentences.Clear(); 
            dialogue.sentences.Add(sentences_2); 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
            if(nextstep == true)
            {
                nextobj.SetActive(true);
            }
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
