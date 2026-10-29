using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spacebattle_playerattack : MonoBehaviour
{
    public GameObject bulletprefab;
    public int cooltime; 
    private bool coolbool;
    public TextMeshProUGUI cooltime_text;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && coolbool == false)
        {
            Instantiate(bulletprefab, gameObject.transform.position, Quaternion.identity);
            StartCoroutine(Cooltime());
        }
    }

    IEnumerator Cooltime()
    {
        coolbool = true;
        for(int x = 0; x <= cooltime; x ++)
        {
            cooltime_text.text = (cooltime - x).ToString();
            yield return new WaitForSeconds(1f);
        }
        coolbool = false;
    }
}
