using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour

{
    public GameObject tutorialScreenUI;
    public GameObject buttonOpenTutorial;
    // Start is called before the first frame update
    void Start()
    {
        tutorialScreenUI.SetActive(false);
    }

    

    public void Button_OpenTutorial(){
        tutorialScreenUI.SetActive(true);
        buttonOpenTutorial.SetActive(false);
    }

    public void Button_CloseTutorial() {
        tutorialScreenUI.SetActive(false);
        buttonOpenTutorial.SetActive(true);
    }
}
