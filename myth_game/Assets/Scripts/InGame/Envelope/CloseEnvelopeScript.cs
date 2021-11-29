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


    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void StartTheDay()
	{
        if(m_openEnvelope)
            m_openEnvelope.SetActive(false);


        this.gameObject.SetActive(false);

        //GameManager.instance.StartTheDayNew();
	}
}
