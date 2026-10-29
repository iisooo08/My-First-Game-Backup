using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombcircle_script : MonoBehaviour
{
    public static bool bomb_inrange = false;
    public static bool player_hit = false;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D info)
    {
        if(info.gameObject.CompareTag("enemy"))
        {
            print("enemy in range");
            bomb_inrange = true;
        }
        //하 근데 이게 하나씩밖에 구별을 못하는듯한데 
        //아 리스트에 다 넣은다음에 있는지 없는지 확인하기 어때 ㅋㅋ 
    }
}
