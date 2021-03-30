using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    public float moveVelocity;
    public KeyCode up;
    public KeyCode down;

    public Transform m_groundCheckPoint;
    public float m_groundDistance = 0.4f;
    public LayerMask m_groundMask;
    public bool grounded;
    //Vector3 velocity;

    void Update()
    {
        grounded = HitGroundCheck();
        Run();
        Jump();
        Slide();
    }

    void Run()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(moveVelocity, GetComponent<Rigidbody>().velocity.y);
    }
    void Jump()
    {
        if (Input.GetKeyDown(up))
        {
            if (grounded == true)
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jump);
        }
    }
    void Slide()
    {
        if (Input.GetKeyDown(down))
        {
            if (grounded == true)
                StartCoroutine(SlideTime());
                //GetComponent<BoxCollider2D>().size = new Vector2(1f, 0.5f);

        }
    }

    IEnumerator SlideTime()
    {
        GetComponent<Transform>().localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(1);
        GetComponent<Transform>().localScale = new Vector3(1,2,1);

    }

    bool HitGroundCheck()
    {
        bool isGrounded = Physics.CheckSphere(m_groundCheckPoint.position, m_groundDistance, m_groundMask);

        //Gravity ground check
        /*if (isGrounded && truevelocity.y < 0)
        {
            truevelocity.y = -2f;
        }*/

        return isGrounded;
    }
}
