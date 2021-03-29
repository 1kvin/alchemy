using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
public class AlchemicalComponent : MonoBehaviour
{
    public AlchemicalComponentParams alchemicalComponentParams { get; private set; }
    private bool isInitialize = false;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Initialize(AlchemicalComponentType alchemicalComponentType,
        AlchemicalComponentTemperatureState temperature = AlchemicalComponentTemperatureState.Cold)
    {
        if (isInitialize) return;
        spriteRenderer.color = AlchemicalComponentColorDictionary.dictionary[alchemicalComponentType];
        alchemicalComponentParams = new AlchemicalComponentParams(alchemicalComponentType, temperature);
        isInitialize = true;
    }
}