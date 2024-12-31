using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public Transform player; // 玩家的Transform组件
    public float maxDistance = 10f; // 声音影响的最大距离
    private AudioSource audioSource; // 声音源组件

    void Start()
    {
        // 获取当前游戏对象上的AudioSource组件
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 计算玩家与声音源之间的距离
        float distance = Vector3.Distance(player.position, transform.position);

        // 根据距离调整音量，距离越近，音量越大
        if (distance <= maxDistance)
        {
            audioSource.volume = 1 - (distance / maxDistance);
        }
        else
        {
            // 如果玩家超出最大距离，音量设置为0
            audioSource.volume = 0;
        }
    }
}

