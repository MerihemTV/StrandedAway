using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAttackController : MonoBehaviour
{
    private float time_btw_attack;
    public float start_time_btw_attack;



    // Update is called once per frame
    void Update()
    {
        if (time_btw_attack <=0)
        {
            if (Input.GetKey("g"))
            {

            }

            time_btw_attack = start_time_btw_attack;
        }
        else
        {
            time_btw_attack -= Time.deltaTime;
        }
    }
}
