using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class robokun_simplemovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed = 4f;
    Vector2 movement;
    public int lives = 3;
    public int ammo = 10;
    public TextMeshProUGUI ammo_text;
    public TextMeshProUGUI health_text;
    private bool once = false;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("attack") && once == false)
        {
            print("deadedead");
            once = true;//이거때문에 못죽을거임 나중에 개발할때 무적받도록 바꾸기
            //lives -= 1;
            health_text.text = lives + "";
            if(lives == 0)
            {
                print("dead");
                death_manager.CODtext = "cause of death: physical trauma";
                SceneManager.LoadScene(19);
            }
        }
    }
}

