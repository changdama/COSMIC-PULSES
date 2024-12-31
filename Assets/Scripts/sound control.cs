using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public Transform player; // ��ҵ�Transform���
    public float maxDistance = 10f; // ����Ӱ���������
    private AudioSource audioSource; // ����Դ���

    void Start()
    {
        // ��ȡ��ǰ��Ϸ�����ϵ�AudioSource���
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // �������������Դ֮��ľ���
        float distance = Vector3.Distance(player.position, transform.position);

        // ���ݾ����������������Խ��������Խ��
        if (distance <= maxDistance)
        {
            audioSource.volume = 1 - (distance / maxDistance);
        }
        else
        {
            // �����ҳ��������룬��������Ϊ0
            audioSource.volume = 0;
        }
    }
}

