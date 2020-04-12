using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk, attack, interact, pathfinding
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState      currentState;
    public float            speed;
    private Rigidbody2D     myRigidbody;
    private Vector3         change;
    private Animator        animator;
    void Start()
    {
        currentState    = PlayerState.walk;
        animator        = GetComponent<Animator>();
        myRigidbody     = GetComponent<Rigidbody2D>();

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");


        // path finding 우선.
        if (currentState != PlayerState.attack && Input.GetButtonDown("attack"))
        {
            StartCoroutine( AttackCo() );
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimatorAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;

        yield return null;

        animator.SetBool("attacking", false);

        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private void UpdateAnimatorAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
