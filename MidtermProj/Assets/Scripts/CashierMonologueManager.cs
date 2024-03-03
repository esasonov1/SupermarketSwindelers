using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierMonologueManager : MonoBehaviour
{
     public GameObject monologueBox;
       public Text monologueText;
       public string[] monologue;
       public int monologueLength;

       void Start(){
              monologueBox.SetActive(false);
              monologueLength = monologue.Length; //allows us test dialogue without an NPC
       }

       void Update(){
              //temporary testing before NPC is created
            //   if (Input.GetKeyDown("p")){
            //          monologueBox.SetActive(true);
            //   }
       }

       public void OpenMonologue(){
              monologueBox.SetActive(true);
 
              //auto-loads the first line of monologue
              monologueText.text = monologue[0];
       }

       public void CloseMonologue(){
              monologueBox.SetActive(false);
              monologueText.text = "..."; //reset text
       }

       public void LoadMonologueArray(string[] NPCscript, int scriptLength){
              monologue = NPCscript;
              monologueLength = scriptLength;
       }
}
