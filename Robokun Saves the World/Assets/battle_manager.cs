using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class battle_manager : MonoBehaviour
{
    public List<GameObject> enemysprite; 
    public List<string> StartLines; 
    public List<string> BattleLines; 
    public List<string> DefeatLines; 
    public List<int> enemyHP; 
    public TextMeshProUGUI numleft; 
    public Dialogue dialogue; 
    public Rigidbody2D rb; 
    public bool startdialogue = false; 
    public List<GameObject> Scriptobj; 
    public int hurtnum = -1; 
    public Slider hpslider; 
    public Slider enemyslider; 
    public SpriteRenderer rbrender; 
    public int current_enemy_HP; 
    public GameObject bullet; 
    public GameObject enemyobj; 
    
    // Start is called before the first frame update
    void Start()
    {
        battle_trigger.start_int = 0; 
        enemyobj = Instantiate(enemysprite[enemy_numberstorage.enemy_num_temp], new Vector2(GameObject.Find("enemy_position").transform.position.x, GameObject.Find("enemy_position").transform.position.y), Quaternion.identity); 
        StartCoroutine(Startbattle()); 
        rbrender = GameObject.Find("robokun_front").GetComponent<SpriteRenderer>(); 
        current_enemy_HP = enemyHP[enemy_numberstorage.enemy_num_temp]; 
        enemyslider.maxValue = current_enemy_HP; 
    }

    // Update is called once per frame
    void Update()
    {   
        enemyslider.value = current_enemy_HP; 

        if(hurtnum != -1) 
        {
            SetSliderValue(); 
        }

        if(hpslider.value == 0) 
        {
            print("hp down"); 
            SceneManager.LoadScene(20); 
        }

        if(Scriptobj[enemy_numberstorage.enemy_num_temp].GetComponent<attackscript>().timeout == true) 
        {
            print("game over"); 
            SceneManager.LoadScene(20); 
        }

        if(current_enemy_HP != 0 && Scriptobj[enemy_numberstorage.enemy_num_temp].GetComponent<attackscript>().attacktime == true) 
        {
            if(Input.GetKeyDown("space")) 
            {
                Instantiate(bullet, new Vector2(GameObject.Find("robokun_front").transform.position.x, GameObject.Find("robokun_front").transform.position.y), Quaternion.identity); 
            }
        }

        if(current_enemy_HP <= 0) 
        {
            //show enemy dying motion 
            current_enemy_HP = -1; 
            enemysprite[enemy_numberstorage.enemy_num_temp].GetComponent<enemy_hit>().kill(); 
            //leave battle 
            StartCoroutine(ReturnScene()); 
        }
    }

    IEnumerator ReturnScene() 
    {
        yield return new WaitForSeconds(1f); 
        SceneManager.LoadScene(enemy_numberstorage.return_scene); 
    }

    IEnumerator Startbattle() 
    {
        yield return new WaitForSeconds(0.5f); 
        //type dialogue. 
        dialogue.sentences.Clear(); 
        dialogue.sentences.Add(StartLines[enemy_numberstorage.enemy_num_temp]);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
        yield return new WaitForSeconds(2f); 
        //show round 1 animation + the 3, 2, 1, countdown 

        //start attacks 
        //call the attack script corresponding to the current enemy 
        Scriptobj[enemy_numberstorage.enemy_num_temp].GetComponent<attackscript>().attack(); 
    }

    public void SayLine() 
    {
        dialogue.sentences.Clear(); 
        dialogue.sentences.Add(BattleLines[enemy_numberstorage.enemy_num_temp]); 
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
    }
    public void SetSliderValue()
    {
        hpslider.value = hpslider.value - hurtnum; 
        hurtnum = -1; 
        StartCoroutine(damageeffects()); 
    }

    IEnumerator damageeffects() 
    {
        for(int x = 0; x < 8; x++) 
        {
            if(x % 2 == 0) 
            {
                rbrender.color = Color.red; 
            }
            else 
            {
                rbrender.color = Color.white; 
            }
            yield return new WaitForSeconds(0.2f); 
        }
    }
}
