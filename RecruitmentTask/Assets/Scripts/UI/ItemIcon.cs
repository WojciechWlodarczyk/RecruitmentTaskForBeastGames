using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    [SerializeField]
    private GameObject isSelectedImage;

    [SerializeField]
    private Image iconImage;

    [SerializeField]
    private ItemType itemType;
    public ItemType GetItemType => itemType;

    [SerializeField]
    private InGameMenu inGameMenu;

    public void ButtonClick()
    {
        inGameMenu.TryToSelectItem(itemType);
    }
    public void Select()
    {
        isSelectedImage.SetActive(true);
    }
    public void Unselect()
    {
        isSelectedImage.SetActive(false);
    }

    public void UnlockItem()
    {
        iconImage.color = Color.white;
    }
    public void LockItem()
    {
        iconImage.color = new Color(0, 0, 0, 0.2f);
    }
}
