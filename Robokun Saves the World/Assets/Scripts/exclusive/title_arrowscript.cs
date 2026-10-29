using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class title_arrowscript : MonoBehaviour
{
    private int num = 1; 
    public TextMeshProUGUI start; 
    public TextMeshProUGUI settings; 
    public TextMeshProUGUI info; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && num != 3) 
        {
            num += 1; 
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow) && num != 1) 
        {
            num -= 1; 
        }

        if(num == 1) 
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, start.transform.position.y); 
            if(Input.GetKeyDown("return")) 
            {
                SceneManager.LoadScene(1); 
            }
        }

        else if(num == 2) 
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, settings.transform.position.y); 
        }

        else if(num == 3) 
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, info.transform.position.y); 
        }
    }
}
