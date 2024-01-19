using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemsManager : MonoBehaviour
{
    [SerializeField]
    private List<ItemToPickUp> sceneItems;

    private Equipment equipment;

    private void Start()
    {
        equipment = GameManager.Instance.GetEquipment;
    }
    public void PutItemOnScene(ItemType type)
    {
        sceneItems[(int)type].EnableItem();
    }

    public void EquipItemFromScene(ItemType type)
    {
        sceneItems[(int)type].DisableItem();
        equipment.AddItem(type);
    }
}
