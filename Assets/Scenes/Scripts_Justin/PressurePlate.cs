using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    
        

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Rock"))
        {
            //TODO
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Rock"))
        {
            //TODO
        }
    }
}