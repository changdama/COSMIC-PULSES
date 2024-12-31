using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float rotateSpeed = 50.0f; // 旋转速度，每秒旋转的度数
    public float moveSpeed = 50.0f; // 移动速度，单位为单位/秒

    void Update()
    {
        // 绕y轴旋转物体
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        // 获取前后移动的输入
        float moveVertical = Input.GetAxis("Vertical"); // W键和S键分别返回1和-1
        // 获取左右移动的输入
        float moveHorizontal = Input.GetAxis("Horizontal"); // A键和D键分别返回-1和1

        // 创建移动向量
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // 应用移动和旋转
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }
}



