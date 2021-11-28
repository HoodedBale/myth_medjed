using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScripts : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject m_bookOfRecordPrefab;
    public GameObject m_spiritPrefab;


    public Transform m_bookOfRecordSpawnLocation;
    public Transform m_bookOfRecordStopLocation;


    public Transform m_spiritSpawnLocation;
    public Transform m_spiritStopLocation;
    public Transform m_spiritEndLocation;

    bool m_moveCharacter = false;


    private GameObject tempBookOfRecord;
    private GameObject tempSpirit;

    // Start is called before the first frame update
    void Start()
    {
        tempBookOfRecord = null;
        tempSpirit = null;
        m_moveCharacter = false;
        GameManager.instance.ReturnBookToCustomerEvent += MoveSpiritToTheEndPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //If there is no customer being served, instantiate a new book of record
        if(!GameManager.instance.variables.m_isServingCustomer)
		{
            //Create new book of record
            tempBookOfRecord = GameManager.instance.variables.m_currentBookOfRecord = Instantiate(m_bookOfRecordPrefab);
            tempBookOfRecord.transform.position = m_bookOfRecordSpawnLocation.position;


            tempSpirit = Instantiate(m_spiritPrefab);
            tempSpirit.transform.position = m_spiritSpawnLocation.position;

            //Currently serving customer
            GameManager.instance.variables.m_isServingCustomer = true; 
        }

        //Move the book if it is not in middle
        float step = speed * Time.deltaTime;
        if (tempBookOfRecord)
        {
            //Debug.Log("BOOK DONT EXIST");
            tempBookOfRecord.transform.position = Vector3.MoveTowards(tempBookOfRecord.transform.position, m_bookOfRecordStopLocation.position, step);
            tempSpirit.transform.position = Vector3.MoveTowards(tempSpirit.transform.position, m_spiritStopLocation.position, step);
        }


        //check if character move away
        if (m_moveCharacter && tempSpirit)
        {
            if (Vector3.Distance(tempSpirit.transform.position, m_spiritEndLocation.position) < 0.1f)
            {
                m_moveCharacter = false;
                Destroy(tempSpirit);

                //Call in next customer
                GameManager.instance.variables.m_isServingCustomer = false;
            }
            else
                tempSpirit.transform.position = Vector3.MoveTowards(tempSpirit.transform.position, m_spiritEndLocation.position, step);
        }
    }


    void MoveSpiritToTheEndPoint()
	{
        m_moveCharacter = true;
    }

    
}
