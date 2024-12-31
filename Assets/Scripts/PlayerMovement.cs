using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float movementSpeed = 5f;
    public float verticalSpeed = 5f; // ���������ƶ����ٶ�

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // �����ƶ�
        float moveUpwards = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            moveUpwards = -verticalSpeed * Time.deltaTime; // �����ƶ�
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveUpwards = verticalSpeed * Time.deltaTime; // �����ƶ�
        }

        // Ӧ�������ƶ�
        controller.Move(new Vector3(0, moveUpwards, 0));


    }
}
