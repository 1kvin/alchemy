using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Mixture : MonoBehaviour
{
    private readonly List<AlchemicalComponentParams> _alchemicalComponents = new List<AlchemicalComponentParams>();
    public ReadOnlyCollection<AlchemicalComponentParams> alchemicalComponents => _alchemicalComponents.AsReadOnly();
    public void AddComponent(AlchemicalComponentParams alchemicalComponent)
    {
        _alchemicalComponents.Add(alchemicalComponent);
    }
}
