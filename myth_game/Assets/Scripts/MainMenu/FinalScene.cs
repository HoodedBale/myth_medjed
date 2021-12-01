using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    public float choicesDelay = 5;
    public GameObject choices;

    public GameObject rebornDialogue;
    public string rebornscene = "Reborn";

    // Start is called before the first frame update
    void Start()
    {
        choices.SetActive(false);
        StartCoroutine(ChoiceDelayRoutine());
    }

    IEnumerator ChoiceDelayRoutine()
    {
        yield return new WaitForSeconds(choicesDelay);
        choices.SetActive(true);
    }

    public void RebornDialogue(bool open)
    {
        rebornDialogue.SetActive(open);
    }

    public void PickReborn()
    {
        FadeScreen.screen.LoadScene(rebornscene);
    }
}
