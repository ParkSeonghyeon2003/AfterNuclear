using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectItem
{
    Item CollectItem();
}

public class ObjectItem : MonoBehaviour, IObjectItem
{
    [Header("아이템")]
    public Item item;
    [Header("아이템 이미지")]
    public SpriteRenderer itemImage;

    void Start()
    {
        itemImage.sprite = item.itemImage;
    }

    public Item CollectItem()
    {
        return this.item;
    }
}
