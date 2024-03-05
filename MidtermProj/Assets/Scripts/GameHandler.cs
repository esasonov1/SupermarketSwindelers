using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public static GameObject theGameHandler;
    public int levelNum;
    public float savings;
    public float[] scores;

    void Awake()
    {
        if (theGameHandler != null && theGameHandler != this.gameObject)
        {
            Destroy(this.gameObject);
        }
        else
        {
            theGameHandler = this.gameObject;
        }
        DontDestroyOnLoad(theGameHandler);
    }
}
