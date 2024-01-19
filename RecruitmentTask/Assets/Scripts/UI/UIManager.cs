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
    private Texture2D customCursor;




    public void OpenEquipmentMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        equipmentMenu.Open();

        currentUIState = UIState.EquipmentUI;
    }

    public void CloseAllMenus()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        equipmentMenu.Close();

        currentUIState = UIState.DuringGame;
    }

    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.ForceSoftware);

        CloseAllMenus();
    }
}
