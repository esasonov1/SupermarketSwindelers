using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CashierMonologue : MonoBehaviour
{

    public bool interactable;
    public ListHandler listHandler;

    void Start(){
        if (GameObject.FindWithTag("GameHandler") != null)
        {
            listHandler = GameObject.FindWithTag("GameHandler").GetComponent<ListHandler>();
        }
        interactable = false;
    }

    void Update() {
        if (interactable)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                listHandler.CalcScore();
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag =="Player") {
            interactable = false;
        }
    }
}
