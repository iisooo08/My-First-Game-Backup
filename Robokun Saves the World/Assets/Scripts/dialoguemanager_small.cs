using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class dialoguemanager_small : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; 
    public static bool stopdialogue = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.detect == true && Input.GetKeyDown("x")) 
        {
            stopdialogue = true; 
            dialogueText.text = DialogueManager.sentence; 
            DialogueManager.detect = false; 
        }
    }
}
