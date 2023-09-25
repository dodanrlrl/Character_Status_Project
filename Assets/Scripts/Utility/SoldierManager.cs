using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
public enum SoldierCode
{
    Zeus,
    Oner,
    Faker,
    Gumayusi,
    Keria
}
public enum SoldierType
{
    Top,
    Jungle,
    Mid,
    Ad,
    Support
}
[System.Serializable]
public struct ExpData
{
    public int level;
    public float maxExp;
}

[System.Serializable]
public struct SoldierAbility
{
    public int level;
    public float exp;

    public SoldierCode code;
    public SoldierType type;
    public string name;
    public float AttackPower;
    public float Defense;
    public float healthPoint;
    public float Critical;

    public string spritePath;
}
public class SoldierManager : MonoBehaviour
{

    private static SoldierManager m_instance = null;

    public SoldierCode cur_soldierCode = 0;
    private SoldierAbility cur_soldierAbility;

    private Dictionary<SoldierCode, SoldierAbility> m_soldierAbility = new Dictionary<SoldierCode, SoldierAbility>();
    private Dictionary<int, float> m_soldierExpData = new Dictionary<int, float>();


    public static SoldierManager Instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = FindObjectOfType(typeof(SoldierManager)) as SoldierManager;
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        if (null == m_instance)
        {
            m_instance = this;
            LoadData();
            SetCurSoldierStatus();//편의를 위해 일단 초반에 캐릭터 넣어줌 추후 변경
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadData()
    {
        string soldierAbilityJSON = File.ReadAllText(Application.dataPath + "/Resources/JSON/SoldierAbility.json");

        List<SoldierAbility> soldierAbilities = JsonHelper.FromJson<SoldierAbility>(soldierAbilityJSON);
        foreach (SoldierAbility ability in soldierAbilities)
        {
            m_soldierAbility.Add(ability.code, ability);
        }

        string soldierExpJSON = File.ReadAllText(Application.dataPath + "/Resources/JSON/SoldierExpData.json");

        List<ExpData> soldierExp = JsonHelper.FromJson<ExpData>(soldierExpJSON);
        foreach (ExpData expData in soldierExp)
        {
            m_soldierExpData.Add(expData.level, expData.maxExp);
        }

    }
    public void SetCurSoldierStatus()
    {
        cur_soldierAbility = m_soldierAbility[cur_soldierCode];
    }

    public SoldierAbility GetCurSoldierStatus()
    {
        return cur_soldierAbility;
    }

    public float GetMaxExp(int level)
    {
        return m_soldierExpData[level];
    }

    public SoldierAbility AddSoldierExp(float exp)//나중에 경험치 상승 효과 있을때 이용
    {

        float curExp = (cur_soldierAbility.exp * GetMaxExp(cur_soldierAbility.level)) + exp;
        while (curExp >= GetMaxExp(cur_soldierAbility.level))
        {
            curExp -= GetMaxExp(cur_soldierAbility.level);
            cur_soldierAbility.level++;

            if (cur_soldierAbility.level >= 30)
            {
                curExp = 0;
                cur_soldierAbility.exp = 0;
                break;
            }
        }

        cur_soldierAbility.exp = curExp / GetMaxExp(cur_soldierAbility.level);
        m_soldierAbility[cur_soldierCode] = cur_soldierAbility;

        return cur_soldierAbility;
    }


}
