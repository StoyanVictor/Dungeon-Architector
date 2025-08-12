using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour,IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private UnitConfigurator configurator;
    private void SetupHealthCount(UnitConfigurator _configurator) => health = _configurator.GetHpCount();
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

    private void Start()
    {
        Debug.LogError(configurator);
        SetupHealthCount(configurator);
        SetMaxHP(health);
    }

    private void PlayerDeath()
    {
        Debug.LogWarning("Unit Died");
        Destroy(this.gameObject);
    }
}