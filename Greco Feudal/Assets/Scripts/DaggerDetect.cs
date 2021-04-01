using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerDetect : MonoBehaviour
{
    public KeyCode daggerKey;
    private Vector3 throwPoint;
    public Transform daggerPrefab;
    public Movement movementScript;
    public Collider daggerRange;
    public Vector3 enemyPos;
    public GameObject enemy;

    private void Start()
    {
        enemy = null;
    }
    void Update()
    {
        Throw();
    }

    void Throw() // Activates move when attack button is pressed
    {
        if (Input.GetKeyDown(daggerKey) && movementScript.grounded == false)
        {
            daggerRange.enabled = true;

            //StartCoroutine(DaggerCooldown()); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("this enemy is real");
            throwPoint = transform.position;
            enemyPos = other.transform.position;
            enemy = other.gameObject;
            Instantiate(daggerPrefab, throwPoint, Quaternion.identity);
        }
        else
        {
            daggerRange.enabled = false;
        }
    }

    /*IEnumerator DaggerCooldown() // Makes sure you can't spam the move
    {
        sword.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sword.enabled = false;
    }*/
}
