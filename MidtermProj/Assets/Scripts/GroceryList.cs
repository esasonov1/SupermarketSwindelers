using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GroceryList : MonoBehaviour
{

    public GameObject listMenuUI;
    public GameObject buttonOpenList;


    void Start()
    {

        if (listMenuUI != null)
        {
            listMenuUI.SetActive(false);
        }

    }

    void Update()
    {
    }

    //Button Functions:
    public void Button_OpenList()
    {
        listMenuUI.SetActive(true);
        buttonOpenList.SetActive(false);
    }

    public void Button_CloseList()
    {
        listMenuUI.SetActive(false);
        buttonOpenList.SetActive(true);
    }
}

