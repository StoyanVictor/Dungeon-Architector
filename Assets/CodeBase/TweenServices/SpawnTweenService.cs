using DG.Tweening;
using UnityEngine;

namespace CodeBase.TweenServices
{
    public class SpawnTweenService
    {
        
        public void SpawnScaleTween(Vector3 initialScale,GameObject obj, float duration)
        {
            obj.transform.localScale = new Vector3(0, 0, 0);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(obj.transform.DOScale(initialScale, duration));
            sequence.Play();
        }
    }
}