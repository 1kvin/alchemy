using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Burner : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Flask>() == null) return;
        var alchemicalComponent = other.GetComponent<AlchemicalComponent>();
        if (alchemicalComponent == null) return;
        alchemicalComponent.alchemicalComponentParams.temperature.IncreaseTemperature(Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Flask>() == null) return;
        audioSource.Play();
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Flask>() == null) return;
        audioSource.Pause();
    }
}
