using TMPro;
using UniRx;
using UnityEngine;
using Zenject;
namespace CodeBase
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private ReactiveProperty<int> moneyCount = new ReactiveProperty<int>(100);
        [SerializeField] private TextMeshProUGUI moneyCountText;
        private EventBus eventBus;

        [Inject]
        public void Construct(EventBus _eventBus)
        {
            eventBus = _eventBus;
        }

        private void AddMoney()
        {
            moneyCount.Value += 50;
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