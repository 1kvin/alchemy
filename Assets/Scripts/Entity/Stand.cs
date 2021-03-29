using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Stand : MonoBehaviour
{
    [SerializeField] private GameObject emptyFlask = null;
    [SerializeField] private SpriteRenderer temperatureSprite;
    [SerializeField] private Sprite[] temperatureStatusSprites;
    private Flask curFlask = null;
    private AudioSource audioSource;
    private void Start()
    {
        temperatureSprite.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var dragAndDrop = other.GetComponent<DragAndDrop>();
        if (dragAndDrop == null) return;
        else if (dragAndDrop.drag) return;
        var alchemicalComponent = other.GetComponent<AlchemicalComponent>();
        var flask = other.GetComponent<Flask>();
        if (flask == null)
        {
            var bag = other.GetComponent<Bag>();
            if (bag == null) return;
            if (curFlask != null)
            {
                ToMixture(alchemicalComponent, other.gameObject);
            }
        }
        else
        {
            if ((curFlask != null) && (curFlask != flask))
            {
                ToMixture(alchemicalComponent, other.gameObject);
            }

            curFlask = flask;
            flask.SetOnStand();
            other.transform.position = emptyFlask.transform.position;
            temperatureSprite.enabled = true;
            if (alchemicalComponent != null)
            {
                temperatureSprite.sprite =
                    temperatureStatusSprites[(int) alchemicalComponent.alchemicalComponentParams.temperature.state];
            }
        }
    }

    private void ToMixture(AlchemicalComponent alchemicalComponent, GameObject other)
    {
        audioSource.Play();
        var mixture = curFlask.GetComponent<Mixture>();
        if(other.GetComponent<Mixture>() != null) return;//TODO mix Mixture
        if (mixture == null)
        {
            mixture = curFlask.gameObject.AddComponent<Mixture>();
            var curFlaskAlchemicalComponent = curFlask.gameObject.GetComponent<AlchemicalComponent>();
            mixture.AddComponent(curFlaskAlchemicalComponent.alchemicalComponentParams);
            Destroy(curFlaskAlchemicalComponent);
        }
        mixture.AddComponent(alchemicalComponent.alchemicalComponentParams);
        Destroy(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var flask = other.GetComponent<Flask>();
        if (flask == null) return;
        temperatureSprite.enabled = false;
        curFlask = null;
    }
}