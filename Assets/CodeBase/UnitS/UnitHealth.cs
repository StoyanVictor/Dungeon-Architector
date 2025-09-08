using CodeBase;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour,IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private UnitConfigurator configurator;
    public GameObject objectFromUnitInside;

    public IUnitDeathBehaviourStrategy deathStrategy;
    
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
        SetupHealthCount(configurator);
        SetMaxHP(health);
        configurator.OnLevelUp += UpgradeHealthComponent;
    }

    private void UpgradeHealthComponent()
    {
        SetupHealthCount(configurator);
        SetMaxHP(health);
        SetHP(health);
    }

    private void PlayerDeath()
    {
        deathStrategy.Die(this);
        Destroy(this.gameObject);
    }
}