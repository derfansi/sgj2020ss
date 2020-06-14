using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableObject : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Fireball"))
        {
            // TODO make object Burn
            StartCoroutine(BurnObject());
        }
    }

    IEnumerator BurnObject()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
