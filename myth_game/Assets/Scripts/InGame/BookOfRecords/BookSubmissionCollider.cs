using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSubmissionCollider : MonoBehaviour
{
    GameObject tempBook = null;
    bool startTimer = false;
    //bool coroutineDone = false;
    float timer = 0.2f;
    float tempTimer = 0;


    Vector3 destinationScale = new Vector3(0.1f, 0.1f, 0.1f);
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.ShrinkAndRemoveBookEvent += ShrinkTheObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer)
        {
            if (tempTimer < 0)
            {
                Destroy(tempBook);
                tempBook = null;
                startTimer = false;
                tempTimer = timer;

            }
            else
            {
                tempTimer -= Time.deltaTime;
            }
        }
    }


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "BookOfRecords")
		{
			GameManager.instance.variables.WithinBookSubmissionCollider = true;
            tempBook = other.gameObject;

        }
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "BookOfRecords")
		{
			GameManager.instance.variables.WithinBookSubmissionCollider = false;
            //tempBook = null;
        }
	}

    void ShrinkTheObject()
    {

        if (tempBook)
        {
            tempTimer = timer;
            startTimer = true;

            StartCoroutine(ScaleOverTime(0.1f, tempBook));

        }
    }

    IEnumerator ScaleOverTime(float time, GameObject bookOfRecord)
    {
        Vector3 originalScale = bookOfRecord.transform.localScale;
        float currentTime = 0.0f;

        do
        {
            bookOfRecord.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

    }
}
