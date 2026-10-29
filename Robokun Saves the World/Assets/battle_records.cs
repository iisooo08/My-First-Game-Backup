using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class battle_records : MonoBehaviour
{
    //따로 변수 필요없고 그냥 배틀이 일어나는 곳에서는 메뉴를 없애버리면됨. 
    public int robo_initial_health;
    public Slider robo_health;

    public int enemy_initial_health;
    public Slider enemy_health;
    public GameObject enemy;

    public Animator dmganim;

    public static bool punched = false;
    public static bool bombed = false;
    public TextMeshProUGUI dmgtext;

    // Start is called before the first frame update
    void Start()
    {
        enemy_health.maxValue = enemy_initial_health;
        robo_health.maxValue = robo_initial_health;
    }

    // Update is called once per frame
    void Update()
    {
        if(punched == true)
        {
            punched = false;
            enemy_health.value -= 3;//나중에 값 수정해야함. 
            //아마도: robokun level * initial attack value + weapon attack addition - debuff 정도? 
            dmgtext.text = "HIT!" + 3 + "DMG";
            dmgtext.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
            dmganim.SetBool("showing", true);
            StartCoroutine(timer());
        }
        if(bombed == true)
        {
            bombed = false;
            enemy_health.value -= 10;
            dmgtext.text = "HIT!" + 10 + "DMG";
            dmgtext.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
            dmganim.SetBool("showing", true);
            StartCoroutine(timer());
        }
        
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.4f);
        dmganim.SetBool("showing", false);
    }
}
