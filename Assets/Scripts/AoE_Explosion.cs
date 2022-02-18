using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoE_Explosion : MonoBehaviour
{
    public float explosionDuration;
    float currentExplosionDuration;
    public ParticleSystem explosionParticle;
    public SphereCollider aoeCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExplosionDuration < explosionDuration)
        {
            currentExplosionDuration += Time.deltaTime;
        }
        else
        {
            aoeCollider.enabled = false;
        }

        if (explosionParticle.isStopped == true)
        {
            Destroy(this.gameObject);
        }
    }
}
