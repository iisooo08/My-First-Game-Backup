using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robomovement : MonoBehaviour
{
    public float movespeed = 4f; 
    public Rigidbody2D rb; 
    Vector2 movement; 
    public Animator anim; 
    public AudioSource audio; 
    public int playing = 0; 
    public GameObject menucanvas;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("m"))
        {
        }
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 
        anim.SetFloat("Horizontal", movement.x); 
        anim.SetFloat("Vertical", movement.y); 
        if(movement.x != 0 || movement.y != 0) 
        {
            anim.SetFloat("Speed", 1); 
            anim.ResetTrigger("front"); 
            anim.ResetTrigger("back"); 
            anim.ResetTrigger("left"); 
            anim.ResetTrigger("right"); 
        }
        else 
        {
            anim.SetFloat("Speed", 0); 
        }

        if(movement.x == 0 && movement.y == -1) 
        {
            anim.SetTrigger("front"); 
        }
        if(movement.x == 0 && movement.y == 1) 
        {
            anim.SetTrigger("back"); 
        }
        if(movement.x == 1 && movement.y == 0) 
        {
            anim.SetTrigger("right"); 
        }
        if(movement.x == -1 && movement.y == 0) 
        {
            anim.SetTrigger("left"); 
        }

        if((movement.x != 0 || movement.y != 0) && playing != 1 && DialogueManager.isopen_int == 0) 
        {
            audio.Play(0); 
            playing = 1; 
        }
        else if(movement.x == 0 && movement.y == 0) 
        {
            audio.Pause(); 
            playing = 0; 
        }
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); 
    }

}
