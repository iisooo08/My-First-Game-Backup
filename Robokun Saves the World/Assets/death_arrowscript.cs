using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class death_arrowscript : MonoBehaviour
{
    private int num = 1; 
    public TextMeshProUGUI continueText; 
    public TextMeshProUGUI title; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && num != 2) 
        {
            num += 1; 
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow) && num != 1) 
        {
            num -= 1; 
        }

        if(num == 1) 
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, continueText.transform.position.y); 
        }

        else if(num == 2) 
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, title.transform.position.y); 
            if(Input.GetKeyDown("return")) 
            {
                SceneManager.LoadScene(0); 
            }
        }
    }
}
