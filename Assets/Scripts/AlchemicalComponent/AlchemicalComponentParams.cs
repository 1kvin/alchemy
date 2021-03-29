using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemicalComponentParams
{
    public AlchemicalComponentType alchemicalComponentType { get; private set; }
    public AlchemicalComponentTemperature temperature { get; private set; }

    public AlchemicalComponentParams(AlchemicalComponentType alchemicalComponentType,
        AlchemicalComponentTemperatureState temperature = AlchemicalComponentTemperatureState.Cold)
    {
        this.alchemicalComponentType = alchemicalComponentType;
        this.temperature = new AlchemicalComponentTemperature(temperature);
    }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as AlchemicalComponentParams);
    }

    public bool Equals(AlchemicalComponentParams alchemicalComponent)
    {
        if (Object.ReferenceEquals(alchemicalComponent, null))
        {
            return false;
        }

        if (Object.ReferenceEquals(this, alchemicalComponent))
        {
            return true;
        }

        if (this.GetType() != alchemicalComponent.GetType())
        {
            return false;
        }

        return (alchemicalComponent.temperature.state == temperature.state) &&
               (alchemicalComponent.alchemicalComponentType == alchemicalComponentType);
    }
}