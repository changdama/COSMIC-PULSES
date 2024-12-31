using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class AudioControlledParticles : MonoBehaviour
{
    private AudioSource audioSource;
    private ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule emissionModule;

    public float maxEmissionRate = 1000f; // ������Ҫ�����������

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
        emissionModule = particleSystem.emission;
    }

    void Update()
    {
        // ������ӳ�䵽������
        float emissionRate = Mathf.Lerp(0, maxEmissionRate, audioSource.volume);
        emissionModule.rateOverTime = emissionRate;
    }
}




