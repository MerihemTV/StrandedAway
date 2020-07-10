using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueChef : MonoBehaviour
{
    private static bool first = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && first)
        {
            first = false;
            GameObject chef = GameObject.Find("Chef_du_village_peacefull");
            if (chef!=null)
            {
                chef.GetComponent<DialogueChefDuVillage>().EntreeZoneJoyaux();
            }
        }
    }
}
