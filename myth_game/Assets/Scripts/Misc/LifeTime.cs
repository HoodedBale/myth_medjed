using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float life = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator StartLife()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
