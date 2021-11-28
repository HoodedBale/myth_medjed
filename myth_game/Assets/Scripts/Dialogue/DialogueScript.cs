using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    DialogueScriptableObject scripts;
    public float totalTimerForDialogue = 2.0f;
    public float WinningLosingDialogue = 5.0f;

    float m_timerForDialogue = 2.0f;
    
    bool m_dialogueCalled = false;
    bool m_winningLosingDialogueCalled = false;
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
            if (!m_winningLosingDialogueCalled)
            {
                if (m_timerForDialogue > 0.0f)
                {
                    m_timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    m_dialogueCalled = false;
                    GameManager.instance.m_Textbox.SetActive(false);
                }
            }
            else
            {
                if (m_timerForDialogue > 0.0f)
                {
                    m_timerForDialogue -= Time.deltaTime;
                }
                else
                {
                    m_dialogueCalled = false;
                    GameManager.instance.m_Textbox.SetActive(false);
                    GameManager.instance.variables.m_dialogueTimerEnded = true;
                    m_winningLosingDialogueCalled = false;
                }
            }
        }
    }

    void GenerateDialogue()
    {
        GameManager.instance.m_Text.text = GameManager.instance.m_dialogueObject.GetRandomDialogueOfType(GameManager.instance.variables.m_dialogueType);

        if (GameManager.instance.variables.m_dialogueType == DialogueScriptableObject.DIALOGUETYPE.QUOTAFAIL ||
           GameManager.instance.variables.m_dialogueType == DialogueScriptableObject.DIALOGUETYPE.QUOTAPASS)
        {
            m_timerForDialogue = WinningLosingDialogue;
            m_winningLosingDialogueCalled = true;
            GameManager.instance.variables.m_dialogueTimerEnded = false;
        }
        else
            m_timerForDialogue = totalTimerForDialogue;

        m_dialogueCalled = true;
    }
}
