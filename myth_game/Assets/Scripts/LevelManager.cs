using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int m_levelChosen;


    public int m_currentDay = 1;
    private static LevelManager m_instance = null;

    void Awake()
	{
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    [System.Serializable]
	public class DaysQuota
	{
        public int m_Level;
        public List<int> m_quotaPerDay;
    }

    //
    public List<DaysQuota> m_quotaPerDay;


    public int TheQuotaForToday()
	{
		foreach (var item in m_quotaPerDay)
		{
            if(item.m_Level == m_levelChosen)
			{
                return item.m_quotaPerDay[m_currentDay - 1];
			}

		}
        return -1;
	}

    //// Start is called before the first frame update
    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
