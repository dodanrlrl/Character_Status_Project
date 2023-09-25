using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneSystem : MonoBehaviour
{

    private static MainSceneSystem m_instance = null;


    [SerializeField]
    private Image SoldierSprite;

    [SerializeField]
    private TMP_Text GoldTxt;
    [SerializeField]
    private int nowGold = 20000;

    [SerializeField]
    private TMP_Text SoldierType;
    [SerializeField]
    private TMP_Text SoldierName;

    [SerializeField]
    private TMP_Text SoldierLevel;
    [SerializeField]
    private TMP_Text SoldierExp;
    [SerializeField]
    private TMP_Text MaxExp;
    [SerializeField]
    private Image ExpBar;

    public static MainSceneSystem Instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = FindObjectOfType(typeof(MainSceneSystem)) as MainSceneSystem;
            }
            return m_instance;
        }
    }

    public void OnOpenSelectSoldierUI()
    {
        UIManager.Instance.AddUI(UIPrefab.SelectSoldierUI);
    }
    public void OnOpenStatusUI()
    {
        UIManager.Instance.AddUI(UIPrefab.StatusUI);
    }
    public void OnOpenInventroyUI()
    {
        UIManager.Instance.AddUI(UIPrefab.InventoryUI);
    }


    private void Start()
    {
        InitializeSoldierInfo();
        UpdateGold();
    }

    public void InitializeSoldierInfo()
    {
        SoldierAbility soldierAbility = SoldierManager.Instance.GetCurSoldierStatus();
        float maxExp = SoldierManager.Instance.GetMaxExp(soldierAbility.level);

        SoldierSprite.sprite = Resources.Load<Sprite>(soldierAbility.spritePath);

        SoldierType.text = "" + soldierAbility.type;
        SoldierName.text = soldierAbility.name;

        SoldierLevel.text = ""+soldierAbility.level;
        SoldierExp.text = "" + soldierAbility.exp;
        MaxExp.text = "" + maxExp;

        ExpBar.fillAmount = soldierAbility.exp / maxExp;

    }
    public void UpdateGold()
    {
        GoldTxt.text = nowGold.ToString();
    }

    public int GetGold()
    {
        return nowGold;
    }

}
