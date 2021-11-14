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
        this.GetComponent<SpriteRenderer>().sprite = m_bookColor[(int)Random.Range(0.0f, 3.0f)];
    }

	void OnDisable()
	{
		
	}

	// Update is called once per frame
	void Update()
    {


    }
}
