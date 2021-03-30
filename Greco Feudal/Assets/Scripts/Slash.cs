using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public KeyCode slashKey;
    public Collider sword;
    public Movement movementScript;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(slashKey) && movementScript.grounded == true)
        {
            StartCoroutine(SlashCooldown());
        }
    }

    IEnumerator SlashCooldown()
    {
        sword.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sword.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<Enemy>().dead = true;
    }
}
