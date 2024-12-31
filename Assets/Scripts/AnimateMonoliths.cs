using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateAndControlMonolith : MonoBehaviour
{
    public float rotateSpeed = 50.0f; // 旋转速度
    public float moveSpeed = 5.0f; // 移动速度

    float randomTime;
    float randomHeight;
    float circleMoveDuration = 10f; // 转圈移动的持续时间
    float circleRadius = 10f; // 圆的半径

    void Start()
    {
        randomTime = Random.Range(10f, 50f);
        randomHeight = Random.Range(50f, 80f);

        AnimateUpDown();
        AnimateCircle();
    }

    void Update()
    {
        // 用户控制的旋转和移动
        RotateAndMove();
    }

    void AnimateUpDown()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMoveY(randomHeight, randomTime).SetEase(Ease.OutBack));
        seq.Append(transform.DOMoveY(4, randomTime));
        seq.AppendCallback(AnimateUpDown);
    }

    void AnimateCircle()
    {
        Vector3 circleCenter = transform.position; // 取当前位置为圆心
        float angle = 0; // 起始角度
        DOTween.To(() => angle, x => angle = x, 360, circleMoveDuration) // 从0度旋转到360度
            .SetRelative()
            .SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                float rad = Mathf.Deg2Rad * angle; // 将角度转换为弧度
                Vector3 pos = circleCenter + new Vector3(Mathf.Cos(rad) * circleRadius, 0, Mathf.Sin(rad) * circleRadius);
                transform.position = pos; // 更新物体位置
            })
            .SetLoops(-1, LoopType.Restart); // 无限循环
    }

    void RotateAndMove()
    {
        // 绕y轴旋转物体
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        // 获取前后移动的输入
        float moveVertical = Input.GetAxis("Vertical"); // W键和S键分别返回1和-1
        // 获取左右移动的输入
        float moveHorizontal = Input.GetAxis("Horizontal"); // A键和D键分别返回-1和1

        // 创建移动向量
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // 应用移动
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }
}

