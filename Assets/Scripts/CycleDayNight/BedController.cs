using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : Interactable
{
    // Start is called before the first frame update

    private int heureactuelle;
    private string nouvelleHeure;
    private char[] heureFinale = { '0', '0' };
    private int i;

    public override void interact()
    {
        i = 0;

        heureactuelle = int.Parse(HeureController.houres_dec.ToString() + HeureController.houres_unit.ToString());
        nouvelleHeure = (heureactuelle + 8).ToString();

        Debug.Log(nouvelleHeure);

        foreach (char c in nouvelleHeure)
        {
            if(nouvelleHeure.Length == 1)
            {
                heureFinale[0] = '0';
                heureFinale[1] = c;
            }
            else
            {
                heureFinale[i] = c;
                i++;
            }  
            
        }

        //Debug.Log(heureFinale[0]);
        //Debug.Log(heureFinale[1]);

        HeureController.houres_dec = int.Parse(heureFinale[0].ToString());
        HeureController.houres_unit = int.Parse(heureFinale[1].ToString());

        Debug.Log("Heure update !");

    }
}
