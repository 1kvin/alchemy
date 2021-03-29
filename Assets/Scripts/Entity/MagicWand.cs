using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class MagicWand : MonoBehaviour
{
    [SerializeField] private UnityEvent onClick;
    [SerializeField] private float hideAlphaValue = 0.5f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeAlphaLayer(hideAlphaValue);
    }

    private void OnMouseEnter()
    {
        ChangeAlphaLayer(1);
    }

    private void OnMouseExit()
    {
        ChangeAlphaLayer(hideAlphaValue);
    }

    private void ChangeAlphaLayer(float value)
    {
        var color = spriteRenderer.color;
        color.a = value;
        spriteRenderer.color = color;
    }

    private void OnMouseDown()
    {
        onClick.Invoke();
    }
}