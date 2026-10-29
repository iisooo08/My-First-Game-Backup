using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//checks if the player is holding a certain item. if yes, do something 
public class puzzle_trigger1 : MonoBehaviour
{
    private bool touching = false; 
    public string requirement;
    public GameObject nextCodeObject;

    void Update()
    {
        if(touching == true)
        {
            if(GameObject.Find("Tempinvent_items").GetComponent<Tempinvent_items>().CheckifinList(requirement) && Input.GetKeyDown("return"))
            {
                nextCodeObject.SetActive(true);
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
