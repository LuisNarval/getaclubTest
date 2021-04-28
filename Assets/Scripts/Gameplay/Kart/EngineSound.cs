using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] float maxSpeed = 20;
    [SerializeField] float maxPitch = 1.5f;
    [SerializeField] float minPitch = 0.5f;
    [SerializeField] float maxVolume = 0.5f;
    [SerializeField] float minVolume = 0.2f;


    [Header("REFERENCE")]
    [SerializeField] AudioSource SFX_Engine;
    [SerializeField] Rigidbody Body;

    private void Update()
    {
        UpdateSFX();   
    }

    void UpdateSFX()
    {
        SFX_Engine.pitch = minPitch + ( (Body.velocity.magnitude * (maxPitch - minPitch)) / (maxSpeed) );
        SFX_Engine.volume = minVolume + ((Body.velocity.magnitude * (maxVolume - minVolume)) / (maxSpeed));
    }

}