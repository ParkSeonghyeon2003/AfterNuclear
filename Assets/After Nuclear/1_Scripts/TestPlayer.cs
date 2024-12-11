using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [Header("인벤토리")]
    public Inventory inventory;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Item Object")) return;
        IObjectItem collectInterface = collision.gameObject.GetComponent<IObjectItem>();

        if (collectInterface != null)
        {
            Item item = collectInterface.CollectItem();
            print($"item.itemName");
            inventory.AddItem(item);
            Destroy(collision.gameObject);
        }
    }
}
