using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class battlescript_player : MonoBehaviour
{
    public GameObject bomb_effect;

    public Animator punch_anim;
    public Animator bomb_anim;
    public TextMeshProUGUI punch_timer;
    public TextMeshProUGUI bomb_timer;

    public GameObject punch_effect;

    private bool punchbool = true; 
    private bool bombbool = true; 
    private GameObject radius; 

    // Start is called before the first frame update
    void Start()
    {
        radius = GameObject.Find("Circle");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p") && punchbool == true)//나중에 거리제한 조건도 달아야 함. 
        {
            if(range_collider.punch_inrange == true)
            {
                Instantiate(punch_effect, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) , Quaternion.identity);
                battle_records.punched = true;
                print("start punch");
                punchbool = false;
                punch_anim.SetBool("die", true);
                //적 피 깎는 메커니즘 넣어야함 플레이어가 적을 찾아서 신호보내면 안됨 왜냐면 적은 유니크개체라서. 적이 플레이어를 찾아야함. 
                StartCoroutine(CoolTime_punch());
            }
            else
            {
                //펀치 거리조건땜에 안들어간다고 메세지 띄워야함. 
            }
        }
        if(Input.GetKeyDown("o") && bombbool == true)
        {
            Instantiate(bomb_effect, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            bombbool = false;
            bomb_anim.SetBool("die", true);
            StartCoroutine(BombAttack());
            StartCoroutine(CoolTime_bomb());
            StartCoroutine(playerBombed());
        }
    }

    IEnumerator CoolTime_punch()
    {
            for(int x = 0; x < 10; x++)
            {
                punch_timer.text = (10 - x).ToString(); 
                yield return new WaitForSeconds(1f); 
            }
            punch_timer.text = "";
            punchbool = true;
            punch_anim.SetBool("die", false);
    }

    IEnumerator CoolTime_bomb()
    {
            for(int x = 0; x < 10; x++)
            {
                bomb_timer.text = (10 - x).ToString(); 
                yield return new WaitForSeconds(1f); 
            }
            bomb_timer.text = "";
            bombbool = true;
            bomb_anim.SetBool("die", false); 
    }

    IEnumerator BombAttack()
    {
        yield return new WaitForSeconds(0.2f);
        if(bombcircle_script.bomb_inrange == true)
        {
            print("first if executed");
            yield return new WaitForSeconds(1f);
            bombcircle_script.bomb_inrange = false;
            battle_records.bombed = true;
        }
    }
    IEnumerator playerBombed()
    {
        yield return new WaitForSeconds(0.2f);
        if(bombcircle_script.player_hit == true)
        {
            yield return new WaitForSeconds(1f);
            bombcircle_script.player_hit = false;
        }
    }
}
