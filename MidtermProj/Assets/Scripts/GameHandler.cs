using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public List<string> cart = new List<string>();
    public List<string> pockets = new List<string>();
    public List<string> order = new List<string>();
    private List<string> collectedItems = new List<string>();
    public GameObject Tutorial;
    public GameObject buttonOpenTutorial;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial.SetActive(false);
    }

    public void AddItem(bool theft, string name)
    {
        collectedItems.Add(name);
        
        if(theft)
        {
            pockets.Add(name);
        }
        else
        {
            cart.Add(name);
        }
    }

    public string DropLastItem() {
        if (collectedItems.Count > 0) {
            string itemToDrop = collectedItems[collectedItems.Count - 1];
            collectedItems.RemoveAt(collectedItems.Count - 1);
            return itemToDrop;
        }
        
        return null;
    }

    public void playGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void Button_OpenTutorial(){
        Tutorial.SetActive(true);
        buttonOpenTutorial.SetActive(false);
    }

    public void Button_CloseTutorial() {
        Tutorial.SetActive(false);
        buttonOpenTutorial.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
