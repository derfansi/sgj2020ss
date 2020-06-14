using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FallFromPlatform : Enemy
{
    private int _right = -1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * (_right * 0.04f);
        if (WallCheck())
        {
            _right *= -1;
        }
    }

    bool WallCheck()
    {
        return Physics2D.Raycast(transform.position, Vector3.right * _right, 0.55f);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {        
        if (other.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            _right *= -1;
        }
        if (other.gameObject.tag.Equals("Fireball"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
