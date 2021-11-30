using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[CreateAssetMenu(fileName = "DialogueScriptable", menuName = "ScriptableObject/Dialogue")]
public class DialogueScriptableObject : ScriptableObject
{
    public enum DIALOGUETYPE
    {
        NONE = 0,
        CORRECT,
        WRONG,
        NOSTAMP,
        QUOTAFAIL,
        QUOTAPASS,
        NODUPLICATESTAMP
    }

    [System.Serializable]
    public class DialogueOptions
    {
        public DIALOGUETYPE type;
        public List<string> options;
    }

    public List<DialogueOptions> m_dialogueOption = new List<DialogueOptions>();


    public string GetRandomDialogueOfType(DIALOGUETYPE type)
    {
        foreach (var item in m_dialogueOption)
        {
            if(item.type == type)
            {
                int dialogueOption = Random.Range(0, item.options.Count);
                return item.options[dialogueOption];
            }
        }
        return null;
    }
}