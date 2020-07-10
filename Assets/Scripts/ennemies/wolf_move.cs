using UnityEngine;

public class wolf_move : Ennemy
{
    // Start is called before the first frame update

    public float time;
    public bool droite = true;

   /*void Start()
    {
        droite = true;
    }*/

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ManageHealth());
        time += 1;
        if (hitten == false)
        {
            if (droite)
            {
                transform.position += new Vector3(0.05f, 0, 0);
                GetComponent<Animator>().Play("loup_droite");
            }
            else
            {
                transform.position -= new Vector3(0.05f, 0, 0);
                GetComponent<Animator>().Play("loup_gauche");
            }
        }

        if(time % 50f == 0)
        {
            droite = !droite;
        }
    }

}
