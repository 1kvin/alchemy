using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OrderPlanner : MonoBehaviour
{
    [SerializeField] private float timeOfOrderAppearance = 10;
    private float timer = 0;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            audioSource.Play();

            var alchemicalComponentTypes = Enum.GetValues(typeof(AlchemicalComponentType));
            var temperatures = Enum.GetValues(typeof(AlchemicalComponentTemperatureState));
            var random = new System.Random();
            var randomComponent1 =
                (AlchemicalComponentType) alchemicalComponentTypes.GetValue(
                    random.Next((int) AlchemicalComponentType.Water, alchemicalComponentTypes.Length));
            var randomComponent2 =
                (AlchemicalComponentType) alchemicalComponentTypes.GetValue(
                    random.Next(alchemicalComponentTypes.Length));
            var randomComponent3 =
                (AlchemicalComponentType) alchemicalComponentTypes.GetValue(
                    random.Next(alchemicalComponentTypes.Length));

            var temperature1 = (AlchemicalComponentTemperatureState) temperatures.GetValue(
                random.Next(temperatures.Length));
            var order = new OrderDetail(new Recipe.Builder()
                .Add(new AlchemicalComponentParams(randomComponent1, temperature1))
                .Add(new AlchemicalComponentParams(randomComponent2))
                .Add(new AlchemicalComponentParams(randomComponent3)).Build());
            OrderBoard.instance.AddOrder(order);
            timer = timeOfOrderAppearance;
        }
    }
}