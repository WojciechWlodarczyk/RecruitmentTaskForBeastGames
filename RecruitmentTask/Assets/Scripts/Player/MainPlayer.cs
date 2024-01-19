using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField]
    private MovementComponent movementComponent;

    private HashSet<ItemToPickUp> ItemsThatPlayerCanPickUp = new HashSet<ItemToPickUp>();

    private SceneItemsManager sceneItemsManager;

    void Start()
    {
        sceneItemsManager = GameManager.Instance.GetSceneItemsManager;
    }

    void Update()
    {
        ManageItemPickUping();
    }

    public void AddItemToPickUp(ItemToPickUp type)
    {
        ItemsThatPlayerCanPickUp.Add(type);
    }

    public void RemoveItemToPickUp(ItemToPickUp type)
    {
        ItemsThatPlayerCanPickUp.Remove(type);
    }

    private void ManageItemPickUping()
    {
        if (GameManager.Instance.GetInputManager.GetPickUpItemInput())
        {
            foreach (ItemToPickUp item in ItemsThatPlayerCanPickUp)
            {
                sceneItemsManager.EquipItemFromScene(item.GetItemType);
            }

            ItemsThatPlayerCanPickUp = new HashSet<ItemToPickUp>();
        }
    }
}
