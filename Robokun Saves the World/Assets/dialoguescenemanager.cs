// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class dialoguescenemanager : MonoBehaviour
// {
//     public Dialogue dialogue;
//     public List<string> names = new List<string>(); 
//     public int order;

//     void Start()
//     {
//         StartCoroutine(DialogueScene());
//     }

//     IEnumerator DialogueScene()
//     {
//         yield return new WaitForSeconds(2f);
//         for(int x = 0; x < order; x++)
//         {
//             dialogue.name = names[x%2];
//             dialogue.sentences.Clear();
//             for(int y = 0; y < GameObject.Find(x.ToString()).GetComponent<listscript1>().fragments.Count; y++)
//             {
//                 dialogue.sentences.Add(GameObject.Find(x.ToString()).GetComponent<listscript1>().fragments[y]);
//             }
//             FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
//             yield return new WaitUntil(() => DialogueManager.end_dialogue == 1);
//         }
//     }
// }
