using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance != null)
                    Debug.LogError("GameManager ½Ì±ÛÅæ °´Ã¼°¡ ¾øÀ½.");
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
}
