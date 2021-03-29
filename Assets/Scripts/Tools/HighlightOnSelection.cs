using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnSelection : MonoBehaviour
{
    [SerializeField]
    private float animationSpeed = 0.05f;
    [SerializeField]
    private float minAlphaLayer = 0.4f;
    [SerializeField]
    private float coroutinePeriod = 0.01f;
    [SerializeField]
    private SpriteRenderer sprite = null;
    private void OnMouseEnter()
    {
        StartCoroutine(RegularCoroutine());
    }
    private void OnMouseExit()
    {
        StopAllCoroutines();
        var c = sprite.color;
        c.a = 1f;
        sprite.color = c;
    }
    private IEnumerator RegularCoroutine()
    {
        while (sprite.color.a > minAlphaLayer)
        {
            var c = sprite.color;
            c.a -= animationSpeed;
            sprite.color = c;
            yield return new WaitForSeconds(coroutinePeriod);
        }
    }
}
