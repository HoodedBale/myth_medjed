using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class CloseEnvelopeScript : MonoBehaviour
{
    public GameObject m_openEnvelope;
    public Canvas m_openEvelopeCanvas;

    [Space()]
    public GameObject m_day1_1;
    public GameObject m_day2_1;
    public GameObject m_day3_1;

    [Space()]
    public GameObject m_day1_2;
    public GameObject m_day2_2;
    public GameObject m_day3_2;

    [Space()]
    public GameObject m_day1_3;
    public GameObject m_day2_3;
    public GameObject m_day3_3;
    public GameObject m_reincarnateHelper;

    [Space()]
    public GameObject m_quotaText;

    GameObject theCurrentDay;
    bool onceActive = false;
    // Start is called before the first frame update
    void Start()
    {
        SoundMan.soundman.PlaySFX(3);
        if (GameManager.instance.variables.m_newStartDay)
            this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.variables.m_newStartDay)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);


            //Check if there is any game object clicked
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "CloseEnvelope")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        m_openEvelopeCanvas.worldCamera = Camera.main;

                        m_openEnvelope.SetActive(true);
                        
                    }
                }
            }
        }


        if (m_openEnvelope.activeSelf)
        {
            LevelManager levelManager = GameManager.instance.m_levelManager.GetComponent<LevelManager>();
            if (m_quotaText.GetComponent<TMP_Text>())
            {
                m_quotaText.GetComponent<TMP_Text>().text = levelManager.TheQuotaForToday().ToString() + " Souls";
            }
            GameManager.instance.variables.m_quotaNumberToReach = levelManager.TheQuotaForToday();

            if (!onceActive)
            {
                //SoundMan.soundman.PlaySFX(5);
                //get which level then which day
                switch (levelManager.m_levelChosen)
                {
                    case 1:
                        switch (levelManager.m_currentDay)
                        {
                            case 1:
                                theCurrentDay = m_day1_1;
                                break;
                            case 2:
                                theCurrentDay = m_day2_1;
                                break;
                            case 3:
                                theCurrentDay = m_day3_1;
                                break;
                        }

                        break;

                    case 2:
                        switch (levelManager.m_currentDay)
                        {
                            case 1:
                                theCurrentDay = m_day1_2;
                                break;
                            case 2:
                                theCurrentDay = m_day2_2;
                                break;
                            case 3:
                                theCurrentDay = m_day3_2;
                                break;
                        }
                        break;

                    case 3:
                        switch (levelManager.m_currentDay)
                        {
                            case 1:
                                theCurrentDay = m_day1_3;
                                m_reincarnateHelper.SetActive(true);
                                break;
                            case 2:
                                theCurrentDay = m_day2_3;
                                m_reincarnateHelper.SetActive(true);
                                break;
                            case 3:
                                theCurrentDay = m_day3_3;
                                m_reincarnateHelper.SetActive(true);
                                break;
                        }
                        break;
                }
                onceActive = true;
                theCurrentDay.SetActive(true);
            }

        }
    }

    public void StartTheDay()
	{
        SoundMan.soundman.PlaySFX(1);
        if(m_openEnvelope)
            m_openEnvelope.SetActive(false);

        if (m_reincarnateHelper.activeSelf)
            m_reincarnateHelper.SetActive(false);

        this.gameObject.SetActive(false);
        onceActive = false;
        GameManager.instance.StartTheDayNewEvent();
    }
}
