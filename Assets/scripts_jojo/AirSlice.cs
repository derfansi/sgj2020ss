using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSlice : MonoBehaviour
{
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        direction = GetComponent<Rigidbody2D>().velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
        
    }


    IEnumerator Die()
    {
        yield return new WaitForSeconds(5);
        
        Destroy(gameObject);
    }
    
}
