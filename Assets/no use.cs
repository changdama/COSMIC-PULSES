using UnityEngine;

public class RotateAroundSelf : MonoBehaviour
{
    public float rotationSpeed = 1f; // 每秒旋转的角度

    void Update()
    {
        // 绕y轴旋转
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
