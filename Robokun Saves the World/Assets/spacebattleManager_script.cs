using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacebattleManager_script : MonoBehaviour
{
    public List<GameObject> battleobjects; 
    // Start is called before the first frame update
    void Start()
    {
        print(enemy_numberstorage.enemy_num_temp);
        battleobjects[enemy_numberstorage.enemy_num_temp].GetComponent<spaceattack_script>().Attack(); 
    }
}
