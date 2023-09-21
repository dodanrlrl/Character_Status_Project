using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoldierUI : MonoBehaviour
{
    [SerializeField]
    private Image SoldierSprite;

    [SerializeField]
    private TMP_Text SoldierType;
    [SerializeField]
    private TMP_Text SoldierName;

    [SerializeField]
    private TMP_Text SoldierHP;
    [SerializeField]
    private TMP_Text SoldierAttack;
    [SerializeField]
    private TMP_Text SoldierDefense;
    [SerializeField]
    private TMP_Text SoldierCritical;

    public void InitializeSoldierStatus()
    {
        SoldierAbility soldierAbility = SoldierManager.Instance.GetCurSoldierStatus();

        SoldierSprite.sprite = Resources.Load<Sprite>(soldierAbility.spritePath);

        SoldierType.text = "" + soldierAbility.type;
        SoldierName.text = soldierAbility.name;

        SoldierHP.text = "" + soldierAbility.healthPoint;
        SoldierAttack.text = ""+soldierAbility.AttackPower;
        SoldierDefense.text = "" + soldierAbility.Defense;
        SoldierCritical.text = "" + soldierAbility.Critical;


    }
    private void Start()
    {
        InitializeSoldierStatus();
    }

}
