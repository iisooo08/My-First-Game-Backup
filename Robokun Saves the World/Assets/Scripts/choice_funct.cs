using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choice_funct : MonoBehaviour
{
    public GameObject arrow; 
    public int choicenum; 
    public static int currentnum; 
    public GameObject yeschoice; 
    public GameObject nochoice; 
    public static bool outcome = false; 

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("choicearrow"); 
        currentnum = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(outcome); 
        if(Input.GetKeyDown(KeyCode.DownArrow) && DialogueManager.isopen_int == 1 && currentnum < choicenum) 
        {
            arrow.transform.position = new Vector2(arrow.transform.position.x, arrow.transform.position.y - 1f); 
            currentnum += 1; 
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow) && DialogueManager.isopen_int == 1 && currentnum > 1) 
        {
            arrow.transform.position = new Vector2(arrow.transform.position.x, arrow.transform.position.y + 1f); 
            currentnum -= 1; 
        }

        if(currentnum == 1 && Input.GetKeyDown("return")) 
        {
            FindObjectOfType<ChoiceManager>().EndChoice(); 
            yeschoice = GameObject.Find(DialogueManager.objname).transform.Find("yes_choice").gameObject; 
            outcome = true; 
            yeschoice.GetComponent<untriggered_dialogue>().TriggerDialogue(); 
        }

        else if(currentnum == 2 && Input.GetKeyDown("return")) 
        {
            FindObjectOfType<ChoiceManager>().EndChoice(); 
            nochoice = GameObject.Find(DialogueManager.objname).transform.Find("no_choice").gameObject; 
            outcome = false; 
            nochoice.GetComponent<untriggered_dialogue>().TriggerDialogue(); 
        }
    }

}
