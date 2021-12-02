using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject levelManager;
    public string sceneName;

    public GameObject m_playButton;
    public GameObject m_exitButton;
    public GameObject m_howButton;
    public GameObject Panel;
    public GameObject m_levelSelect;
	// Start is called before the first frame update

	void Start()
	{

        levelManager = GameObject.Find("LevelManager");
		
	}

	public void GoToGameSceneLevel1()
	{
        levelManager.GetComponent<LevelManager>().m_levelChosen = 1;
        //SceneManager.LoadScene(sceneName);
        FadeScreen.screen.LoadScene(sceneName);
	}

    public void GoToGameSceneLevel2()
    {
        levelManager.GetComponent<LevelManager>().m_levelChosen = 2;
        //SceneManager.LoadScene(sceneName);
        FadeScreen.screen.LoadScene(sceneName);
    }

    public void GoToGameSceneLevel3()
    {
        levelManager.GetComponent<LevelManager>().m_levelChosen = 3;
        //SceneManager.LoadScene(sceneName);
        FadeScreen.screen.LoadScene(sceneName);
    }

    public void PlayButtonClick()
    {
        m_playButton.SetActive(false); 
        m_exitButton.SetActive(false);  
        m_levelSelect.SetActive(true);
        m_howButton.SetActive(false);
    }

    public void BackButtonClick()
    {
        m_playButton.SetActive(true);
        m_exitButton.SetActive(true);
        m_levelSelect.SetActive(false);
        m_howButton.SetActive(true);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void HowButtonClick()
    {
        m_playButton.SetActive(false);
        m_exitButton.SetActive(false);
        m_levelSelect.SetActive(false);
        m_howButton.SetActive(false);
        Panel.SetActive(true);
    }
    public void PanelClick()
    {
        m_playButton.SetActive(true);
        m_exitButton.SetActive(true);
        m_levelSelect.SetActive(false);
        m_howButton.SetActive(true);
        Panel.SetActive(false);
    }
}
