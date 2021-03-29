using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<AlchemicalComponent>() != null)
            Destroy(other.gameObject);

        var mixture = other.GetComponent<Mixture>();
        if (mixture != null)
            OrderBoard.instance.HandOverOrder(mixture);
        Destroy(other.gameObject);
    }
}