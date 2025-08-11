using System;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int moneyCount;
        [SerializeField] private TextMeshProUGUI moneyCountText;

        
        private void AddMoney()
        {
            moneyCount += 50;
        }

        private void Start()
        {
            EventBus.Instance.OnEnemyDied += AddMoney;
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