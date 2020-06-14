using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconChanger : MonoBehaviour
{
    public Image currentIcon;
    public Sprite earth, fire, air, water;

    public void SwitchTo(MyCursor.Element element)
    {
        switch (element)
        {
            case MyCursor.Element.WATER:
                currentIcon.sprite = water;
                break;
            case MyCursor.Element.FIRE:
                currentIcon.sprite = fire;
                break;
            case MyCursor.Element.EARTH:
                currentIcon.sprite = earth;
                break;
            case MyCursor.Element.AIR:
                currentIcon.sprite = air;
                break;
        }
    }
}
