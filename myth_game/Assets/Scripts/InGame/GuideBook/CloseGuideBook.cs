using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGuideBook : MonoBehaviour
{
    // Start is called before the first frame update
    public void CloseBook()
    {
        this.gameObject.SetActive(false);
    }
}
