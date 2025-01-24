using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateAndControlMonolith : MonoBehaviour
{
    public float rotateSpeed = 50.0f; 
    public float moveSpeed = 5.0f; 

    float randomTime;
    float randomHeight;
    float circleMoveDuration = 10f; 
    float circleRadius = 10f; 

    void Start()
    {
        randomTime = Random.Range(10f, 50f);
        randomHeight = Random.Range(50f, 80f);

        AnimateUpDown();
        AnimateCircle();
    }

    void Update()
    {
        
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
        Vector3 circleCenter = transform.position; 
        float angle = 0; 
        DOTween.To(() => angle, x => angle = x, 360, circleMoveDuration) 
            .SetRelative()
            .SetEase(Ease.Linear)
            .OnUpdate(() =>
            {
                float rad = Mathf.Deg2Rad * angle; 
                Vector3 pos = circleCenter + new Vector3(Mathf.Cos(rad) * circleRadius, 0, Mathf.Sin(rad) * circleRadius);
                transform.position = pos; 
            })
            .SetLoops(-1, LoopType.Restart); 
    }

    void RotateAndMove()
    {
       
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

       
        float moveVertical = Input.GetAxis("Vertical");
       
        float moveHorizontal = Input.GetAxis("Horizontal");

   
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);


        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }
}

