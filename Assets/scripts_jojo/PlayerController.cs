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
            _rigidbody.velocity = new Vector2(baseVelocity, _rigidbody.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            _rigidbody.velocity = new Vector2(-baseVelocity, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpVelocity);
        }
        
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    
}
