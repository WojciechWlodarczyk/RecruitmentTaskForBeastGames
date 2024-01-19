using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingMenu : InGameMenu
{
    public List<Sprite> iconSprites = new List<Sprite>();

    private ItemType firstCraftingItem;
    private ItemType secondCraftingItem;
    private ItemType craftingResult;

    [SerializeField]
    private Image imageForFirstCraftingItem;
    [SerializeField]
    private Image imageForSecondCraftingItem;
    [SerializeField]
    private Image imageForCraftingResult;

    [SerializeField]
    private GameObject failMessage;
    [SerializeField]
    private GameObject successMessage;
    [SerializeField]
    private GameObject tryMessage;


    [SerializeField]
    private Text textForProbability;

    [SerializeField]
    private string probabilityText = "% szansy na powodzenie";

    [SerializeField]
    private string nothingSelectedText = "Wybierz drugi przedmiot";

    private CraftingManager craftingManager;

    List<ItemType> possibleSecondItems = new List<ItemType>();

    protected override void UpdateLockItems()
    {
        base.UpdateLockItems();

        foreach (var item in itemIcons)
        {
            if (!possibleSecondItems.Contains(item.GetItemType))
            {
                item.LockItem();
            }
        }
    }

    public override void Open()
    {
        craftingManager = GameManager.Instance.GetCraftingManager;
        possibleSecondItems = craftingManager.GetSecondItemsForCraftingMenu(firstCraftingItem);
        textForProbability.text = nothingSelectedText;
        ResetCraftingMessages();

        base.Open();
    }

    public void SetFirstCraftingItem(ItemType type)
    {
        firstCraftingItem = type;
        imageForFirstCraftingItem.sprite = iconSprites[(int)type];
    }
    public void SetSecondCraftingItem(ItemType type)
    {
        secondCraftingItem = type;

        if(type == ItemType.None)
        {
            imageForSecondCraftingItem.enabled = false;
        }
        else
        {
            imageForSecondCraftingItem.enabled = true;
            imageForSecondCraftingItem.sprite = iconSprites[(int)type];


        }
    }
    public void SetCraftingResult(ItemType type)
    {
        craftingResult = type;
        imageForCraftingResult.sprite = type != ItemType.None ? iconSprites[(int)type] : null;
    }
    public override bool TryToSelectItem(ItemType type)
    {
        if (equipment.IsItemInEquipment(type) == false)
            return false;

        if (!possibleSecondItems.Contains(type))
            return false;

        SelectNewIcon(type);
        SetSecondCraftingItem(type);
        UpdateProbabilityText();

        return true;
    }

    public void CraftButton()
    {
        if (secondCraftingItem == ItemType.None)
            return;

        bool result = craftingManager.TryCraftingItems(firstCraftingItem, secondCraftingItem, out ItemType resultItem);
        
        if(result)
        {
            equipment.AddItem(resultItem);
            SetCraftingResult(resultItem);
            ShowSuccessCraftingMessage();
            UpdateLockItems();
        }
        else
        {
            ShowFailCraftingMessage();
        }
    }

    public void ReturnButton()
    {
        uiManager.OpenEquipmentMenu();
    }

    private void UpdateProbabilityText()
    {
        float probability = craftingManager.GetProbabilityForCrafting(firstCraftingItem, secondCraftingItem);
        probability *= 100;
        textForProbability.text = probability.ToString() + probabilityText;

        ResetCraftingMessages();
    }

    void ShowSuccessCraftingMessage()
    {
        tryMessage.SetActive(false);
        failMessage.SetActive(false);
        successMessage.SetActive(true);
    }

    void ShowFailCraftingMessage()
    {
        tryMessage.SetActive(false);
        failMessage.SetActive(true);
        successMessage.SetActive(false);
    }
    void ResetCraftingMessages()
    {
        tryMessage.SetActive(true);
        failMessage.SetActive(false);
        successMessage.SetActive(false);
    }
}
