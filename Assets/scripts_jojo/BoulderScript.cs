using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BoulderScript : Interactable
{
   private Vector2 cursorPos;
   private Vector2 lastPosition;
   private Rigidbody2D _rigidbody;
   private float gravityScale;
   private bool isHeld;
   private bool cmp = false;
   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
   }


   private void Update()
   {
      //update position if held
      if (isHeld)
      {
         lastPosition = transform.position;
         cursorPos = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
         transform.localPosition = new Vector2(cursorPos.x, cursorPos.y);
      }
      //check for cursor input and invoke functions accordingly
      if (active)
      {
         if (cursorScript.down && !cmp)
         {
            cmp = !cmp;
            MouseDown();
         }
         else if (!cursorScript.down && cmp)
         {
            cmp = !cmp;
            MouseUp();
         }
      }
      
   }

   
   public override void MouseDown()
   {
      Debug.Log("down");
      this.cursor = cursor;
      isHeld = true;
      cursorScript.speed /= _rigidbody.mass * 2f;
      gravityScale = _rigidbody.gravityScale;
      _rigidbody.gravityScale = 0;
   }

   public override void MouseUp()
   {
      Debug.Log("up");
      Vector2 throwVector = new Vector2(transform.position.x, transform.position.y) - lastPosition;
      float speed = throwVector.magnitude / (Time.deltaTime * _rigidbody.mass);
      Vector2 throwVelocity = speed * throwVector.normalized;
      _rigidbody.velocity = throwVelocity;
      _rigidbody.gravityScale = gravityScale;
      cursorScript.speed *= _rigidbody.mass * 2f;
      isHeld = false;
   }

   
}
