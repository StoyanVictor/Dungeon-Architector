using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float fastMultiplier = 3f;

    [Header("Camera Reference")]
    public Transform cameraTransform; // сюда кинь MainCamera

    void Update()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * fastMultiplier : moveSpeed;

        Vector3 direction = Vector3.zero;

        // направление вперёд/назад по камере (обнуляем Y, чтобы не заваливаться при наклоне)
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        // направление влево/вправо
        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        if (Input.GetKey(KeyCode.W)) direction += forward;
        if (Input.GetKey(KeyCode.S)) direction -= forward;
        if (Input.GetKey(KeyCode.A)) direction -= right;
        if (Input.GetKey(KeyCode.D)) direction += right;
        if (Input.GetKey(KeyCode.E)) direction += Vector3.up;
        if (Input.GetKey(KeyCode.Q)) direction -= Vector3.up;

        transform.position += direction * speed * Time.deltaTime;
    }
}