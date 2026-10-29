using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class dialoguescene_ : MonoBehaviour
{
    public static bool once = true; 
    public Dialogue dialogue; 

    // Start is called before the first frame update
    void Start()
    {
        dialogue.fromlever = false; 
        dialogue.privname = gameObject.name; 
    }

    // Update is called once per frame
    void Update()
    {
        if(once == true) 
        {
            once = false; 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
        }
    }
}
