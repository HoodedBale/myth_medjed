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

            //Generate the book of record info
            GenerateBookOfRecordInfo(tempBookOfRecord);


            //Currently serving customer
            GameManager.instance.variables.m_isServingCustomer = true;
        }

        //Move the book if it is not in middle
        float step = speed * Time.deltaTime;
        if (tempBookOfRecord && !GameManager.instance.variables.m_isInkedOnBook)
        {
            tempBookOfRecord.transform.position = Vector3.MoveTowards(tempBookOfRecord.transform.position, m_bookOfRecordStopLocation.position, step);
        }


        //Check if customer is sent to the right location ( Just stamped on book )
        if(GameManager.instance.variables.m_isInkedOnBook)
		{
			if (CheckIfSentCorrectly())
			{
                //Animation
                if (tempBookOfRecord)
                {
                    tempBookOfRecord.transform.position = Vector3.MoveTowards(tempBookOfRecord.transform.position, m_bookOfRecordSpawnLocation.position, step);
                }


                if (Vector3.Distance(tempBookOfRecord.transform.position, m_bookOfRecordSpawnLocation.position) < 0.1f)
                {
                    GameManager.instance.CustomerServedCorrectlyEvent();
                    GameManager.instance.DestroyInstantiateEvent();
                }

            }
            else
			{

			}
		}

    }

    bool CheckIfSentCorrectly()
	{

        //GameManager.instance.variables.m_stampedNumber;
        return true;
	}

    void GenerateBookOfRecordInfo(GameObject book)
	{
		if (book)
		{



		}
	}
}
