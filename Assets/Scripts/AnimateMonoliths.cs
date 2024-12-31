using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateAndControlMonolith : MonoBehaviour
{
    public float rotateSpeed = 50.0f; // ��ת�ٶ�
    public float moveSpeed = 5.0f; // �ƶ��ٶ�

    float randomTime;
    float randomHeight;
    float circleMoveDuration = 10f; // תȦ�ƶ��ĳ���ʱ��
    float circleRadius = 10f; // Բ�İ뾶

    void Start()
    {
        randomTime = Random.Range(10f, 50f);
        randomHeight = Random.Range(50f, 80f);

        AnimateUpDown();
        AnimateCircle();
    }

    void Update()
    {
        // �û����Ƶ���ת���ƶ�
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
        Vector3 circleCenter = transform.position; // ȡ��ǰλ��ΪԲ��
        float angle = 0; // ��ʼ�Ƕ�
        DOTween.To(() => angle, x => angle = x, 360, circleMoveDuration) // ��0����ת��360��
            .SetRelative()
            .SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                float rad = Mathf.Deg2Rad * angle; // ���Ƕ�ת��Ϊ����
                Vector3 pos = circleCenter + new Vector3(Mathf.Cos(rad) * circleRadius, 0, Mathf.Sin(rad) * circleRadius);
                transform.position = pos; // ��������λ��
            })
            .SetLoops(-1, LoopType.Restart); // ����ѭ��
    }

    void RotateAndMove()
    {
        // ��y����ת����
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        // ��ȡǰ���ƶ�������
        float moveVertical = Input.GetAxis("Vertical"); // W����S���ֱ𷵻�1��-1
        // ��ȡ�����ƶ�������
        float moveHorizontal = Input.GetAxis("Horizontal"); // A����D���ֱ𷵻�-1��1

        // �����ƶ�����
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Ӧ���ƶ�
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }
}

