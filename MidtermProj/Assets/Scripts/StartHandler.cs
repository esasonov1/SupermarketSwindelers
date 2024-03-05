using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartHandler : MonoBehaviour
{
    public GameHandler staticHandlerObj;
    void Start()
    {
        if (GameObject.FindWithTag("StaticHandler") != null)
        {
            staticHandlerObj = GameObject.FindWithTag("StaticHandler").GetComponent<GameHandler>();
        }
    }

    public void playGame()
    {
        staticHandlerObj.levelNum = 1;
        SceneManager.LoadScene("GameScene");
    }
}
