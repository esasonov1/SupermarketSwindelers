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
       public List<string> missing;
       public List<string> errors;

       void Start(){
              monologueBox.SetActive(false);
              monologueLength = monologue.Length; //allows us test dialogue without an NPC
       }

       void Update(){
       }

       public void OpenMonologue(){
              monologueBox.SetActive(true);
              int missing = GameObject.FindWithTag("GameHandler").GetComponent<ListHandler>().order.Count;
              int errors = GameObject.FindWithTag("GameHandler").GetComponent<ListHandler>().orderedErrors.Count;
 
             if ((errors == 0) && (missing == 0)) {
                monologueText.text = monologue[1];
             } else {
               GameObject yesButton = monologueBox.transform.Find("Finish").gameObject;
               yesButton.SetActive(false);
               GameObject noButton = monologueBox.transform.Find("Continue").gameObject;
               noButton.SetActive(false);
                monologueText.text = monologue[0];
             }
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
