using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameScripts : MonoBehaviour
{

    bool m_isStampClicked;
    
    Vector3 m_initialStampPosition;
    GameObject m_stampGameObject;
    GameObject m_stampInk;

    //Timer
    public float m_dailyTimer;
    [Space()]

    //Quota
    public int m_quotaToReach;



    [Space()]
    //Gameobject
    public GameObject m_stampInkPrefab;


    // Start is called before the first frame update
    void Start()
    {
        m_isStampClicked = false;

        GameManager.instance.variables.m_WorkTimer = m_dailyTimer;
        GameManager.instance.variables.m_quotaNumberToReach = m_quotaToReach;
    }

    // Update is called once per frame
    void Update()
    {
        StampCalculation();

        WinningAndLosingCondition();

    }

    void WinningAndLosingCondition()
	{
        //Check if timer runs out 
        if(GameManager.instance.variables.m_timerRunsOut)
		{
            //If quota not met, reset scene
            if (GameManager.instance.variables.m_currentPlayerQuota != GameManager.instance.variables.m_quotaNumberToReach)
            {
                GameManager.instance.ResetVariablesEvent();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
            else
            {
                //WIn game
            }
		}

	}


    void StampCalculation()
	{
        //Create the ink on book / Move the stamp around the screen
        if (m_isStampClicked)
        {
            StampLogic();
        }

        //Check for raycast on which gameobject is clicked
        else if (Input.GetMouseButtonDown(0) && !m_isStampClicked)
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
                        GameManager.instance.InstantiateOpenBookEvent();

                    }
                }
                //Check if click on stamp
                else if (hit.collider.gameObject.tag == "Stamp")
                {
                    m_isStampClicked = true;

                    //Find specific stamp
                    m_stampGameObject = GameObject.Find(hit.collider.name);
                    m_initialStampPosition = m_stampGameObject.GetComponent<StampInk>().m_initialPosition;
                }
            }
        }
    }

    //Create the ink on book / Move the stamp around the screen
    void StampLogic()
    {
        if (m_stampGameObject)
        {
            //  If left click is detected within stamp boundary, create ink 
            //else 
            //  return stamp position
            if (Input.GetMouseButtonDown(0))
            {
                InstantiateInkOnBook();
            }

            //Check if left click is detected on stamp, move the stamp following mouse
            if (m_isStampClicked)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                m_stampGameObject.transform.position = new Vector2(mousePos.x, mousePos.y);

            }
        }
    }

    //Instantiate if Ink is on book
    void InstantiateInkOnBook()
	{
        m_isStampClicked = false;

        //Need check if within the stamp boundary and if there is openbook
        if (GameManager.instance.variables.m_stampWithinBoundary && GameManager.instance.variables.m_currentOpenBookOfRecord)
        {
            //Create the ink
            GameManager.instance.variables.m_currentInkUsed = m_stampInk = Instantiate(m_stampInkPrefab);
            //Set ink to current stamp position
            m_stampInk.transform.position = m_stampGameObject.transform.position;
            //Set ink sprite to current stamp sprite
            if (m_stampInk.GetComponent<SpriteRenderer>() && m_stampGameObject.GetComponent<StampInk>())
            {
                m_stampInk.GetComponent<SpriteRenderer>().sprite = m_stampGameObject.GetComponent<StampInk>().stampInk;
                
                //Get Sprite Name
                string spriteName = m_stampGameObject.GetComponent<StampInk>().stampInk.name;

                //This is to set which ink is used, get the sprite name last number: eg: ink_2, we take in 2
                GameManager.instance.variables.m_stampedNumber = int.Parse(spriteName.Substring(spriteName.IndexOf('_') + 1));
                GameManager.instance.variables.m_isInkedOnBook = true;
            }

        }

        //Reset stamp position
        m_stampGameObject.transform.position = m_initialStampPosition;
        m_stampGameObject = null;
    }
}
