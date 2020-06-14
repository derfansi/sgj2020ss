using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endboss : Enemy
{
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Fireball"))
        {
            Destroy(gameObject);
            StartCoroutine(toCredits());
        }
    }

    IEnumerator toCredits()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(2);
    }
}
