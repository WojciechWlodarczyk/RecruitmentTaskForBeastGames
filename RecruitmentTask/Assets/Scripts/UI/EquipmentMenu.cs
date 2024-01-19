using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenu : InGameMenu
{
    public override bool TryToSelectItem(ItemType type)
    {
        if (equipment.IsItemInEquipment(type) == false)
            return false;

        SelectNewIcon(type);
        return true;
    }

    public void AddItemToCrafting()
    {
        if (selectedIcon == null)
            return;

        uiManager.OpenCraftingMenu(selectedIcon.GetItemType);
    }

    public void UnpackItem()
    {
        if (selectedIcon == null)
            return;

        equipment.PutItemOnScene(selectedIcon.GetItemType);
        selectedIcon.Unselect();
        selectedIcon = null;
        UpdateLockItems();
    }
}
