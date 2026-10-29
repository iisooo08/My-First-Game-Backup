using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class battlescript : MonoBehaviour
{
    public List<string> attackLines; //list to write down attack patterns numerically (so that I don't need separate script for all bosses) 
    public string movementLine; 
    public bool movementVal = false; 
    public List<int> coordinatesx; //final list used to instantiate one group of objects at end of for loop 
    public List<int> coordinatesy; 
    public List<GameObject> attackTypes; 
    public Transform parentobj; 

    private bool once = false; 
    private bool functiononce = false; 
    private int xmove = 0; 
    private int ymove = 0; 
    private int attackNum; 
    private bool attacked = false;

    private int tempx;
    private int tempy;

    private bool elseifonce = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BattleCoroutine());
    }

    // Update is called once per frame
    IEnumerator BattleCoroutine()
    {
        for(int x = 0; x < attackLines.Count; x++)
        {
            if(x == 0)
            {
                attackNum = int.Parse(attackLines[x]); 
            }
            else
            {
                for(int y = 0; y < attackLines[x].Length; y++)
            {
                //attack 그리고 여기서 특수부호 신호를 받으면 밑에 있는 함수로 이동 
                if(attackLines[x][0].ToString() == "@" && functiononce == false)
                {
                    functiononce = true; 
                    End(); 
                }
                else if(attackLines[x][0].ToString() == "#" && functiononce == false)
                {
                    functiononce = true;
                    HarmfulEffects(); 
                }
                else if(attackLines[x][0].ToString() == "*" && functiononce == false)
                {
                    functiononce = true;
                    Dialogue(); 
                }
                else if(attackLines[x][0].ToString() == "^" && elseifonce == false)
                {
                    elseifonce = true;
                    //repeat function: ^315 --> 3번 반복한다 line 1-5를 
                    for(int i = 0; i < int.Parse(attackLines[x][1].ToString()); i++)
                    {
                        for(int j = int.Parse(attackLines[x][2].ToString()); j < int.Parse(attackLines[x][3].ToString()) + 1; j++) 
                        {
                            print(j + "j value");
                            for(int k = 0; k < attackLines[j].Length; k++)
                            {
                                tempx = j;
                                tempy = k;
                                Attack();
                            }
                            Instantiate();
                            yield return new WaitForSeconds(2f);
                        }
                    }
                }
                else//만일 그냥 공격하는 거라면 (다른 함수가 아니라)
                {
                    print("just attack");
                    //battlegrid 에 있는 4개의 점 중 하나 + 거기서 틀어야 하는 방향 예)-1, +1 이면 x좌표로 -1 y좌표로 +1 
                    //-1+1 점1에서 엑스좌표 -1 와이좌표 +1 이동한 점을 찍는거임 
                    //예: -1+1.-2+2...
                    tempx = x; 
                    tempy = y;
                    Attack();
                    attacked = true;
                }
            }
            if(attacked == true)
            {
                Instantiate();
                                attacked = false;
                yield return new WaitForSeconds(2f);

            }
        }
    }
    }

    void Instantiate()
    {
        //instantiate objects based on coordinates 
        for(int z = 0; z < coordinatesx.Count; z++)
        {
                Instantiate(attackTypes[attackNum], new Vector2(coordinatesx[z], coordinatesy[z]) , Quaternion.identity, parentobj);
        }
        coordinatesx.Clear(); coordinatesy.Clear(); 
        functiononce = false;
    }

    void Attack()
    {
        functiononce = true;
        //print("attack function entered");
        if(once == false && (attackLines[tempx][tempy].ToString() == "+" || attackLines[tempx][tempy].ToString() == "-"))//first value(for x value) 
        {
            once = true; 
                        if(attackLines[tempx][tempy].ToString() == "-")
            {
                xmove = 0 - int.Parse(attackLines[tempx][tempy+1].ToString()); 
            }
               else
            {
                xmove = int.Parse(attackLines[tempx][tempy+1].ToString()); 
            }
        }
        else if(once == true && (attackLines[tempx][tempy].ToString() == "+" || attackLines[tempx][tempy].ToString() == "-"))//y value 
        {
            if(attackLines[tempx][tempy].ToString() == "-")
            {
                ymove = 0 - int.Parse(attackLines[tempx][tempy+1].ToString()); 
            }
            else
            {
                ymove = int.Parse(attackLines[tempx][tempy+1].ToString()); 
            }
        }
        else if(attackLines[tempx][tempy].ToString() == ".")
        {
            coordinatesx.Add(xmove); coordinatesy.Add(ymove); 
            once = false; xmove = 0; ymove = 0; 
        }
        functiononce = false;
    }

    void End() 
    {
        death_manager.CODtext = "estimated cause: overloaded components due to prolonged battle";
        print(death_manager.CODtext);
        SceneManager.LoadScene(19);
    }

    void HarmfulEffects() 
    {
        //포켓몬 독 같은 steady damage attack 
        //speed debuff 
        //attack debuff 
    }

    void Dialogue() 
    {
        //dialogue contents 
    }
}
