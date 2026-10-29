using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room1_story : MonoBehaviour
{
    private bool touching = false; 
    public static bool plant = false; 
    public GameObject plant3; 
    public GameObject plant_position; 
    public GameObject robokun; 
    private SpriteRenderer plantrend; 
    public static bool touching2; 
    public Rigidbody2D rb; 
    public Animator surveillance_bot; 
    public static bool transitioned = false; 
    private bool animdone = false;

    // Start is called before the first frame update
    void Start()
    {
        plant3 = GameObject.Find("labplant (2)"); 
        plant_position = GameObject.Find("plant_position"); 
        robokun = GameObject.Find("robokun_front"); 
        plantrend = plant3.GetComponent<SpriteRenderer>(); 
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        surveillance_bot = GameObject.Find("blocking_laser").GetComponent<Animator>(); 
        if(transitioned == true) 
        {
            Destroy(plant3); 
            Destroy(GameObject.Find("blocking_laser")); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(touching == true && DialogueManager.isopen_int == 1 && plant == false) 
        {
            StartCoroutine(PlantTransfer()); 
        }

        if(throw_plant.thrown == true && transitioned == false) 
        {
            transitioned = true; 
            StartCoroutine(SecurityAttack()); 
        }
        if(animdone == true) 
        {
            animdone = false;
            enemy_numberstorage.enemy_num_temp = 0;  
            enemy_numberstorage.return_scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; 
            battle_trigger.start_int = 1; 
        }
    }

    void OnCollisionEnter2D(Collision2D hitinfo) 
    {
        if(hitinfo.gameObject.name == "labplant (3)") 
        {
            touching = true; 
        }
        else if(hitinfo.gameObject.name == "blocking_laser") 
        {
            touching2 = true; 
        }
    }

    void OnCollisionExit2D() 
    {
        touching = false; 
        touching2 = false; 
    }

    IEnumerator PlantTransfer() 
    {
        yield return new WaitForSeconds(2f); 
        plant = true; 
        plant3.transform.parent = robokun.transform; 
        plantrend.sortingOrder = plantrend.sortingOrder + 1; 
        plant3.transform.position = plant_position.transform.position; 
    }

    IEnumerator SecurityAttack() 
    {
        yield return new WaitForSeconds(0.5f); 
        surveillance_bot.SetBool("attack", true); 
        yield return new WaitForSeconds(0.4f); 
        surveillance_bot.SetBool("attack", false); 
        yield return new WaitForSeconds(1f); 
        animdone = true;
    }
}
