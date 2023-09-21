using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{

    [SerializeField]
    private TMP_Text SoldierHP;
    [SerializeField]
    private TMP_Text SoldierAttack;
    [SerializeField]
    private TMP_Text SoldierDefense;
    [SerializeField]
    private TMP_Text SoldierCritical;

    private void InitializeSoldierStatus()
    {
        SoldierAbility soldierAbility = SoldierManager.Instance.GetCurSoldierStatus();

        SoldierHP.text = "" + soldierAbility.healthPoint;
        SoldierAttack.text = "" + soldierAbility.AttackPower;
        SoldierDefense.text = "" + soldierAbility.Defense;
        SoldierCritical.text = "" + soldierAbility.Critical;

    }
    private void Start()
    {
        InitializeSoldierStatus();
    }
    public void ExitUI()
    {
        UIManager.Instance.RemoveOneUI();
    }
}
