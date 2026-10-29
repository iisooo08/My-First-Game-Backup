using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add time over element! (out of turns) 
public class attackscript : MonoBehaviour
{
    public List<GameObject> Attacktypes; 
    public List<string> Attackorders; 
    public List<int> coordinates; 
    public List<string> attackdialogue; 
    public List<float> spawncoords; 
    public int type; 
    public int temp; 
    public Transform parentobj; 
    public float wait_time; 
    public List<int> RepeatList; 
    private int num1; 
    private int num2; 
    private bool repeated = false; 
    public Dialogue dialogue; 
    public bool attacktime = false; 
    public bool timeout = false; 

    void Start() 
    {
        parentobj = GameObject.Find("attackparent").transform; 
    }

    public void attack() 
    {
        StartCoroutine(AttackCoroutine()); 
    }

    IEnumerator AttackCoroutine() 
    {
        //attack code (make sure the code can be altered in the editor based on the enemy)
        for(int x = 0; x < Attackorders.Count; x++) 
        {
            for(int y = 0; y < Attackorders[x].Length; y++) 
            {
                if(y == 0) 
                {
                    if(Attackorders[x][y].ToString() == "z" || Attackorders[x][0].ToString() == "z") 
                    {
                        repeated = true; 
                        for(int i = 1; i < Attackorders[x].Length; i++) 
                        {
                            //add all repeat lines to a separate list 
                            RepeatList.Add(int.Parse(Attackorders[x][i].ToString())); 
                        }
                        StartCoroutine(Repeat()); 
                    }
                    else if(Attackorders[x][y].ToString() == "s") 
                    {
                        //signal that chances have ended 
                        print("chances have ended - game over"); 
                        timeout = true; 
                    }
                    else if(Attackorders[x][y].ToString() == "y" || Attackorders[x][0].ToString() == "y") 
                    {
                        repeated = true; 
                        //show dialogue 
                        dialogue.sentences.Clear(); 
                        dialogue.sentences.Add(attackdialogue[int.Parse(Attackorders[x][1].ToString())]);
                        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
                    }
                    else if(Attackorders[x][y].ToString() == "a" || Attackorders[x][0].ToString() == "a") 
                    {
                        repeated = true; 
                        //show attack chance animations 
                        attacktime = true; 
                        yield return new WaitForSeconds(5f); 
                        attacktime = false; 
                    }
                    else 
                    {
                        repeated = false; 
                        type = int.Parse(Attackorders[x][0].ToString()); 
                        print(type); 
                    }   
                }
                else if(y != 0 && repeated == false)
                {
                    num1 = x; 
                    num2 = y; 
                    AddCoordinates(); 
                }
            }
            if(repeated == false) 
            {
                InstantiateObj(); 
            }
            yield return new WaitForSeconds(wait_time); 
        }
    }

    public void InstantiateObj() 
    {
        for (int i = 0; i < coordinates.Count; i++)
            {
                Instantiate(Attacktypes[type], new Vector2(GameObject.Find(coordinates[i].ToString()).transform.position.x, GameObject.Find(coordinates[i].ToString()).transform.position.y + spawncoords[type]) , Quaternion.identity, parentobj);
                
            }
        coordinates.Clear(); 
    }

    IEnumerator Repeat() 
    {
        for(int x = 0; x < RepeatList.Count; x++) 
        {
            for(int y = 1; y < Attackorders[RepeatList[x]].Length; y++) 
            {
                num1 = RepeatList[x]; 
                num2 = y; 
                AddCoordinates(); 
                
            }
            InstantiateObj(); 
            yield return new WaitForSeconds(wait_time); 

        }
    }

    public void AddCoordinates() 
    {
                    //add to the list 
                    if(Attackorders[num1][num2].ToString() == "a") 
                    {
                        coordinates.Add(10); 
                    }
                    else if(Attackorders[num1][num2].ToString() == "b") 
                    {
                        coordinates.Add(11); 
                    }
                    else if(Attackorders[num1][num2].ToString() == "c") 
                    {
                        coordinates.Add(12); 
                    }
                    else if(Attackorders[num1][num2].ToString() == "d") 
                    {
                        coordinates.Add(13); 
                    }
                    else if(Attackorders[num1][num2].ToString() == "e") 
                    {
                        coordinates.Add(14); 
                    }
                    else if(Attackorders[num1][num2].ToString() == "f") 
                    {
                        coordinates.Add(15); 
                    }
                    else if(Attackorders[num1][num2].ToString() == "g") 
                    {
                        coordinates.Add(16); 
                    }
                    else 
                    {
                        coordinates.Add(int.Parse(Attackorders[num1][num2].ToString())); 
                    }
    }
}
