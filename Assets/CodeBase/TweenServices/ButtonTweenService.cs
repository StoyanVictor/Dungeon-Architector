using DG.Tweening;
using UnityEngine;

public class ButtonTweenService 
{

    public void PressButtonShakeTween(RectTransform buttonTransform)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(buttonTransform.DOShakeScale(0.2f));
        sequence.Play();
        var returnBack = sequence.onComplete = () => ReturnBack(buttonTransform);
        sequence.OnComplete(returnBack);
    }

    private void ReturnBack(RectTransform transform)
    {
        transform.localScale = Vector3.one;
    }
}
