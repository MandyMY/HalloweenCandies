using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= transform.position.y)
        {
            Vector3 temp = transform.position;
            temp.y = player.transform.position.y;
            transform.position = temp;
        }
    }
}
