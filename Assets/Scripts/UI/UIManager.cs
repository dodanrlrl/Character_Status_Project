using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIPrefab
{
    StatusUI,
    SelectSoldierUI
}
public class UIManager : MonoBehaviour
{
    private static UIManager m_instance = null;

    List<GameObject> m_ui = new List<GameObject>();
    List<string> m_uiPrefabPath = new List<string>();

    public static UIManager Instance
    {
        get
        {
            if(!m_instance)
            {
                m_instance = FindObjectOfType(typeof(UIManager)) as UIManager;
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        if(null == m_instance) 
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
            SetUIPrefabPath();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SetUIPrefabPath()
    {
        m_uiPrefabPath.Add("UI/StatusUI");
        m_uiPrefabPath.Add("UI/SelectSoldierUI");
        //�κ��丮 �߰� ����
    }
    
    public void AddUI(UIPrefab uiPrefab)//�������� ui�߰�
    {
        m_ui.Add(Instantiate(Resources.Load(m_uiPrefabPath[(int)uiPrefab])) as GameObject);
        m_ui[m_ui.Count - 1].GetComponent<Canvas>().sortingOrder = m_ui.Count;
        m_ui[m_ui.Count - 1].transform.SetParent(this.gameObject.transform);
    }

    public void RemoveOneUI()//���� ���� ui����
    {
        if(m_ui.Count> 0) 
        {
            Destroy(m_ui[m_ui.Count-1]);
            m_ui.RemoveAt(m_ui.Count-1);
        }
    }
    
}
