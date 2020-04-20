using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xplodManager : MonoBehaviour
{


    /// Singleton
    public static xplodManager Instance;
    public ParticleSystem playerXplod;
    public ParticleSystem enemxplod;
      

    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    public void Explosion(string xplodtype, Vector3 position)
    {
        // square xplod
        if (xplodtype == "xplod")
            instantiate(playerXplod, position);
        if (xplodtype == "enemy")
            instantiate(enemxplod, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
        return newParticleSystem;
    }
}
