using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPanel : MonoBehaviour
{
    public static GoldPanel instance = null;
    [SerializeField] private Text goldCounter;

    private long _gold = 0;

    public long gold
    {
        get
        {
            return _gold;
        }
        private set
        {
            _gold = value;
            goldCounter.text = _gold + "$";
        }
    }
    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
    }

    public void AddGold(int value)
    {
        if (value < 0) throw new ArgumentException("Gold must be greater than zero");
        gold += value;
    }
}
