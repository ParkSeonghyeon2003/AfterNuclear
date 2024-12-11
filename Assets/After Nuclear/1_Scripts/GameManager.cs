using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [Header("# Player Info")]
    public int exp;
    public int level;
    public int maxExp;
    public int hp;
    public int maxHp;

    [Header("# GUI Objects")]
    public GameObject inventory;
    public GameObject crafting;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance != null)
                    Debug.LogError("GameManager 싱글톤 객체가 없음.");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void TriggerInventory()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

    public void OpenCrafting()
    {
        crafting.SetActive(true);
        Inventory inv = inventory.GetComponent<Inventory>();
        // if (inv.FindItem("battery") && inv.FindItem("mainboard") && inv.FindItem("transmitter"))
        // {
        //     Sprite[] sprite = Resources.LoadAll<Sprite>("GUI_Parts/Gui_parts/Button_agree");
        //     crafting.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
        // }
    }

    public void CloseCrafting()
    {
        crafting.SetActive(false);
    }
}
