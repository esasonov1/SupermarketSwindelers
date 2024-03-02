using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public Scene gameOverScene;
    public Text finalScore;

    public void SetGameOver()
    {
        SceneManager.LoadScene("EndScene");

    }
}