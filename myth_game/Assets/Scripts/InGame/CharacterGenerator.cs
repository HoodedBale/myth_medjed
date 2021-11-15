using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public float fadeSpeed = 1;

    public List<GameObject> bodies = new List<GameObject>();
    public List<GameObject> heads = new List<GameObject>();
    public List<GameObject> mouths = new List<GameObject>();
    public List<GameObject> noses = new List<GameObject>();
    public List<GameObject> eyes = new List<GameObject>();

    int currentBody = 0;
    int currentHead = 0;
    int currentMouth = 0;
    int currentNose = 0;
    int currentEyes = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCharacter();
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateCharacter()
    {
        currentBody = Random.Range(0, bodies.Count);
        currentHead = Random.Range(0, heads.Count);
        currentMouth = Random.Range(0, mouths.Count);
        currentNose = Random.Range(0, noses.Count);
        currentEyes = Random.Range(0, eyes.Count);

        GameObject temp = Instantiate(bodies[currentBody]);
        temp.transform.SetParent(transform);
        temp.transform.localPosition = Vector3.zero;

        temp = Instantiate(heads[currentHead]);
        temp.transform.SetParent(transform);
        temp.transform.localPosition = Vector3.zero;
        GameObject head = temp;

        temp = Instantiate(mouths[currentMouth]);
        temp.transform.SetParent(head.transform.GetChild(0));
        //temp.transform.localPosition = Vector3.zero;
        temp.transform.position = transform.position;

        temp = Instantiate(noses[currentNose]);
        temp.transform.SetParent(head.transform.GetChild(0));
        //temp.transform.localPosition = Vector3.zero;
        temp.transform.position = transform.position;

        temp = Instantiate(eyes[currentEyes]);
        temp.transform.SetParent(head.transform.GetChild(0));
        //temp.transform.localPosition = Vector3.zero;
        temp.transform.position = transform.position;
    }

    IEnumerator FadeIn()
    {
        List<SpriteRenderer> sprites = new List<SpriteRenderer>(transform.GetComponentsInChildren<SpriteRenderer>());
        foreach(var sprite in sprites)
        {
            sprite.color = Color.black;
        }

        while(sprites[0].color.r < 1)
        {
            foreach(var sprite in sprites)
            {
                sprite.color += Color.white * fadeSpeed * Time.deltaTime;
            }

            yield return null;
        }
    }

    public void Kill()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        List<SpriteRenderer> sprites = new List<SpriteRenderer>(transform.GetComponentsInChildren<SpriteRenderer>());

        while (sprites[0].color.r > 0)
        {
            foreach (var sprite in sprites)
            {
                sprite.color -= Color.white * fadeSpeed * Time.deltaTime;
            }

            yield return null;
        }

        Destroy(gameObject);
    }
}
