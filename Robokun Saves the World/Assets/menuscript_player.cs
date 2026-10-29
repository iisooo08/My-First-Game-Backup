using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuscript_player : MonoBehaviour
{
    private int vertical = 0;
    private int horizontal = 0;

    public GameObject itembox;
    public GameObject equipmentbox;
    public GameObject skillbox;
    public GameObject unknownbox;
    public GameObject save;
    public GameObject quit;

    // Update is called once per frame
    void Update()
    {
        if(robokun_triggermenu.open == true)
        {
            itembox = GameObject.Find("item_box");
            equipmentbox = GameObject.Find("equipment_box");
            skillbox = GameObject.Find("skill_box");
            unknownbox = GameObject.Find("unknown_box");
            save = GameObject.Find("save_button");
            quit = GameObject.Find("quit_button");
        }

        if(vertical == 0 && horizontal == 0)
        {
            skillbox.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
        }
        else
        {
            skillbox.gameObject.transform.localScale = new Vector2(1f,1f);
        }
        if(vertical == 0 && horizontal == 1)
        {
            equipmentbox.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
        }
        else
        {
            equipmentbox.gameObject.transform.localScale = new Vector2(1f,1f);
        }
        if(vertical == 1 && horizontal == 0)
        {
            itembox.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
        }
        else
        {
            itembox.gameObject.transform.localScale = new Vector2(1f,1f);
        }
        if(vertical == 1 && horizontal == 1)
        {
            unknownbox.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
        }
        else
        {
            unknownbox.gameObject.transform.localScale = new Vector2(1f,1f);
        }
        if(vertical == 2 && horizontal == 0)
        {
            quit.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
        }
        else
        {
            quit.gameObject.transform.localScale = new Vector2(1f,1f);
        }
        if(vertical == 2 && horizontal == 1)
        {
            save.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
        }
        else
        {
            save.gameObject.transform.localScale = new Vector2(1f,1f);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)&& robokun_triggermenu.open == true)
        {
            if(vertical != 0)
            {
                vertical -= 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)&& robokun_triggermenu.open == true)
        {
            if(vertical != 2)
            {
                vertical += 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)&& robokun_triggermenu.open == true)
        {
            if(horizontal == 0)
            {
                horizontal += 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && robokun_triggermenu.open == true)
        {
            if(horizontal == 1)
            {
                horizontal -= 1;
            }
        }

        if(robokun_triggermenu.open == false)
        {
            horizontal = 0;
            vertical = 0;
        }
    }
}
