using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    private enum UIState
    {
        DuringGame,
        EquipmentUI,
        CraftingUI
    }

    private UIState currentUIState = UIState.DuringGame;

    [SerializeField]
    private EquipmentMenu equipmentMenu;

    [SerializeField]
    private CraftingMenu craftingMenu;

    [SerializeField]
    private Texture2D customCursor;




    public void OpenEquipmentMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        equipmentMenu.Open();
        craftingMenu.Close();

        currentUIState = UIState.EquipmentUI;
    }
    public void OpenCraftingMenu(ItemType forItem)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        equipmentMenu.Close();
        craftingMenu.SetFirstCraftingItem(forItem);
        craftingMenu.SetSecondCraftingItem(ItemType.None);
        craftingMenu.SetCraftingResult(ItemType.None);
        craftingMenu.Open();

        currentUIState = UIState.EquipmentUI;
    }

    public void CloseAllMenus()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        equipmentMenu.Close();
        craftingMenu.Close();

        currentUIState = UIState.DuringGame;
    }

    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.ForceSoftware);

        CloseAllMenus();
    }
}
