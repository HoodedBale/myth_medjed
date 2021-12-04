using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RebornScene : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    public Image fade;
    public float fadeSpeed = 1;
    public TextMeshProUGUI text;
    public GameObject nextPagePrompt;
    public float nextPageDelay = 2.0f;

    public GameObject quitButton;

    int currentPage = -1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextPage());
    }

    // Update is called once per frame
    void Update()
    {
        if(nextPagePrompt.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                nextPagePrompt.SetActive(false);
                StartCoroutine(NextPage());
            }
        }
    }

    IEnumerator NextPage()
    {
        while(fade.color.a < 1)
        {
            fade.color += new Color(0, 0, 0, 1) * fadeSpeed * Time.deltaTime;
            yield return null;
        }

        ++currentPage;
        text.text = dialogue[currentPage];

        while(fade.color.a > 0)
        {
            fade.color -= new Color(0, 0, 0, 1) * fadeSpeed * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(nextPageDelay);

        if(currentPage < dialogue.Count - 1)
        {
            nextPagePrompt.SetActive(true);
        }
        else
        {
            quitButton.SetActive(true);
        }
    }

    public void QuitButton()
    {
        StartCoroutine(QuitRoutine());
    }

    IEnumerator QuitRoutine()
    {
        while (fade.color.a < 1)
        {
            fade.color += new Color(0, 0, 0, 1) * fadeSpeed * Time.deltaTime;
            yield return null;
        }
        Application.Quit();
    }

}
