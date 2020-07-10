using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class HeureController : MonoBehaviour
{
    public static float timer = 0.0f;
    public static int minutes_unit = 0;
    public static int minutes_dec = 0;
    public static int houres_unit = 8;
    public static int houres_dec = 0;

    UnityEngine.UI.Text text;

    private void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = houres_dec.ToString() + houres_unit.ToString() + " : " + minutes_dec.ToString() + minutes_unit.ToString();

        timer += Time.deltaTime;
        minutes_unit = (int)(timer % 60);

        //Debug.Log(houres_dec);
        //Debug.Log(houres_unit);

        if (minutes_unit == 10)
        {
            timer = 0;
            minutes_unit = 0;
            minutes_dec += 1;
        }
        if (minutes_dec == 6)
        {
            minutes_dec = 0;
            //minutes_unit = 0;
            houres_unit += 1;
        }
        if (houres_unit >= 10)
        {
            houres_unit -= 10;
            houres_dec += 1;
        }
        if (houres_dec == 2 && houres_unit >= 4)
        {
            houres_unit -= 4;
            houres_dec = 0;
        }


    }
}
