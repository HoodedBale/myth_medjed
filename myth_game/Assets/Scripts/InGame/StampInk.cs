using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampInk : MonoBehaviour
{
    public Sprite stampInk;
    public Vector3 m_initialPosition;
    // Start is called before the first frame update
    void Start()
    { 
        m_initialPosition = this.gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OpenBookOfRecords")
		{
            GameManager.instance.variables.m_stampWithinBoundary = true;
		}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "OpenBookOfRecords")
        {
            GameManager.instance.variables.m_stampWithinBoundary = false;
        }
    }

}
