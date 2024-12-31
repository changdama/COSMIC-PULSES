using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class AudioControlledParticles : MonoBehaviour
{
    private AudioSource audioSource;
    private ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule emissionModule;

    public float maxEmissionRate = 1000f; // 根据需要调整最大发射率

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
        emissionModule = particleSystem.emission;
    }

    void Update()
    {
        // 将音量映射到发射率
        float emissionRate = Mathf.Lerp(0, maxEmissionRate, audioSource.volume);
        emissionModule.rateOverTime = emissionRate;
    }
}




