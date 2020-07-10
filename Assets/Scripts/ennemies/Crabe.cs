using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabe : Ennemy
{
    public float time;
    public bool droite = true;

    public bool vertical_gauche = false;
    public bool vertical_droite = false;
    public bool horizontal_haut = false;
    public bool horizontal_bas = false;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ManageHealth());
        time += 1;
        if (hitten == false && health > 0)
        {
            if (droite)
            {
                if(vertical_gauche)
                {
                    transform.position += new Vector3(0, 0.05f, 0);
                    GetComponent<Animator>().Play("Crabe_animation_vertical_gauche");
                }
                else if(vertical_droite)
                {
                    transform.position += new Vector3(0, 0.05f, 0);
                    GetComponent<Animator>().Play("Crabe_animation_vertical_droite");
                }
                else if(horizontal_haut)
                {
                    transform.position += new Vector3(0.05f, 0, 0);
                    GetComponent<Animator>().Play("Crabe_animation_horizontal_haut");
                }
                else if(horizontal_bas)
                {
                    transform.position += new Vector3(0.05f, 0, 0);
                    GetComponent<Animator>().Play("Crabe_animation_horizontal_bas");
                }
/*                if(vertical)
                {
                    transform.position += new Vector3(0, 0.05f, 0);
                    GetComponent<Animator>().Play("Crabe_animation_haut");
                }
                else
                {
                    transform.position += new Vector3(0.05f, 0, 0);
                    GetComponent<Animator>().Play("Crabe_animation_droite");
                }
                */
            }
            else
            {
                if (vertical_gauche)
                {
                    transform.position -= new Vector3(0, 0.05f, 0);
                    GetComponent<Animator>().Play("Crabe_animation_vertical_gauche");
                }
                else if (vertical_droite)
                {
                    transform.position -= new Vector3(0, 0.05f, 0);
                    GetComponent<Animator>().Play("Crabe_animation_vertical_droite");
                }
                else if (horizontal_haut)
                {
                    transform.position -= new Vector3(0.05f, 0, 0);
                    GetComponent<Animator>().Play("Crabe_animation_horizontal_haut");
                }
                else if (horizontal_bas)
                {
                    transform.position -= new Vector3(0.05f, 0, 0);
                    GetComponent<Animator>().Play("Crabe_animation_horizontal_bas");
                }
/*                if (vertical)
                {
                    transform.position -= new Vector3(0, 0.05f, 0);
                    GetComponent<Animator>().Play("Crabe_animation_bas");
                }
                else
                {
                    transform.position -= new Vector3(0.05f, 0, 0);
                    GetComponent<Animator>().Play("Crabe_animation_gauche");
                }*/
            }
        }

        if (time % 80f == 0)
        {
            droite = !droite;
        }
    }
}
