using System.Collections.Generic;
using UnityEngine;
using static AlchemicalComponentType;

public static class AlchemicalComponentColorDictionary
{
    public static readonly Dictionary<AlchemicalComponentType, Color> dictionary =
        new Dictionary<AlchemicalComponentType, Color>
        {
            {Alcohol, new Color(0.73f, 0.73f, 0.73f)},
            {Cobalt, Color.blue},
            {Copper, new Color(0.8549f, 0.54f, 0.40f)},
            {Gold, Color.yellow},
            {Honey, new Color(0.92f, 0.83f, 0.56f)},
            {Mercury, new Color(0.31f, 0.37f, 0.41f)},
            {Milk, Color.white},
            {Oil, new Color(0.62f, 0.58f, 0.36f)},
            {Petrol, new Color(0.12f, 0.15f, 0.21f)},
            {Water, Color.cyan},
            {SulphuricAcid, new Color(0.18f, 0.46f, 0.56f)}
        };
}