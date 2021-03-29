using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DragAndDrop : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public bool drag { get; private set; }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDrag()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    private void OnMouseUpAsButton()
    {
        drag = false;
    }

    private void OnMouseDown()
    {
        drag = true;
    }
}
