using Cinemachine;
using UnityEngine;

public class CineMachineExtension : MonoBehaviour
{
    private CinemachineFreeLook freeLook;

    public string mouseX = "Mouse X";
    public string mouseY = "Mouse Y";

    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();

        // Чтобы Cinemachine не ловил мышь напрямую
        freeLook.m_XAxis.m_InputAxisName = "";
        freeLook.m_YAxis.m_InputAxisName = "";
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // ПКМ
        {
            freeLook.m_XAxis.m_InputAxisValue = Input.GetAxis(mouseX);
            freeLook.m_YAxis.m_InputAxisValue = Input.GetAxis(mouseY);
        }
        else
        {
            freeLook.m_XAxis.m_InputAxisValue = 0;
            freeLook.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
