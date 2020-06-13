using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Interactable
{
    public bool hold;

    public float charge = 0;
    public float maxCharge = 5 ;
    public float chargeSpeed = 1;

    public GameObject player;
    public Rigidbody2D p_rb;
    public Vector2 cursorPos;
    public Vector2 playerPos;

    public GameObject airSlice;
    public float attackSpeed = 6;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        p_rb = player.GetComponent<Rigidbody2D>();
        cursor = gameObject;
        cursorScript = GetComponent<MyCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cursorScript.element == MyCursor.Element.AIR)
        {
            playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            cursorPos = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
            if (hold && charge < maxCharge)
            {
                charge += Time.deltaTime * chargeSpeed * 10;
                Debug.Log(charge);
            }

            if (charge > maxCharge)
            {
                charge = maxCharge;
            }
        }
        
    }

    public override void MouseDown()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            AirAttack();
        }
        else
        {
            hold = true;
        }
        
    }
    
    public override void MouseUp()
    {
        hold = false;
        StartCoroutine(AirBurst());
    }



    IEnumerator AirBurst()
    {
        player.GetComponent<PlayerController>().airDash = true;
        direction = cursorPos - playerPos;
        Vector2 pushDir = (-direction.normalized) * charge;
        Debug.Log(pushDir);
        p_rb.AddRelativeForce(pushDir*5, ForceMode2D.Impulse);
        charge = 0;
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<PlayerController>().airDash = false;
    }

    public void AirAttack()
    {
        direction = (cursorPos - playerPos).normalized;
        GameObject gameObject = Instantiate(airSlice, playerPos, Quaternion.identity);
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction*attackSpeed, ForceMode2D.Impulse);
    }
}
