using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance = null;
    GameVariables m_variables = new GameVariables();
    public delegate void void_event();

    public void_event BookOfRecordsClicked;



    public class GameVariables
    {
        //Countdown timer
        public float m_WorkTimer = 0.0f;
        public bool m_isWorkTimerRunning = false;

        //Quota To meet
        public int m_currentPlayerQuota = 0;
        public int m_quotaNumberToReach = 0;

        //Check if bookOpen is active
        public bool m_openBookActive = false;

        //check if stamp is within boundary
        public bool m_stampWithinBoundary = false;

    }

    public GameVariables variables
    {
        get
        {
            return m_variables;
        }
    }



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

    public static GameManager GetInstance()
    {
        return m_instance;
    }
    public static GameManager instance
    {
        get
        {
            return m_instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }


}
    