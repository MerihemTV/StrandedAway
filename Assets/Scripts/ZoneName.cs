using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneName : MonoBehaviour
{

    public static string zone;
    public Text text;
   
    // Start is called before the first frame update
    void Start()
    {
        zone = "Campement";
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = zone;
    }
}
