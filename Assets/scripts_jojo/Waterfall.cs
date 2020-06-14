using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Waterfall : Interactable
{
    public GameObject wgc;
    public bool cmp = false;
    private GameObject _current;
    public GameObject wf;
    private GameObject _waterFloor;
    
    private List<GameObject> _floors = new List<GameObject>();
    private List<GameObject> _creatorsL = new List<GameObject>();
    private Dictionary<GameObject, Coroutine> _creators = new Dictionary<GameObject, Coroutine>();

    private void Update()
    {
        if (active)
        {
            if (cursorScript.down && !cmp)
            {
                cmp = !cmp;
                MouseDown();
            }
        }

        if (activated)
        {
            if(!cursorScript.down && cmp)
            {
                cmp = !cmp;
                MouseUp();
            }
        }
    }


    public override void MouseDown()
    {
        if (cursorScript.element == MyCursor.Element.WATER)
        {
            _current = Instantiate(wgc);
            _current.transform.parent = cursor.transform;
            _current.transform.localPosition = Vector3.zero;
            _creatorsL.Add(_current);
            _creators[_current] = StartCoroutine(DestroyGroundCreator());
            //current = Instantiate(whip, cursor.transform.position, Quaternion.identity);
            //current.GetComponent<Whip>().Config(cursor, cursorScript);
        }
    }

    public override void MouseUp()
    {
        if (cursorScript.element == MyCursor.Element.WATER)
        {
            //current.GetComponent<Whip>().isHeld = false;
            StopCoroutine(_creators[_current]);
            _creators.Remove(_current);
            Vector2 pos = _current.transform.position;
            
            Destroy(_current);
            _creatorsL.RemoveAt(0);
            
            _waterFloor = Instantiate(wf);
            _waterFloor.transform.position = pos;
            _floors.Add(_waterFloor);
            StartCoroutine(DestroyGround());
        }
    }

    IEnumerator DestroyGroundCreator()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(_creatorsL[0]);
        _creatorsL.RemoveAt(0);
        cmp = false;
    }

    IEnumerator DestroyGround()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(_floors[0]);
        _floors.RemoveAt(0);
    }
}
