using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateCube : MonoBehaviour
{
    float randomTime;
    float randomHeight;
    Vector3[] circlePath; // �洢Բ��·���ĵ�

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(1f, 5f);
        randomHeight = Random.Range(1f, 5f);

        AnimateUpDown();
        InitializeCirclePath();
        AnimateCircle();
    }

    void AnimateUpDown()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMoveY(randomHeight, randomTime).SetEase(Ease.OutBack));
        seq.Append(transform.DOMoveY(5f, randomTime));
        seq.AppendCallback(AnimateUpDown);
    }

    void InitializeCirclePath()
    {
        int points = 20; // Բ��·���ĵ���
        circlePath = new Vector3[points];
        float angleStep = 360f / points; // ÿ����֮��ĽǶ�

        for (int i = 0; i < points; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad; // ���Ƕ�ת��Ϊ����
            circlePath[i] = new Vector3(Mathf.Cos(angle) * 2f, 0f, Mathf.Sin(angle) * 2f); // ����Բ�İ뾶Ϊ2
        }
    }

    void AnimateCircle()
    {
        transform.DOPath(circlePath, 2f, PathType.CatmullRom, PathMode.Full3D)
            .SetOptions(true)
            .SetLookAt(0.01f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }
}
