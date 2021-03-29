using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DragAndDrop))]
public class Scroll : MonoBehaviour
{
    public OrderDetail order { get; private set; }
    public Vector3 startPosition { get; private set; }
    public bool isActive { get; private set; } = false;

    private void Awake()
    {
        startPosition = transform.position;
       
    }

    public void Open(OrderDetail order)
    {
        isActive = true;
        gameObject.SetActive(isActive);
        this.order = order;
        transform.position = startPosition;
    }

    public void Close()
    {
        isActive = false;
        gameObject.SetActive(isActive);
    }
}