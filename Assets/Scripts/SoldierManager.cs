using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    Warrior,
    Archor,
    Mage,
    Thif
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
    public float fatalHitProbability;
}
public class SoldierManager : MonoBehaviour
{

    private static SoldierManager m_instance = null;

    private Dictionary<SoldierCode, SoldierAbility> m_soldierAbility = new Dictionary<SoldierCode, SoldierAbility> ();


    public static SoldierManager Instance
    {
        get
        {
            if(!m_instance)
            {
                m_instance = FindObjectOfType(typeof(SoldierManager)) as SoldierManager;
            }   
            return m_instance;
        }
    }

    private void Awake()
    {
        if(null == m_instance)
        {
            m_instance = this;
            LoadData();
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

    }



}
