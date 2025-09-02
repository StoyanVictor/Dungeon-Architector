using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;
namespace CodeBase
{
    public class Bank : MonoBehaviour
    {
        [FoldoutGroup("Настройка экономики")]
        [Tooltip("С помощью настройки этой графы мы может настраивать как будет увеличиваться доход от убийста врагов относительно уровня")]
        [SerializeField]private AnimationCurve economicProgression;
        [SerializeField] private ReactiveProperty<int> moneyCount = new ReactiveProperty<int>(100);
        [SerializeField] private TextMeshProUGUI moneyCountText;
        
        private LevelSwitcher levelSwitcher;
        private EventBus eventBus;
        


        [Inject]
        public void Construct(EventBus _eventBus, LevelSwitcher _levelSwitcher)
        {
            eventBus = _eventBus;
            levelSwitcher = _levelSwitcher;
        }

        private void AddMoney()
        {
            moneyCount.Value += (int)economicProgression.Evaluate(levelSwitcher.GetCurrentLvlIndex());
        }

        private void Start()
        {
            eventBus.OnEnemyDied += AddMoney;
            moneyCount.Subscribe(newValue => moneyCountText.text = "Money: " + moneyCount.ToString());
        }

        public bool SpendMoney(int count)
        {
            if (moneyCount.Value - count >= 0)
            {
                moneyCount.Value -= count;
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}