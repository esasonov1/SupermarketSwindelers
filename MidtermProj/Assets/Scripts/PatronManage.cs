using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronManage : MonoBehaviour
{
    public GameObject patronPrefab; 
    public int numberOfPatrons = 5;
    public float minX, maxX, minY, maxY;

    private void Start()
    {
        for (int i = 0; i < numberOfPatrons; i++)
        {
            SpawnPatron();
        }
    }

    private void SpawnPatron()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(patronPrefab, randomPosition, Quaternion.identity);
    }
}
