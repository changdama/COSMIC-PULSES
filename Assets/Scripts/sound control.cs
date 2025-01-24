using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public Transform player; 
    public float maxDistance = 10f; 
    private AudioSource audioSource; 

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        float distance = Vector3.Distance(player.position, transform.position);

        
        if (distance <= maxDistance)
        {
            audioSource.volume = 1 - (distance / maxDistance);
        }
        else
        {
          
            audioSource.volume = 0;
        }
    }
}

