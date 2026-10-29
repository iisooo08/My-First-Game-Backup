using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems; 

public class nextarrow_click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && DialogueManager.nextarrow_bool == true) 
        {
            gameObject.GetComponent<Button>().onClick.Invoke(); 
        }
    }
}
