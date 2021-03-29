using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnObject : MonoBehaviour
{
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }

    public void ToStartPosition()
    {
        transform.position = startPosition;
    }
}
