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
    private C2Client        client;

    public int Level { get; set; } = 1;
    public int Exp { get; set; } = 0;

    [SerializeField] private Stat hp;
    [SerializeField] private Stat mp;

    void Start()
    {
        hp.Initialize(200, 200);
        mp.Initialize(200, 200);

        currentState    = PlayerState.walk;
        animator        = GetComponent<Animator>();
        myRigidbody     = GetComponent<Rigidbody2D>();

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);

        //client = new C2Client(this);
    }

    // Update is called once per frame
    void Update()
    {
        //client.session.Update();
        if (UIManager.Instance.CurrentState != UIState.Play)
        {
            return;
        }


        // hp bar test
        if (Input.GetKeyDown(KeyCode.I))        
        {
            hp.CurrentValue -= 10;
            mp.CurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            hp.CurrentValue += 10;
            mp.CurrentValue += 10;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");


        // path finding 우선.
        if (currentState != PlayerState.attack && Input.GetButtonDown("attack"))
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimatorAndMove();
        }
    }



    //void FixedUpdate()
    //{
    //    change = Vector3.zero;
    //    change.x = Input.GetAxisRaw("Horizontal");
    //    change.y = Input.GetAxisRaw("Vertical");


    //    // path finding 우선.
    //    if (currentState != PlayerState.attack && Input.GetButtonDown("attack"))
    //    {
    //        StartCoroutine(AttackCo());
    //    }
    //    else if (currentState == PlayerState.walk)
    //    {
    //        UpdateAnimatorAndMove();
    //    }
    //}


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
        myRigidbody.MovePosition(transform.position + change * ( speed * Time.fixedDeltaTime));
    }
}
