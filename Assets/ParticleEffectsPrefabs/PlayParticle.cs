using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    public ParticleSystem particle;

    [SerializeField]
    public static bool playParticle, stopParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (playParticle) 
       {
          particle.Play();
       }
    }
}
