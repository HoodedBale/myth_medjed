using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScripts : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject m_bookOfRecordPrefab;

    public Transform m_bookOfRecordSpawnLocation;
    public Transform m_bookOfRecordStopLocation;


    private GameObject tempBookOfRecord;

    // Start is called before the first frame update
    void Start()
    {
        tempBookOfRecord = null;
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
            //Currently serving customer
            GameManager.instance.variables.m_isServingCustomer = true;
        }

        //Move the book
        float step = speed * Time.deltaTime;
        if(tempBookOfRecord)
            tempBookOfRecord.transform.position = Vector3.MoveTowards(tempBookOfRecord.transform.position, m_bookOfRecordStopLocation.position, step);

    }
}
