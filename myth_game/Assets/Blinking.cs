using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{

    SpriteRenderer temp;
    bool check = true;

    float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        temp = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(check)
		{
         
            temp.color += new Color(0, 0, 0, 1.0f) * speed * Time.deltaTime;
        }
        else
		{
            temp.color -= new Color(0, 0, 0, 1.0f) * speed * Time.deltaTime;
        }

        if (temp.color.a >= 0.9f)
        {
            //Debug.Log("Swap False");
            check = false;
        }
        else if (temp.color.a <= 0.1f)
        {
            //Debug.Log("Swap True");
            check = true;
        }
    }
}
