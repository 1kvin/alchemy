using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private AlchemicalComponentType[] types;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject componentPrefab;
    [SerializeField] private float startHeightOffset = 3;
    private float distanceBetweenPoints;

    private void Start()
    {
        distanceBetweenPoints = Vector2.Distance(startPoint.position, endPoint.position) / (types.Length - 1);
        ReturnToShelf();
    }

    public void ReturnToShelf()
    {
        var alchemicalComponents = FindObjectsOfType<AlchemicalComponent>();
        for (var i = 0; i < types.Length; i++)
        {
            var position = startPoint.position + new Vector3(distanceBetweenPoints * i, startHeightOffset);
            var findAlchemicalComponent = alchemicalComponents.FirstOrDefault(alchemicalComponent =>
                alchemicalComponent.alchemicalComponentParams.alchemicalComponentType == types[i]);

            if (findAlchemicalComponent != null)
            {
                var flask = findAlchemicalComponent.gameObject.GetComponent<Flask>();
                if (flask != null)
                    if (flask.onStand)
                        continue;
                findAlchemicalComponent.gameObject.transform.position = position;
                findAlchemicalComponent.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                var instanceObject = Instantiate(componentPrefab, position, transform.rotation)
                    .GetComponent<AlchemicalComponent>();
                instanceObject.Initialize(types[i]);
                instanceObject.transform.parent = gameObject.transform;
            }
        }
    }
}