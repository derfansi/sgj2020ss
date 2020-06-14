using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    private float ttl;
    
    private void Start()
    {
        ttl = 3f;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl <= 0)
            return;
        transform.localScale = new Vector3(0.2f + ttl / 10, 0.2f + ttl / 10, 0.2f + ttl / 10);
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Endboss"))
        {
            Destroy(other.gameObject);
            StartCoroutine(toCredits());
        }
    }

    IEnumerator toCredits()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(2);
    }
}