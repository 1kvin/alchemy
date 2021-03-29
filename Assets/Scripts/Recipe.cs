using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class Recipe
{
   public const int maxRecipeSize = 3;
   public readonly List<AlchemicalComponentParams> alchemicalComponents;
   private Recipe(List<AlchemicalComponentParams> alchemicalComponents)
   {
      this.alchemicalComponents = alchemicalComponents;
   }
   
   public class Builder
   {
      private List<AlchemicalComponentParams> alchemicalComponents = new List<AlchemicalComponentParams>();
      private int counter = 0;
      public Builder Add(AlchemicalComponentParams alchemicalComponent)
      {
         if (counter != maxRecipeSize)
         {
            alchemicalComponents.Add(alchemicalComponent);
         }
         else
         {
            throw new ArgumentException("Maximum recipe size exceeded");
         }
         counter++;
         return this;
      }

      public Recipe Build()
      {
         return new Recipe(alchemicalComponents);
      }
   }
}
