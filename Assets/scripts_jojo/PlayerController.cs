using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float baseVelocity = 5f;
    public float jumpVelocity = 8f; 
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 3f;
    public bool isGrounded;
    public bool airDash;

    public Animator animator;

    [SerializeField] private Transform groundCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKey("d"))
        {
            if (isGrounded)
            {
                _rigidbody.velocity = new Vector2(baseVelocity, _rigidbody.velocity.y);
            }
            else
            {
                _rigidbody.velocity = new Vector2(baseVelocity * 1.2f, _rigidbody.velocity.y);
            }
            
        }
        else if (Input.GetKey("a"))
        {
            if (isGrounded)
            {
                _rigidbody.velocity = new Vector2(-baseVelocity, _rigidbody.velocity.y);
            }
            else
            {
                _rigidbody.velocity = new Vector2(-baseVelocity * 1.2f , _rigidbody.velocity.y);
            }
        }
        else if(isGrounded && !airDash)
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
            animator.SetTrigger("isJumping");
        }
        
       

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        animator.SetFloat("PlayerSpeed", Math.Abs(_rigidbody.velocity.x));
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y < 0)
        {
            Vector2 dir = Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1);
            _rigidbody.AddForce(dir);
        }
        else if(_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            Vector2 dir = Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1);
            _rigidbody.AddForce(dir); 
        }
    }
}
