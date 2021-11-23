using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBook : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_openGuideBook;
   // public Text m_CrimeText;
    void OnEnable()
    {
        //GameManager.instance.InstantiateOpenGuideBookEvent += InstantiateOpenGuideBook;
        
    }

	void OnDisable()
	{
        //GameManager.instance.InstantiateOpenGuideBookEvent -= InstantiateOpenGuideBook;
    }

	// Update is called once per frame
	void Update()
    {
        //m_CrimeText = 

    }

    public void InstantiateOpenGuideBook()
	{
        GameManager.instance.variables.m_currentopenGuideBook = Instantiate(m_openGuideBook);
        GameManager.instance.variables.m_currentopenGuideBook.GetComponent<Transform>().position = new Vector3();
        GameManager.instance.variables.m_openGuideBookActive = true;
    }
}
