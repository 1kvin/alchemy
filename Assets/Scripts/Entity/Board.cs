using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HighlightOnSelection))]
public class Board : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] componentSprites;
    [SerializeField] private SpriteRenderer[] temperatureSprites;
    [SerializeField] private SpriteRenderer[] plusSprites;
    [SerializeField] private Sprite[] temperatureStatusSprites;
    public Recipe curRecipe { get; private set; } = null;

    private void Start()
    {
        Clear();
    }
    
    public void Clear()
    {
        SetAlphaLayerToAll(0);
        curRecipe = null;
    }

    private void SetAlphaLayerToAll(float value)
    {
        SetAlphaLayer(componentSprites, value);
        SetAlphaLayer(temperatureSprites, value);
        SetAlphaLayer(plusSprites, value);
    }

    private static void SetAlphaLayer(IEnumerable<SpriteRenderer> spriteRenderers, float value)
    {
        foreach (var spriteRenderer in spriteRenderers)
        {
            var color = spriteRenderer.color;
            color.a = value;
            spriteRenderer.color = color;
        }
    }

    private void SetRecipe(Recipe recipe)
    {
        var recipeSize = recipe.alchemicalComponents.Count;
        if ((recipeSize != componentSprites.Length) || (recipeSize != temperatureSprites.Length))
            throw new ArgumentException("Size of board and recipe does not match");
        curRecipe = recipe;

        for (var i = 0; i < recipeSize; i++)
        {
            var curAlchemicalComponent = recipe.alchemicalComponents[i];

            componentSprites[i].color =
                AlchemicalComponentColorDictionary.dictionary[curAlchemicalComponent.alchemicalComponentType];
            temperatureSprites[i].sprite =
                temperatureStatusSprites[(int) curAlchemicalComponent.temperature.state];
        }

        SetAlphaLayerToAll(1);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var scroll = other.GetComponent<Scroll>();
        if (scroll == null) return;
        if (curRecipe != null) return;//TODO cancel orders
        if (other.GetComponent<DragAndDrop>().drag) return;

        SetRecipe(scroll.order.recipe);
        OrderBoard.instance.AcceptOrder(scroll.order, this);
        scroll.Close();
    }
}