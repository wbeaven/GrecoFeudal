using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool dead = false;
    public Collider collision;

    private void Update()
    {
        Killed();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Damage();
    }
    void Damage() //When player runs into enemy, player loses health
    {
        //deal damage to player's healthbar
    }
    void Killed() //When player attacks enemy it is set to dead and it's trigger is disabled
    {
        if (dead == true)
        {
            collision.enabled = false;
            //Play animation
            Destroy(gameObject, 1);
        }
    }
}
