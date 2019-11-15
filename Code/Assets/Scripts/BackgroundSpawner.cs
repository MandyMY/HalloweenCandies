using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float heighest;

    void Start()
    {
        bgs = GameObject.FindGameObjectsWithTag("bg");
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;

        for (int i = 0; i < bgs.Length; i++)
        {
            if (bgs[i].transform.position.y > heighest)
                heighest = bgs[i].transform.position.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bg")
        {
            Vector3 temp = collision.transform.position;
            if (temp.y.Equals(heighest))
            {
                for (int i = 0; i < bgs.Length; i++)
                {
                    if (!bgs[i].gameObject.activeInHierarchy)
                    {
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);
                        heighest = temp.y;
                        PlatformSpawner.instance.SpawnPlatforms();
                    }
                }
            }
        }
    }
}
