using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public KeyCode daggerKey;
    private Vector3 throwPoint;
    public Transform daggerPrefab;
    public Movement movementScript;

    public Vector3 playerPosition;                // Default 0, 0, 0.  Turret is in center of scene, value not needed.
    public Vector3 distanceDifference;            // Difference between the target and turret.
    public float oldDistance = Mathf.Infinity;    // Starts at infinity to always ensure IF loop runs to detect closest enemy.
    public float currentDistance;                 // The sqrMagnitude of the difference in distance
    public GameObject enemy;                      // Current closest enemy
    public GameObject closest;                    // Assigned as closest target
    public GameObject[] targets;                  // Array to load every target as they enter trigger
    public bool enemyInRange;

    void Update()
    {
        Throw();
        throwPoint = transform.position;
    }

    void Throw()
    {
        if (Input.GetKeyDown(daggerKey) && movementScript.grounded == false)
        {
            //StartCoroutine(DaggerCooldown());
            throwPoint = transform.position;
            Instantiate(daggerPrefab, throwPoint, Quaternion.identity);
            Vector3.MoveTowards(throwPoint,closest,5);
        }
    }

    /*IEnumerator DaggerCooldown()
    {
        sword.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sword.enabled = false;
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<Enemy>().dead = true;
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject target in targets)
            {
                distanceDifference = target.transform.position - playerPosition;
                currentDistance = distanceDifference.sqrMagnitude;
                if (currentDistance < oldDistance)
                {
                    closest = target;
                    enemy = closest;
                    oldDistance = currentDistance;
                }
            }
            oldDistance = Mathf.Infinity;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = false;
        }
    }
}
