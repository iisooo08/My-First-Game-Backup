using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throw_plant : MonoBehaviour
{
    public Animator plantanim; 
    private bool once = false; 
    public GameObject plant3; 
    public GameObject burntplant; 
    public static bool thrown = false; 

    // Start is called before the first frame update
    void Start()
    {
        plant3 = GameObject.Find("labplant (2)"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(choice_funct.outcome == true && room1_story.touching2 == true && once == false)
        {
            once = true; 
            burntplant.SetActive(true); 
            plant3.SetActive(false); 
            plantanim.SetTrigger("throw"); 
            thrown = true; 
        }
    }
}
