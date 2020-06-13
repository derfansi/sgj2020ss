using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Enemy_StayOnPlatform : MonoBehaviour
{
    private int _right = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * (_right * 0.04f);
        if (!GroundCheck() || WallCheck())
        {
            _right *= -1;
        }
    }

    bool GroundCheck()
    {
        return Physics2D.Raycast(transform.position, Vector3.down, 0.55f);
    }

    bool WallCheck()
    {
        return Physics2D.Raycast(transform.position, Vector3.right * _right, 0.55f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            _right *= -1;
        }
    }
}
