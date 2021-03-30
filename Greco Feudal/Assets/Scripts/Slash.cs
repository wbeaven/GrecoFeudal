using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public KeyCode slash;
    public Collider sword;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(slash))
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
