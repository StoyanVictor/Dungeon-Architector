using Cinemachine;
using UniRx;
using UnityEngine;

public class CineMachineExtension : MonoBehaviour
{
    private CinemachineFreeLook freeLook;
    public TargetMover targetMover;
    public string mouseX = "Mouse X";
    public string mouseY = "Mouse Y";

    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();

        freeLook.m_XAxis.m_InputAxisName = "";
        freeLook.m_YAxis.m_InputAxisName = "";

        Observable.EveryUpdate().Subscribe(_ => Move(Input.GetMouseButton(1)))
            .AddTo(this);
    }

    private void Move(bool canMove)
    {
        if (canMove)
        {
            freeLook.m_XAxis.m_InputAxisValue = Input.GetAxis(mouseX);
            freeLook.m_YAxis.m_InputAxisValue = Input.GetAxis(mouseY);
            targetMover.MoveCamera();
        }
        else
        {
            freeLook.m_XAxis.m_InputAxisValue = 0;
            freeLook.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
