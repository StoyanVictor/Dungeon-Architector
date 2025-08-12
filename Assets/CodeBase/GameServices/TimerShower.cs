using System.Collections;
using TMPro;
using UnityEngine;

public class TimerShower : MonoBehaviour
{
    [SerializeField] private int timerDuration = 10;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private FabricCreatingSfxPlayer SfxPlayer;
    private int standartTimerValue;

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
            SfxPlayer.PlayCreateSFX();
        }
        timerText.text = "0";
        ResetTimer();
        Debug.LogError("Reset timer was lauched!");
    }
}