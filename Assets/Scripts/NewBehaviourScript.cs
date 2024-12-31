using UnityEngine;

public class ConnectAllParticles : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        int particleCount = particleSystem.particleCount;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];

        particleSystem.GetParticles(particles);
        lineRenderer.positionCount = particleCount; // 设置LineRenderer的位置点数

        for (int i = 0; i < particleCount; i++)
        {
            lineRenderer.SetPosition(i, particles[i].position); // 更新每个位置点到对应粒子的位置
        }
    }
}


