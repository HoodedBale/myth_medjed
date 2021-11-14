using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class GameScripts : MonoBehaviour
{

    bool calculatePosition;
    
    Vector3 m_findPosition;
    GameObject m_stampGameObject;

    GameObject m_stampInk;

    public TMP_Text m_timerText;

    public GameObject m_stampInkPrefab;

    // Start is called before the first frame update
    void Start()
    {
        calculatePosition = false;
        GameManager.instance.variables.m_WorkTimer = 50.0f;
        GameManager.instance.variables.m_isWorkTimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCalculation();
        StampCalculation();
    }


    void TimerCalculation()
	{
        if(GameManager.instance.variables.m_isWorkTimerRunning)
		{
            if (GameManager.instance.variables.m_WorkTimer > 0)
            {
                GameManager.instance.variables.m_WorkTimer -= Time.deltaTime;
                m_timerText.text = DisplayTime(GameManager.instance.variables.m_WorkTimer);
            }
            else
            {
                GameManager.instance.variables.m_WorkTimer = 0;
                GameManager.instance.variables.m_isWorkTimerRunning = false;
            }
        }
	}

    string DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void StampCalculation()
	{
        //Moving stamp around
        if (calculatePosition)
        {
            RecalculatePosition();
        }

        //Check for raycast
        else if (Input.GetMouseButtonDown(0) && !calculatePosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            //Check if there is any game object clicked
            if (hit.collider != null)
            {
                //Check if click on closed book of records
                if (hit.collider.gameObject.tag == "BookOfRecords")
                {
                    if (hit.collider.gameObject.GetComponent<BookOfRecords>())
                    {
                        hit.collider.gameObject.GetComponent<BookOfRecords>().m_openBook.SetActive(true);
                        GameManager.instance.variables.m_openBookActive = true;

                    }
                }
                //Check if click on stamp
                else if (hit.collider.gameObject.tag == "Stamp")
                {
                    calculatePosition = true;
                    m_stampGameObject = GameObject.Find(hit.collider.name);
                    m_findPosition = m_stampGameObject.GetComponent<StampInk>().m_initialPosition;
                }
            }
        }
    }


    void RecalculatePosition()
    {
        if (m_stampGameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                calculatePosition = false;

                //Need check if within the stamp boundary
                if (GameManager.instance.variables.m_stampWithinBoundary)
                {
                    //Create the ink
                    m_stampInk = Instantiate(m_stampInkPrefab);
                    //Set ink to current stamp position
                    m_stampInk.transform.position = m_stampGameObject.transform.position;
                    //Set ink sprite to current stamp sprite
                    if (m_stampInk.GetComponent<SpriteRenderer>() && m_stampGameObject.GetComponent<StampInk>())
                        m_stampInk.GetComponent<SpriteRenderer>().sprite = m_stampGameObject.GetComponent<StampInk>().stampInk;

                }

                //Reset stamp position
                m_stampGameObject.transform.position = m_findPosition;
                m_stampGameObject = null;
            }
            if (calculatePosition)
            {
                //Move around the stamp
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                m_stampGameObject.transform.position = new Vector2(mousePos.x, mousePos.y);

            }
        }
    }
}
