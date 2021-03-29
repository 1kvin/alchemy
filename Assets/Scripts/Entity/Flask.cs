using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DragAndDrop))]
public class Flask : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public bool onStand { get; private set; } = false;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetOnStand()
    {
        onStand = true;
        GetComponent<BoxCollider2D>().isTrigger = true;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    public void TakeOffStand()
    {
        onStand = false;
    }

    void OnMouseDrag()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}