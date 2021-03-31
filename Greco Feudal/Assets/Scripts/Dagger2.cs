using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger2 : MonoBehaviour
{
    DaggerDetect detectScript;
    Vector3 pos;
    GameObject throwPos;
    public int speed = 20;

    private void Awake()
    {
        throwPos = GameObject.FindGameObjectWithTag("ThrowPoint2");
        detectScript = throwPos.GetComponent<DaggerDetect>();
    }
    private void Start()
    {
        pos = detectScript.enemyPos;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, pos, speed * Time.deltaTime);
        if (transform.position == pos)
        {
            detectScript.enemy.GetComponent<Enemy>().dead = true;
            Destroy(gameObject, 0);
        }
    }
}
