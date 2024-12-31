using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float rotateSpeed = 50.0f; // ��ת�ٶȣ�ÿ����ת�Ķ���
    public float moveSpeed = 50.0f; // �ƶ��ٶȣ���λΪ��λ/��

    void Update()
    {
        // ��y����ת����
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        // ��ȡǰ���ƶ�������
        float moveVertical = Input.GetAxis("Vertical"); // W����S���ֱ𷵻�1��-1
        // ��ȡ�����ƶ�������
        float moveHorizontal = Input.GetAxis("Horizontal"); // A����D���ֱ𷵻�-1��1

        // �����ƶ�����
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Ӧ���ƶ�����ת
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }
}



