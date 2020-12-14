using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] ParticleSystem plantFX;
    

    public void StopFx()
    {
        plantFX.Stop();
    }

    
}
