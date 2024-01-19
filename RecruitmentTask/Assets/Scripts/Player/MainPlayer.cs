using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    ControllingPlayer,
    InMenu
}

public class MainPlayer : MonoBehaviour
{
    [SerializeField]
    private MovementComponent movementComponent;

    private PlayerState currentState;

    private HashSet<ItemToPickUp> ItemsThatPlayerCanPickUp = new HashSet<ItemToPickUp>();

    private SceneItemsManager sceneItemsManager;
    private UIManager uiManager;

    void Start()
    {
        sceneItemsManager = GameManager.Instance.GetSceneItemsManager;
        uiManager = GameManager.Instance.GetUIManager;
    }

    void Update()
    {
        if (GameManager.Instance.GetInputManager.GetEquipmentInput())
        {
            switch (currentState)
            {
                case PlayerState.ControllingPlayer:
                    EnterEquipmentMenuState();
                    break;
                case PlayerState.InMenu:
                    EnterControllingPlayerState();
                    break;
            }
        }

        if (currentState == PlayerState.ControllingPlayer)
        {
            ManageItemPickUping();
        }
    }
    private void EnterEquipmentMenuState()
    {
        movementComponent.DisableControlling();
        uiManager.OpenEquipmentMenu();

        currentState = PlayerState.InMenu;
    }

    private void EnterControllingPlayerState()
    {
        movementComponent.EnableControlling();
        uiManager.CloseAllMenus();

        currentState = PlayerState.ControllingPlayer;
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
