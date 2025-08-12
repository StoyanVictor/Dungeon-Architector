using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyHeroHealth : MonoBehaviour,IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private EnemyConfigurator configurator;
    private EventBus eventBus;

    private void SetupHealth() => health = configurator.GetHpCount();

    [Inject]
    public void Construct(EventBus _eventBus)
    {
        eventBus = _eventBus;
    }
    
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
        SetupHealth();
        SetMaxHP(health);
    }

    private void PlayerDeath()
    {
        Debug.LogWarning("Enemy Died");
        eventBus.EnemyDies();
        Destroy(this.gameObject);
    }
}