using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDetail 
{
    public Recipe recipe { get; private set; }
    public Board onBoard { get; set; }

    public OrderDetail(Recipe recipe)
    {
        this.recipe = recipe;
    }
}
