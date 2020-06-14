using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Balance : Enemy
{
    private void Update()
    {
        //TODO Schießen
    }    
    
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Fireball"))
        {
            Destroy(transform.parent.parent.parent.gameObject);
            Destroy(other.gameObject);
        }
    }
}
