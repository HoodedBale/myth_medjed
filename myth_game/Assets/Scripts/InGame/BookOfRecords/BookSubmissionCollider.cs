using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSubmissionCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "BookOfRecords")
		{
			GameManager.instance.variables.WithinBookSubmissionCollider = true;
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "BookOfRecords")
		{
			GameManager.instance.variables.WithinBookSubmissionCollider = false;
		}
	}
}
