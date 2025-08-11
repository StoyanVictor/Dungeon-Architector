using System.Collections;
using TMPro;
using UnityEngine;

public class TimerShower : MonoBehaviour
{
    [SerializeField] private int timerDuration = 10;
    private int standartTimerValue;
    [SerializeField] private TextMeshProUGUI timerText;

    public int GetTimerDuration() => timerDuration;

    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());

    }

    public void ResetTimer() => timerDuration = standartTimerValue;
    
    private void Start()
    {
        standartTimerValue = timerDuration;
    }

    private IEnumerator TimerCoroutine()
    {
        while (timerDuration > 0)
        {
            timerText.text = timerDuration.ToString();
            yield return new WaitForSeconds(1f);
            timerDuration--;
        }

        timerText.text = "0";
        ResetTimer();
    }
}