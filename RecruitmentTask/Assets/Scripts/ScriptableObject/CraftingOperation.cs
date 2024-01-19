using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CraftingOperation", menuName = "My project/Scriptable Object")]
public class CraftingOperation : ScriptableObject
{
    public ItemType firstItem;

    public ItemType secondItem;

    public ItemType resultItem;

    [Range(0, 1)]
    public float probability = 0.8f;
}
