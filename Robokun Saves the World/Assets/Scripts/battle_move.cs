using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_move : MonoBehaviour
{
    public Animator anim; 
    private int horizontal; 
    private int vertical; 
    public bool collided = false; 
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s")) 
        {
            anim.SetTrigger("front"); 
            anim.ResetTrigger("back"); 
            anim.ResetTrigger("left"); 
            anim.ResetTrigger("right"); 
            if(vertical != 3) 
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1.3f); 
                vertical += 1; 
            }
            print("(" + horizontal + "," + vertical + ")"); 
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w")) 
        {
            anim.SetTrigger("back"); 
            anim.ResetTrigger("front"); 
            anim.ResetTrigger("left"); 
            anim.ResetTrigger("right"); 
            if(vertical != 0) 
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1.3f); 
                vertical -= 1; 
            }
            print("(" + horizontal + "," + vertical + ")"); 
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a")) 
        {
            anim.SetTrigger("left"); 
            anim.ResetTrigger("front"); 
            anim.ResetTrigger("back"); 
            anim.ResetTrigger("right"); 
            if(horizontal != 0) 
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y); 
                horizontal -= 1;
            }
            print("(" + horizontal + "," + vertical + ")"); 
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d")) 
        {
            anim.SetTrigger("right"); 
            anim.ResetTrigger("front"); 
            anim.ResetTrigger("left"); 
            anim.ResetTrigger("back"); 
            if(horizontal != 3) 
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y); 
                horizontal += 1; 
            }
            print("(" + horizontal + "," + vertical + ")"); 
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name.Substring(0, 9) != "robokun_b")
        {
            collided = true; 
            print("collided"); 
        }
    }
    void OnTriggerExit2D() 
    {
        collided = false; 
    }
}
