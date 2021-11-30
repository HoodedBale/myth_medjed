using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMan : MonoBehaviour
{
    public static SoundMan soundman;

    public List<AudioClip> sfxList = new List<AudioClip>();
    public GameObject sfxPrefab;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        soundman = this;
    }

    public void PlaySFX(int id)
    {
        GameObject sfx = Instantiate(sfxPrefab);
        sfx.GetComponent<AudioSource>().clip = sfxList[id];
        sfx.GetComponent<AudioSource>().Play();
    }
}
