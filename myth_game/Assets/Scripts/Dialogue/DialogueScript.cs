using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    DialogueScriptableObject scripts;
    public float totalTimerForDialogue = 2.0f;
    float m_timerForDialogue = 2.0f;
    bool m_dialogueCalled = false;
    // Start is called before the first frame update
    void Start()
    {
        scripts = GameManager.instance.m_dialogueObject;

        GameManager.instance.StartDialogueEvent += GenerateDialogue; 
    }

    // Update is called once per frame
    void Update()
    {
        if(m_dialogueCalled)
        {
            if (m_timerForDialogue > 0.0f)
            {
                m_timerForDialogue -= Time.deltaTime;
            }
            else
            {
                m_dialogueCalled = false;
                m_timerForDialogue = totalTimerForDialogue;
                GameManager.instance.m_Textbox.SetActive(false);
            }
               
        }
    }

    void GenerateDialogue()
    {
        GameManager.instance.m_Text.text = GameManager.instance.m_dialogueObject.GetRandomDialogueOfType(GameManager.instance.variables.m_dialogueType);
        m_dialogueCalled = true;
    }
}
