using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int moneyCount;
        [SerializeField] private TextMeshProUGUI moneyCountText;
        private EventBus eventBus;

        [Inject]
        public void Construct(EventBus _eventBus)
        {
            eventBus = _eventBus;
        }

        private void AddMoney()
        {
            moneyCount += 50;
        }

        private void Start()
        {
            eventBus.OnEnemyDied += AddMoney;
        }

        private void Update()
        {
            moneyCountText.text = "Money: "+ moneyCount.ToString();
        }

        public bool SpendMoney(int count)
        {
            if (moneyCount - count >= 0)
            {
                moneyCount -= count;
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}