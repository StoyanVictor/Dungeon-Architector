using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TimerShower : MonoBehaviour
{
    [SerializeField] private int timerDuration = 10;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private FabricCreatingSfxPlayer SfxPlayer;
    private int standartTimerValue;

    public void ShowZoomTimerText(TextMeshProUGUI text,float duration)
    {
        text.transform.localScale = new Vector3(0, 0, 0);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(text.transform.DOScale(Vector3.one, duration));
        sequence.Play();
    }

    public async UniTask StartTimer()
    {
        await Timer();
    }

    public void ResetTimer() => timerDuration = standartTimerValue;
    
    private void Start()
    {
        standartTimerValue = timerDuration;
    }

    private async UniTask Timer()
    {
        while (timerDuration > 0)
        {
            timerText.text = timerDuration.ToString();
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            timerDuration--;
            SfxPlayer.PlayCreateSFX();
            ShowZoomTimerText(timerText, 0.4f);
        }
        timerText.text = "0";
        ResetTimer();
    }
}