using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InGameMenu : MonoBehaviour
{
    [SerializeField]
    protected List<ItemIcon> itemIcons = new List<ItemIcon>();

    protected ItemIcon selectedIcon = null;

    protected Equipment equipment;

    protected UIManager uiManager;

    public virtual void Open()
    {
        equipment = GameManager.Instance.GetEquipment;
        uiManager = GameManager.Instance.GetUIManager;

        gameObject.SetActive(true);
        UpdateLockItems();
    }
    public void Close()
    {
        if(selectedIcon)
            selectedIcon.Unselect();
        gameObject.SetActive(false);
    }

    protected virtual void UpdateLockItems()
    {
        foreach (var item in itemIcons)
        {
            if (equipment.IsItemInEquipment(item.GetItemType))
            {
                item.UnlockItem();
            }
            else
            {
                item.LockItem();
            }
        }
    }
    public abstract bool TryToSelectItem(ItemType type);
    protected void SelectNewIcon(ItemType type)
    {
        if (selectedIcon != null)
            selectedIcon.Unselect();

        selectedIcon = itemIcons[(int)type];
        selectedIcon.Select();
    }
}
