using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class spaceattack_script : MonoBehaviour
{
    //position grid reference: -2.5, -1.3, -0.1, 1.15, 2.4 for the x axis 
    //position grid reference: 3.6, 1.8, -0.15, -2.1, -4 for the y axis 
    public List<GameObject> attacklist; //types of attacks 
    public List<int> attackorder; //what attack will be used each turn 
    public List<string> attackpos; //how many attacks will be spawned, and where it will be spawned 
    //it will be in the form: *1_2*3_4*... this means spawn 1 in pos 2, 3 in pos 4, etc... 
    public List<float> resttime; //time in between attack sequences 
    public List<int> attackpos1; //temporary list per each x loop to store values of how many attacks per position 
    public List<string> attackpos2; //temporary list per each x loop to store values of attack positions 
    private int temp; //temporary value to store which attack run it is 
    
    public List<string> attackdialogue;
    private int stringtemp;
    public TextMeshProUGUI dialogue_text;

public void Attack(){
    StartCoroutine(Attacks());
}
    IEnumerator Attacks()
    {
        for(int x = 0; x < attackorder.Count; x++) //one rotation per each attack cycle 
        {
            temp = x;
            //interpret the attackpos values 
            for(int y = 0; y < attackpos[x].Length; y++) //add all values to attackpos 1 and 2 
            {
                if(attackpos[x][y] + "" == "*")
                {
                    attackpos1.Add(int.Parse(attackpos[x][y + 1] + "")); //add the single digit number that tells how many per position 
                }
                else if(attackpos[x][y] + "" == "_")
                {
                    attackpos2.Add(attackpos[x][y+1] + ""); //add the single digit number that tells what position 
                }
            }
            if(stringtemp > attackdialogue.Count)
            {
                stringtemp = 0;
            }
            dialogue_text.text = attackdialogue[stringtemp];
            stringtemp += 1;
            InstantiateAttacks();
            yield return new WaitForSeconds(1f);
            //yield return new WaitForSeconds(resttime[x]); 
        }
        yield return new WaitForSeconds(3f);
        print("battle won");
        SceneManager.LoadScene(enemy_numberstorage.return_scene);
    }

    void InstantiateAttacks()
    {
        for(int x = 0; x < attackpos1.Count; x++)
        {
            for(int y = 0; y < attackpos1[x]; y++)
            {
                Instantiate(attacklist[attackorder[temp]], GameObject.Find(attackpos2[x]).transform.position, Quaternion.identity);
            }
        }
        attackpos1.Clear();
        attackpos2.Clear();
    }
}
