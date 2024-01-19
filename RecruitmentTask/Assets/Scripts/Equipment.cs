using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ItemType
{
    None = -1,
    //Start game itemes
    Wood = 0,
    Stone = 1,
    IronOre = 2,

    //Items from crafting
    WoodPlank = 3,
    StoneAxe = 4,
    Nail = 5,
    BatWithNails = 6
};

public class Equipment : MonoBehaviour
{
    private HashSet<ItemType> itemsInEquipment = new HashSet<ItemType> ();
    private SceneItemsManager sceneItemsManager;

    private void Start()
    {
        sceneItemsManager = GameManager.Instance.GetSceneItemsManager;
    }

    public void AddItem(ItemType type)
    {
        itemsInEquipment.Add(type);
    }

    public bool IsItemInEquipment(ItemType type)
    {
        return itemsInEquipment.Contains(type);
    }

    public void PutItemOnScene(ItemType type)
    {
        itemsInEquipment.Remove(type);
        sceneItemsManager.PutItemOnScene(type);
    }
}
