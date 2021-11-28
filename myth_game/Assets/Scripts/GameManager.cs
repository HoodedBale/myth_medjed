using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject m_levelManager;
    public bool IsInputEnabled = true;

    public SinsScriptableObject m_sinsObject;

    public SinsScriptableObject SinsVariables
    {
        get
        {
            return m_sinsObject;
        }
    }

    public DialogueScriptableObject m_dialogueObject;

    public DialogueScriptableObject DialogueVariable
    {
        get
        {
            return m_dialogueObject;
        }
    }


    private static GameManager m_instance = null;
    GameVariables m_variables = new GameVariables();
    public delegate void void_event();

    public void_event BookOfRecordsClickedEvent;
    public void_event CustomerServedCorrectlyEvent;
    public void_event DestroyInstantiateEvent;
    public void_event ReturnBookToCustomerEvent;
    public void_event ShrinkAndRemoveBookEvent;
    public void_event CheckCustomerStampEvent;

    public void_event MoveTheLineEvent;

    public void_event InstantiateOpenBookEvent;
    
    //guidebook
    public void_event InstantiateOpenGuideBookEvent;

    public void_event WinGameEvent;
    public void_event LoseGameEvent;

    public void_event ResetVariablesEvent;

    public void_event StartDialogueEvent;

    //Game level variables
    [Space()]
    public int m_GameLevel = 1;

    [Space()]
    [Space()]
    public int m_Level1MaxStamp = 4;
    public int m_Level2MaxStamp = 7;
    public int m_Level3MaxStamp = 10;

    [Space()]
    [Space()]
    public int m_Level1MaxRecords = 0;
    public int m_Level2MaxRecords = 0;
    public int m_Level3MaxRecords = 0;


    [Space()]
    [Space()]
    public TMP_Text m_Text = null;
    public GameObject m_Textbox = null;



    public class GameVariables
    {
        //Countdown timer
        public float m_WorkTimer = 0.0f;
        public bool m_isWorkTimerRunning = false;
        public bool m_timerRunsOut = false;

        //Quota To meet
        public int m_currentPlayerQuota = 0;
        public int m_quotaNumberToReach = 0;

        //Check if bookOpen is active
        public bool m_openBookActive = false;

        //check if stamp is within boundary
        public bool m_stampWithinBoundary = false;

        //check if guidebook is open
        public bool m_openGuideBookActive = false;
        public GameObject m_currentopenGuideBook = null;

        //Customer variables
        //Check if customer being served
        public bool m_isServingCustomer = false;
        public List<SinsScriptableObject.MiniSins> m_sins = new List<SinsScriptableObject.MiniSins>();
        public List<int> m_inkStamped = new List<int>();


        //Current customer bookOfRecord
        public GameObject m_currentBookOfRecord = null;
        public GameObject m_currentOpenBookOfRecord = null;

        //Stamp Variable
        //Detect which stamp is used to stamp the book
        public GameObject m_currentInkUsed = null;
        public int m_stampedNumber;
        public bool m_isInkedOnBook;
        public bool WithinBookSubmissionCollider = false;


        //Type of dialogue
        public DialogueScriptableObject.DIALOGUETYPE m_dialogueType = DialogueScriptableObject.DIALOGUETYPE.NONE;
        public bool m_dialogueTimerEnded = true;

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
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


        m_levelManager = GameObject.Find("LevelManager");
        m_GameLevel = m_levelManager.GetComponent<LevelManager>().m_levelChosen;

        CustomerServedCorrectlyEvent += ServedCustomerCorrectly;
        DestroyInstantiateEvent += DestroyBookAndInk;
        ResetVariablesEvent += ResetVariable;
        StartDialogueEvent += SetDialogueActive;
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
        m_Textbox = GameObject.Find("DialogueBox");
        if (m_Textbox)
        {
            m_Text = m_Textbox.transform.Find("DialogueName").GetComponent<TMP_Text>();
        }
        m_Textbox.SetActive(false);
    }

    void Update()
    {

    }
    void OnEnable()
    {

    }
    void ResetVariable()
    {
        m_variables = new GameVariables();
    }

    void ServedCustomerCorrectly()
    {
        variables.m_currentPlayerQuota++;
    }

    void DestroyBookAndInk()
    {

        if (variables.m_currentOpenBookOfRecord)
            Destroy(variables.m_currentOpenBookOfRecord);

    }


    void SetDialogueActive()
    {
        m_Textbox.SetActive(true);
    }


}
    