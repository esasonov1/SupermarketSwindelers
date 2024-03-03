using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierMonologue : MonoBehaviour
{
       private CashierMonologueManager monologueMNGR;
       public string[] monologue; //enter monologue lines into the inspector for each NPC
       //public bool playerInRange = false; //could be used to display an image: hit [e] to talk
       public int monologueLength;
       public bool interactable;

       void Start(){
              monologueLength = monologue.Length;
              if (GameObject.FindWithTag("MonologueManager")!= null){
                     monologueMNGR = GameObject.FindWithTag("MonologueManager").GetComponent<CashierMonologueManager>();
              }
              interactable = false;
       }

     void Update() {
        if (interactable)
            {
                if(Input.GetKeyDown(KeyCode.P))
                {
                    monologueMNGR.LoadMonologueArray(monologue, monologueLength);
                    monologueMNGR.OpenMonologue();
                }
     }
     }

       private void OnTriggerEnter2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                    interactable = true;
                     //playerInRange = true;
                     //monologueMNGR.LoadMonologueArray(monologue, monologueLength);
                    // monologueMNGR.OpenMonologue();
              }
       }

       private void OnTriggerExit2D(Collider2D other){
              if (other.gameObject.tag =="Player") {
                interactable = false;
                    //  playerInRange = false;
                     monologueMNGR.CloseMonologue();
              }
       }
}
