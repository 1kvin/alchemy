using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemicalComponentTemperature
{
    private float _heat = 0;
    public AlchemicalComponentTemperatureState state { get; private set; }

    public AlchemicalComponentTemperature(AlchemicalComponentTemperatureState temperature)
    {
        _heat = AlchemicalComponentTemperatureDictionary.dictionary[temperature];
        state = temperature;
    }

    public float heat
    {
        get => _heat;
        private set
        {
            _heat = value;
            state = DefineTemperatureStatus(_heat);
        }
    }

    public void IncreaseTemperature(float value)
    {
        if (value < 0) throw new ArgumentException("Heating must be greater than zero");
        heat += value;
    }

    public AlchemicalComponentTemperatureState DefineTemperatureStatus(float value)
    {
        if (value <
            AlchemicalComponentTemperatureDictionary.dictionary[
                AlchemicalComponentTemperatureState.Warm])
            return AlchemicalComponentTemperatureState.Cold;
        else if (value <
                 AlchemicalComponentTemperatureDictionary.dictionary[
                     AlchemicalComponentTemperatureState.Hot])
            return AlchemicalComponentTemperatureState.Warm;
        else if (value <
                 AlchemicalComponentTemperatureDictionary.dictionary[
                     AlchemicalComponentTemperatureState.Boil])
            return AlchemicalComponentTemperatureState.Hot;
        else
            return AlchemicalComponentTemperatureState.Boil;
    }
}