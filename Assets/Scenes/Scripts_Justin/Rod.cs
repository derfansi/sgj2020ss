using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    private int _right = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, _right * 0.2f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Rod_Endpoint"))
        {
            
            _right *= -1;
        }
    }
}
