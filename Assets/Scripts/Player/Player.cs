using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed = 0.1f;
    private Animator animator = null;
    private Rigidbody2D rigidbody = null;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        var position = transform.position;

        bool walking = false;
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= Speed;
            walking = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += Speed;
            walking = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position.y += Speed;
            walking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= Speed;
            walking = true;
        }

        if (walking == true)
        {
            animator.SetTrigger("playerWalk");
            rigidbody.MovePosition(position);            
        } else
        {
            animator.SetTrigger("playerStopWalk");
        }
    }
}
