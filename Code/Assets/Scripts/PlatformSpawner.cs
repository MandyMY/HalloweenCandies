using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;
    public float offset = 1.6f;
    public float lmin = -4f, lmax = -1.5f;
    public float rmin = 1.5f, rmax = 4f;

    private int count;
    private float flyGhostOffset = 5;

    [SerializeField]
    private GameObject platformL;
    [SerializeField]
    private GameObject platformR;
    [SerializeField]
    private GameObject flyGhost;
    [SerializeField]
    private GameObject vik;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    void Start()
    {
        SpawnPlatforms();  
    }

    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        SpawnVik();
        for (int i = 0; i < 6; i++)
        {
            if (count % 2 == 0)
            {
                temp.x = Random.Range(lmin, lmax);
                Instantiate(platformL, temp, Quaternion.identity);
            }
            else
            {
                temp.x = Random.Range(rmin, rmax);
                Instantiate(platformR, temp, Quaternion.identity);
            }

            temp.y += offset;
            count++;
        }
        if (Random.Range(0, 9) < 2)
            SpawnFlyGhost();
    }

    public void SpawnFlyGhost()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(lmin + 1, rmax - 1);
        temp.y += flyGhostOffset;
        Instantiate(flyGhost, temp, Quaternion.identity);
    }

    public void SpawnVik()
    {
        Vector2 temp = transform.position;
        temp.x = lmin + 1;
        temp.y += 10;
        Instantiate(vik, temp, Quaternion.identity);
    }
}
