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
