using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSummary : MonoBehaviour
{
    public Text scoreText;

    public GameHandler staticHandlerObj;

    public float winThreshold = 0f;

    public void Start()
    {
        if (GameObject.FindWithTag("StaticHandler") != null)
        {
            staticHandlerObj = GameObject.FindWithTag("StaticHandler").GetComponent<GameHandler>();
        }
        string text = "Leftover Budget/Order Payment: " + staticHandlerObj.scores[0].ToString("0.00") + "\nPurchased Items: -"
        + staticHandlerObj.scores[1].ToString("0.00") + "\nTip/Time Bonus: " + staticHandlerObj.scores[2].ToString("0.00") + "\nStolen Goods Value: "
        + staticHandlerObj.scores[3].ToString("0.00");
        float totalScore = staticHandlerObj.scores[0] + staticHandlerObj.scores[2] + staticHandlerObj.scores[3];
        text += "\n\nTotal Earnings: " + totalScore.ToString("0.00");
        if(totalScore >= winThreshold)
        {
            text += "\n\nI was able to pay my bills!";
        }
        else
        {
            text += "\n\nAnother sleepless night without heating...";
        }
        scoreText.text = text;
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
