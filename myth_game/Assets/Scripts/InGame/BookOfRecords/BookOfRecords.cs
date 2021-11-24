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
        }

        
    }
}
