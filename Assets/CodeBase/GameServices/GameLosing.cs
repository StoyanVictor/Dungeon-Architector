using UnityEngine;
public class GameLosing : MonoBehaviour
{
    [SerializeField] private GameObject lossingScreen;
    [SerializeField] private RectTransform mainCanvas;
    [Header("Кривая роста урона")]
    public AnimationCurve damageCurve;
    private async void OnDestroy()
    {
        Instantiate(lossingScreen, mainCanvas); 
        print($"<color=red><size=20>You lose!</size></color>");
    }
}
