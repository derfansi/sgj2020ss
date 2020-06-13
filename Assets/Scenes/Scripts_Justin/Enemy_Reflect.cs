using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Reflect : MonoBehaviour
{
    private int _right = -1;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * (_right * 0.04f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Reflect_Endpoint"))
        {
            
            _right *= -1;
        }
    }
    
    //TODO reflect logic
}
