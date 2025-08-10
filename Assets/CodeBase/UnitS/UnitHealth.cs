using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour,IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private Slider hpSlider;
    
    
    public void SetMaxHP(float maxHP)
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = maxHP;
    }

    public void SetHP(float currentHP)
    {
        hpSlider.value = currentHP;
    }
    
    public void TakeDamage(int dmg)
    {
        if (health - dmg > 0)
        {
            health -= dmg;
            SetHP(health);
        }
        else
            PlayerDeath();
    }

    private void Awake()
    {
        SetMaxHP(health);
    }

    private void PlayerDeath()
    {
        Debug.LogWarning("Unit Died");
        Destroy(this.gameObject);
    }
}