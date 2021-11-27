using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


using TMPro;
public class OpenBookOfRecords : MonoBehaviour
{
    public Canvas m_canvas;
    public TMP_Text m_characterName;
    public TMP_Text m_characterRecords;


    void OnEnable()
    {
        m_canvas.worldCamera = Camera.main;
    }
}
