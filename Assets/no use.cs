using UnityEngine;

public class RotateAroundSelf : MonoBehaviour
{
    public float rotationSpeed = 1f; // ÿ����ת�ĽǶ�

    void Update()
    {
        // ��y����ת
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
