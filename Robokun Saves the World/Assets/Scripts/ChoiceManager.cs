using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ChoiceManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; 
    public GameObject nextarrow; 
    public TextMeshProUGUI yesText; 
    public TextMeshProUGUI noText; 
    public GameObject choicearrow; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Choice() 
    {
        nextarrow = GameObject.Find("nextarrow"); 
        choicearrow.SetActive(true); 
        dialogueText.text = ""; 
        nextarrow.SetActive(false); 
        yesText.text = "Yes"; 
        noText.text = "No"; 
    }

    public void EndChoice() 
    {
        choicearrow.SetActive(false); 
        yesText.text = ""; 
        noText.text = ""; 
    }
}
