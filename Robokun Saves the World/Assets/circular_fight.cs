using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class circular_fight : MonoBehaviour
{

    public Rigidbody2D rb; 
    public GameObject robokun; 
    private bool once = false; 
    private bool triggered = false; 
    public Animator botanim; 
    public static bool triggered2 = false; 

    void Start()
    {
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        robokun = GameObject.Find("robokun_front"); 
        botanim = GameObject.Find("security").GetComponent<Animator>(); 

        if(triggered2 == true) 
        {
            Destroy(gameObject); 
            robokun.transform.position = enemy_numberstorage.return_pos;
        }
    }

    void Update() 
    {
        if(triggered == true && once == false) 
        {
            once = true; 
            triggered = false; 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
            enemy_numberstorage.enemy_num_temp = 1; 
            print(enemy_numberstorage.enemy_num_temp);
            enemy_numberstorage.return_pos = GameObject.Find("battlereturn1").transform.position; 
            enemy_numberstorage.return_scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            triggered2 = true; 
            battle_trigger.start_int = 1; 
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject == robokun) 
        {
            triggered = true; 
            botanim.SetTrigger("attack"); 
        }
    }
}
