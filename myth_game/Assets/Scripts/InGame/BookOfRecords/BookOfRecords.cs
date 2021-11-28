using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOfRecords : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> m_bookColor;

    public GameObject m_openBook;
    

    void OnEnable()
    {
        GameManager.instance.InstantiateOpenBookEvent += InstantiateOpenBookOfRecord;
        GameManager.instance.ReturnBookToCustomerEvent += ReturnTheBookOfRecord;
        this.GetComponent<SpriteRenderer>().sprite = m_bookColor[(int)Random.Range(0.0f, 3.0f)];
    }

	void OnDisable()
	{
        GameManager.instance.InstantiateOpenBookEvent -= InstantiateOpenBookOfRecord;
        GameManager.instance.ReturnBookToCustomerEvent -= ReturnTheBookOfRecord;
    }

	// Update is called once per frame
	void Update()
    {


    }


    void InstantiateOpenBookOfRecord()
    {
        GameManager.instance.variables.m_currentOpenBookOfRecord = Instantiate(m_openBook);
        GameManager.instance.variables.m_openBookActive = true;

        if (GameManager.instance.variables.m_currentOpenBookOfRecord.GetComponent<OpenBookOfRecords>())
        {
            GameManager.instance.variables.m_sins.Clear();
            OpenBookOfRecords temp = GameManager.instance.variables.m_currentOpenBookOfRecord.GetComponent<OpenBookOfRecords>();
            List<SinsScriptableObject.MiniSins> minisins = new List<SinsScriptableObject.MiniSins>();

            temp.m_characterName.text = MiscScripts.GeneratePresetName();

            if (GameManager.instance.m_GameLevel == 1)
            {
                int MaxHellNumber = GameManager.instance.m_Level1MaxStamp;
                int MaxHellRecord = GameManager.instance.m_Level1MaxRecords;
                minisins = GameManager.instance.m_sinsObject.GenerateSinList(MaxHellNumber, MaxHellRecord);
                //foreach (var sins in minisins)
                //{
                //    Debug.Log("The hell number :" + sins.m_hellNumber + "  The Sins :" + sins.SinsName);
                //}
                temp.m_characterRecords.text = GameManager.instance.m_sinsObject.ConvertListOfSinsToString(minisins); 

            }
            else if (GameManager.instance.m_GameLevel == 2)
            {
                int MaxHellNumber = GameManager.instance.m_Level2MaxStamp;
                int MaxHellRecord = GameManager.instance.m_Level2MaxRecords;
                minisins = GameManager.instance.m_sinsObject.GenerateSinList(MaxHellNumber, MaxHellRecord);
                //foreach (var sins in minisins)
                //{
                //    Debug.Log("The hell number :" + sins.m_hellNumber + "  The Sins :" + sins.SinsName);
                //}
                temp.m_characterRecords.text = GameManager.instance.m_sinsObject.ConvertListOfSinsToString(minisins);
            }
            else if (GameManager.instance.m_GameLevel == 3)
            {

                int MaxHellNumber = GameManager.instance.m_Level3MaxStamp;
                int MaxHellRecord = GameManager.instance.m_Level3MaxRecords;
                //GameManager.instance.m_sinsObject.GenerateSinList(MaxHellNumber, MaxHellRecord,true);
                minisins = GameManager.instance.m_sinsObject.GenerateSinList(MaxHellNumber, MaxHellRecord,true);
                //foreach (var sins in minisins)
                //{
                //    Debug.Log("The hell number :" + sins.m_hellNumber + "  The Sins :" + sins.SinsName);
                //}
                temp.m_characterRecords.text = GameManager.instance.m_sinsObject.ConvertListOfSinsToString(minisins);
            }

            GameManager.instance.variables.m_sins = minisins;
        }
    }


    void ReturnTheBookOfRecord()
	{
		foreach (var item in GameManager.instance.variables.m_sins)
		{
            Debug.Log("Hell Number : " + item.m_hellNumber);
		}

        foreach (var item in GameManager.instance.variables.m_inkStamped)
        {
            Debug.Log("Stamp Number : " + item);
        }

        if (GameManager.instance.variables.m_inkStamped.Count != 0)
        {
            
            if (GameManager.instance.m_sinsObject.CompareWithList(GameManager.instance.variables.m_sins, GameManager.instance.variables.m_inkStamped))
            {
                Debug.Log("Correct");
                //GameManager.instance.CustomerServedCorrectlyEvent();
                //GameManager.instance.DestroyInstantiateEvent();
            }
            else
            {

                Debug.Log("Wrong");

            }
        }
        else
		{
            Debug.Log("havent stamp yet");
		}
    }
}
