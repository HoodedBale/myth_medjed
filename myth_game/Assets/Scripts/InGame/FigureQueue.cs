using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureQueue : MonoBehaviour
{
    public class Figure
    {
        public GameObject figObj;
        public Vector3 startPos;
        public float weight;
        public float flip = 1;
    }

    public Transform start, end;
    public Vector2 startOffset;
    public float startScale = 1, endScale = 0.25f;
    public int maxFigures = 5;
    public GameObject figurePrefab;
    public float moveSpeed = 1;

    Queue<Figure> figureQueue = new Queue<Figure>();

    // Start is called before the first frame update
    void Start()
    {
        FillQueue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            MoveLine();
        }
    }

    Figure CreateFigure()
    {
        Figure fig = new Figure();
        fig.figObj = Instantiate(figurePrefab);
        float randomOff = Random.Range(startOffset.x, startOffset.y);
        if (randomOff < 0)
        {
            fig.flip = -1;
        }
        fig.figObj.transform.position = start.position + new Vector3(randomOff, 0, 0);
        fig.figObj.transform.localScale = new Vector3(startScale * fig.flip, startScale, 1);
        fig.startPos = fig.figObj.transform.position;
        fig.weight = 0;
        return fig;
    }

    public void MoveLine()
    {
        if (figureQueue.Count <= 0)
        {
            figureQueue.Enqueue(CreateFigure());
            return;
        }

        StartCoroutine(MoveLineRoutine());
    }

    IEnumerator MoveLineRoutine()
    {
        float oldWeight = figureQueue.Peek().weight;
        while(figureQueue.Peek().weight - oldWeight < 1)
        {
            foreach (var fig in figureQueue)
            {
                fig.weight += moveSpeed * Time.deltaTime;
                float finalWeight = fig.weight / maxFigures;
                Vector3 dir = end.position - fig.startPos;
                float weightDir = endScale - startScale;
                fig.figObj.transform.position = fig.startPos + finalWeight * dir;
                fig.figObj.GetComponent<Animator>().SetBool("walk", true);
                fig.figObj.transform.localScale =
                    new Vector3(startScale, startScale, 1) + finalWeight * weightDir * new Vector3(1, 1, 0);
                fig.figObj.transform.localScale = new Vector3(
                    fig.figObj.transform.localScale.x * fig.flip,
                    fig.figObj.transform.localScale.y,
                    fig.figObj.transform.localScale.z);
            }
            yield return null;
        }

        foreach(var fig in figureQueue)
        {
            fig.figObj.GetComponent<Animator>().SetBool("walk", false);
        }

        if(figureQueue.Peek().weight >= maxFigures)
        {
            Destroy(figureQueue.Dequeue().figObj);
        }

        figureQueue.Enqueue(CreateFigure());
    }

    public void FillQueue()
    {
        for(int i = maxFigures; i >= 0; --i)
        {
            Figure fig = CreateFigure();
            fig.weight = i;
            float finalWeight = fig.weight / maxFigures;
            Vector3 dir = end.position - fig.startPos;
            float weightDir = endScale - startScale;
            fig.figObj.transform.position = fig.startPos + finalWeight * dir;
            fig.figObj.GetComponent<Animator>().SetBool("walk", true);
            fig.figObj.transform.localScale =
                new Vector3(startScale, startScale, 1) + finalWeight * weightDir * new Vector3(1, 1, 0);
            fig.figObj.transform.localScale = new Vector3(
                fig.figObj.transform.localScale.x * fig.flip,
                fig.figObj.transform.localScale.y,
                fig.figObj.transform.localScale.z);

            figureQueue.Enqueue(fig);
        }
    }
}
