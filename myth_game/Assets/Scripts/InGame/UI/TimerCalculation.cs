using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCalculation : MonoBehaviour
{
    //1.0f =  1 second

    public TMP_Text m_timerText;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TimerCalculationLogic();

        if (Input.GetKeyDown(KeyCode.N))
            GameManager.instance.variables.m_WorkTimer -= 10.0f ;
    }


    void TimerCalculationLogic()
    {
        //Check if game manager timer is running
        if (GameManager.instance.variables.m_isWorkTimerRunning)
        {
            if (GameManager.instance.variables.m_WorkTimer > 0)
            {
                GameManager.instance.variables.m_timerRunsOut = false;
                GameManager.instance.variables.m_WorkTimer -= Time.deltaTime;
                m_timerText.text = DisplayTime(GameManager.instance.variables.m_WorkTimer);
            }
            else
            {
                GameManager.instance.variables.m_WorkTimer = 0;
                GameManager.instance.variables.m_isWorkTimerRunning = false;
                GameManager.instance.variables.m_timerRunsOut = true;
            }
        }
    }

    //Display timer
    string DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
