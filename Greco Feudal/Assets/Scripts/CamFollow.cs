using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    public GameObject cam;

    void Update()
    {
        cam.transform.position = player.transform.position + offset;
    }
}