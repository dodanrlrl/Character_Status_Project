using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Counsumable,
    Equipable
}

public enum ConsumableType
{
    Health,
    Mana
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType ConsumableType;
    public float value;
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
