using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    public static FadeScreen screen;

    public Image fade;
    public float fadeSpeed = 1.0f;

    bool m_loading = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        screen = this;
    }

    public void LoadScene(string scene)
    {
        if(!m_loading)
        {
            m_loading = true;
            StartCoroutine(LoadSceneRoutine(scene));
        }
    }

    IEnumerator LoadSceneRoutine(string scene)
    {
        while(fade.color.a < 1)
        {
            fade.color += new Color(0, 0, 0, 1) * fadeSpeed * Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(scene);

        while(fade.color.a > 0)
        {
            fade.color -= new Color(0, 0, 0, 1) * fadeSpeed * Time.deltaTime;
            yield return null;
        }

        m_loading = false;
    }
}
