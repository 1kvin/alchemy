using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlchemicalComponentTemperatureState;

public static class AlchemicalComponentTemperatureDictionary
{
    public static readonly Dictionary<AlchemicalComponentTemperatureState, float>
        dictionary =
            new Dictionary<AlchemicalComponentTemperatureState, float>
            {
                {Cold, 0f},
                {Warm, 5f},
                {Hot, 10f},
                {Boil, 15f},
            };
}