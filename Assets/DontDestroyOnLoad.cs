using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            //Debug.Log("plus d'une instance de hearts");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
}
