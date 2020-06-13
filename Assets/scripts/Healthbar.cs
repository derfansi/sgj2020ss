using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider healthbar;

    public void SetHealth(int health)
    {
        healthbar.value = health;
    }

    public void SetMaxHealth(int health)
    {
        healthbar.maxValue = health;
    }
}
