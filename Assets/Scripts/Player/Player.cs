using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed = 0.1f;
    private Animator animator = null;
    private Rigidbody rigidbody = null;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float xmove = 0f, ymove = 0f;

        bool walking = false;
        if (Input.GetKey(KeyCode.A))
        {
            xmove -= Speed;
            walking = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xmove += Speed;
            walking = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ymove += Speed;
            walking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ymove -= Speed;
            walking = true;
        }

        if (walking == true)
        {
            Vector3 movementVector = transform.position + ((new Vector3(xmove, ymove)).normalized * Speed);

            animator.SetTrigger("playerWalk");
            rigidbody.MovePosition(movementVector);
        } else
        {
            animator.SetTrigger("playerStopWalk");
        }
    }
}
