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
        this.GetComponent<SpriteRenderer>().sprite = m_bookColor[(int)Random.Range(0.0f, 3.0f)];
    }

	void OnDisable()
	{
        GameManager.instance.InstantiateOpenBookEvent -= InstantiateOpenBookOfRecord;
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
            OpenBookOfRecords temp = GameManager.instance.variables.m_currentOpenBookOfRecord.GetComponent<OpenBookOfRecords>();

            temp.m_characterName.text = MiscScripts.GeneratePresetName();

            if (GameManager.instance.m_GameLevel == 1)
            {
                int MaxHellNumber = GameManager.instance.m_Level1MaxStamp;
                int MaxHellRecord = GameManager.instance.m_Level1MaxRecords;
                List<SinsScriptableObject.MiniSins> minisins = GameManager.instance.m_sinsObject.GenerateSinList(MaxHellNumber, MaxHellRecord);
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
                List<SinsScriptableObject.MiniSins> minisins = GameManager.instance.m_sinsObject.GenerateSinList(MaxHellNumber, MaxHellRecord);
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
                List<SinsScriptableObject.MiniSins> minisins = GameManager.instance.m_sinsObject.GenerateSinList(MaxHellNumber, MaxHellRecord,true);
                //foreach (var sins in minisins)
                //{
                //    Debug.Log("The hell number :" + sins.m_hellNumber + "  The Sins :" + sins.SinsName);
                //}
                temp.m_characterRecords.text = GameManager.instance.m_sinsObject.ConvertListOfSinsToString(minisins);
            }


        }
    }
}
