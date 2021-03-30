using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHp = 100;
    public Slider healthBar;

    void Start()
    {
        healthBar.maxValue = maxHp;
        healthBar.value = 10000;
    }

    void Update()
    {
        healthBar.value =- 1 * Time.deltaTime;
    }

    void LoseHealth()
    {
        Success();
    }

    void Success()
    {
        //if player hits QTE lose health
    }
}
