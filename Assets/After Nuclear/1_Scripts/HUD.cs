using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, HP, Level };
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.Instance.exp;
                float maxExp = GameManager.Instance.maxExp;
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.HP:
                float curHp = GameManager.Instance.hp;
                float maxHp = GameManager.Instance.maxHp;
                mySlider.value = curHp / maxHp;
                break;
            case InfoType.Level:

                break;
            default:

                break;
        }
    }
}
