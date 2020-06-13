using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vertical : MonoBehaviour
{
    private int _up = -1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * (_up * 0.04f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Vertical_Endpoint"))
        {
            
            _up *= -1;
        }
    }
}
