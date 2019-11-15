using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{

    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject c1, c2, c3, c4, c5, coin;

    void Start()
    {
        SpawnCandies();
    }

    public void SpawnCandies()
    {
        int i = Random.Range(0, 9);

        switch (i)
        {
            case 0:
            case 2:
            case 4:
                Instantiate(c1, spawnPoint.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(c2, spawnPoint.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(c3, spawnPoint.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(c4, spawnPoint.position, Quaternion.identity);
                break;
            case 6:
                Instantiate(c5, spawnPoint.position, Quaternion.identity);
                break;
            case 7:
            case 8:
                Instantiate(coin, spawnPoint.position, Quaternion.identity);
                break;
        }   
    }
}
