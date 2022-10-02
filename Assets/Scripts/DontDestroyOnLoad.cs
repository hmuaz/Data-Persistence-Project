using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static DontDestroyOnLoad ddol;
    private void Start()
    {
        if (ddol != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ddol = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
