using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPickUp : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType = ItemType.None;
    public ItemType GetItemType => itemType;

    private string playerTag;
    private MainPlayer player;
    private SceneItemsManager sceneItemsManager;
    private bool IsItemOnScene = true;

    private void Start()
    {
        playerTag = GameManager.Instance.GetPlayerTag;
        player = GameManager.Instance.GetPlayer;
        sceneItemsManager = GameManager.Instance.GetSceneItemsManager;

        if (itemType == ItemType.None)
            throw new System.Exception("Item type not selected!");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTag)
        {
            player.AddItemToPickUp(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
            player.RemoveItemToPickUp(this);
        }
    }

    public void DisableItem()
    {
        gameObject.SetActive(false);
    }

    public void EnableItem()
    {
        gameObject.SetActive(true);
    }
}
