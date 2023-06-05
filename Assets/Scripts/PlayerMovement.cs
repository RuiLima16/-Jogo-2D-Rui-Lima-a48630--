using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    
    
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk)
            {
                UpdateAnimationAndMove();
            }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
        
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        Vector2 targetVelocity = change.normalized * speed;
        myRigidbody.velocity = Vector2.Lerp(myRigidbody.velocity, targetVelocity, 0.01f);

        if (change == Vector3.zero && myRigidbody.velocity.magnitude < 0.1f)
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
