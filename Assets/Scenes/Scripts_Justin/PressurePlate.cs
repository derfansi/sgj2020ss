using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool activated;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Rock"))
        {
            activated = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Rock"))
        {
            activated = false;
        }
    }
}