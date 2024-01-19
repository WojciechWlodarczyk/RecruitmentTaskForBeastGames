using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CraftingManager : MonoBehaviour
{
    [System.Serializable]
    public struct CraftingStruct
    {
        [SerializeField]
        private CraftingOperation craftingOperation;
        [SerializeField]
        private UnityEvent successEvent;
        [SerializeField]
        private UnityEvent failEvent;

        public bool TryCrafting(out ItemType resultItem)
        {
            float randomNumber = Random.Range(0f, 1f);
            if(randomNumber <= craftingOperation.probability) 
            {
                successEvent?.Invoke();
                resultItem = craftingOperation.resultItem;
                return true;
            }
            else 
            {
                failEvent?.Invoke();
                resultItem = ItemType.None;
                return false;
            }
        }
        public bool IsForThisItem(ItemType firstCraftingMenuItem, out ItemType secondCraftingMenuItem)
        {
            if (craftingOperation.firstItem == firstCraftingMenuItem)
            {
                secondCraftingMenuItem = craftingOperation.secondItem;
                return true;
            }

            if (craftingOperation.secondItem == firstCraftingMenuItem)
            {
                secondCraftingMenuItem = craftingOperation.firstItem;
                return true;
            }

            secondCraftingMenuItem = ItemType.None;
            return false;
        }
        public bool IsForThoseItems(ItemType first, ItemType second)
        {
            if (craftingOperation.firstItem == first && craftingOperation.secondItem == second)
                return true;

            if (craftingOperation.firstItem == second && craftingOperation.secondItem == first)
                return true;

            return false;
        }
        public float GetProbability() => craftingOperation.probability;
    }

    public List<CraftingStruct> possibleCrafting = new List<CraftingStruct>();

    public List<ItemType> GetSecondItemsForCraftingMenu(ItemType firstCraftingMenuItem)
    {
        List<ItemType> secondItemsForCraftingMenu = new List<ItemType>();

        for (int i = 0; i < possibleCrafting.Count; i++)
        {
            if (possibleCrafting[i].IsForThisItem(firstCraftingMenuItem, out ItemType secondCraftingMenuItem))
            {
                secondItemsForCraftingMenu.Add(secondCraftingMenuItem);
            }
        }
        return secondItemsForCraftingMenu;
    }

    public float GetProbabilityForCrafting(ItemType first, ItemType second)
    {
        for (int i = 0; i < possibleCrafting.Count; i++)
        {
            if(possibleCrafting[i].IsForThoseItems(first, second))
            {
                return possibleCrafting[i].GetProbability();
            }
        }

        throw new System.Exception("No crafting for those items!");
    }

    public bool TryCraftingItems(ItemType first, ItemType second, out ItemType resultItem)
    {
        for (int i = 0; i < possibleCrafting.Count; i++)
        {
            if (possibleCrafting[i].IsForThoseItems(first, second))
            {
                return possibleCrafting[i].TryCrafting(out resultItem);
            }
        }

        throw new System.Exception("No crafting for those items!");
    }
}
