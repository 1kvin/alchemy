using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class OrderBoard : MonoBehaviour
{
    [SerializeField] private AudioClip moneyClip;
    [SerializeField] private AudioClip scrollClip;
    public static OrderBoard instance = null;
    public GameObject[] scrolls;

    private List<OrderDetail> _activeOrders = new List<OrderDetail>();
    private List<OrderDetail> _doneOrders = new List<OrderDetail>();
    private List<OrderDetail> _waitingOrders = new List<OrderDetail>();
    private AudioSource audioSource;
   

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
        
        audioSource = GetComponent<AudioSource>();
    }
    

    public void AcceptOrder(OrderDetail order, Board board)
    {
        audioSource.clip = scrollClip;
        audioSource.Play();
        _waitingOrders.Remove(order);
        order.onBoard = board;
        _activeOrders.Add(order);
    }
    
    public void HandOverOrder(Mixture mixture)
    {
        for (var i = 0; i < _activeOrders.Count; i++)
        {
            if (!_activeOrders[i].recipe.alchemicalComponents.SequenceEqual(mixture.alchemicalComponents)) continue;
            CompletionOrder(_activeOrders[i]);
        }
    }

    private void CompletionOrder(OrderDetail order)
    {
        audioSource.clip = moneyClip;
        audioSource.Play();
        order.onBoard.Clear();
        _doneOrders.Add(order);
        _activeOrders.Remove(order);
        GoldPanel.instance.AddGold(1);
    }

    public void AddOrder(OrderDetail order)
    {
        foreach (var scroll in scrolls)
        {
            var curScroll = scroll.GetComponent<Scroll>();
            if (curScroll.isActive) continue;

            curScroll.Open(order);
            _waitingOrders.Add(order);
            return;
        }

        throw new Exception("Order board overflow");
    }
}