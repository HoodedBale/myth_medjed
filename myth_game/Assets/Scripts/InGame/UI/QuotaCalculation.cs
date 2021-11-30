using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class QuotaCalculation : MonoBehaviour
{
    public TMP_Text m_quotaInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int number = GameManager.instance.variables.m_quotaNumberToReach - GameManager.instance.variables.m_currentPlayerQuota;
        if (number >= 0)
            m_quotaInput.text = (number).ToString();
        else
            m_quotaInput.text = "0";
    }
}
