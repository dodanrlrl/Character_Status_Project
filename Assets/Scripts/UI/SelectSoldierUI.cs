using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSoldierUI : MonoBehaviour
{
    public void SelectZeus()
    {
        SoldierManager.Instance.cur_soldierCode = SoldierCode.Zeus;
        SoldierManager.Instance.SetCurSoldierStatus();
        MainSceneSystem.Instance.InitializeSoldierInfo();

        UIManager.Instance.RemoveOneUI();
    }
    public void SelectOner()
    {
        SoldierManager.Instance.cur_soldierCode = SoldierCode.Oner;
        SoldierManager.Instance.SetCurSoldierStatus();
        MainSceneSystem.Instance.InitializeSoldierInfo();

        UIManager.Instance.RemoveOneUI();
    }
    public void SelectFaker()
    {
        SoldierManager.Instance.cur_soldierCode = SoldierCode.Faker;
        SoldierManager.Instance.SetCurSoldierStatus();
        MainSceneSystem.Instance.InitializeSoldierInfo();

        UIManager.Instance.RemoveOneUI();
    }
    public void SelectGumayusi()
    {
        SoldierManager.Instance.cur_soldierCode = SoldierCode.Gumayusi;
        SoldierManager.Instance.SetCurSoldierStatus();
        MainSceneSystem.Instance.InitializeSoldierInfo();

        UIManager.Instance.RemoveOneUI();
    }
    public void SelectKeria()
    {
        SoldierManager.Instance.cur_soldierCode = SoldierCode.Keria;
        SoldierManager.Instance.SetCurSoldierStatus();
        MainSceneSystem.Instance.InitializeSoldierInfo();

        UIManager.Instance.RemoveOneUI();
    }

    public void ExitUI()
    {
        UIManager.Instance.RemoveOneUI();
    }
    
}
