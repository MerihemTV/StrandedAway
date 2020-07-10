using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef_du_villageController : Ennemy
{

    public GameObject emplacements_tp_gameObject;
    Transform[] emplacements_tp;
    public float time;

    public GameObject explosion;
    public GameObject fireBall;
    

    int index_action;

    public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        //if ennemy mode 
        emplacements_tp = new Transform[4];
        emplacements_tp[0] = emplacements_tp_gameObject.transform.GetChild(0);
        emplacements_tp[1] = emplacements_tp_gameObject.transform.GetChild(1);
        emplacements_tp[2] = emplacements_tp_gameObject.transform.GetChild(2);
        emplacements_tp[3] = emplacements_tp_gameObject.transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            time += 1;
            StartCoroutine(ManageHealth());

            if (time % 300 == 0)
            {
                index_action = Random.Range(0, 3);
                if (index_action == 0)
                {
                    int index = Random.Range(0, 3);
                    StartCoroutine(Teleportation(index));
                }
                if (index_action == 1)
                {
                    StartCoroutine(CastLightning());
                }
                if (index_action == 2)
                {
                    StartCoroutine(CastFireBall());
                }
            }
        }

    }

    //fonctionne
    IEnumerator Teleportation(int index_emplacement)
    {
        //lancer l'animation du cast
        GetComponent<Animator>().SetTrigger("Cast_tp");
        //attendre que le perso disparaisse (fade)
        yield return new WaitForSecondsRealtime(1.12f);
        //change transform
        transform.position = emplacements_tp[index_emplacement].position;

    }

    IEnumerator CastFireBall()
    {
        //lancer l'animation
        GetComponent<Animator>().SetTrigger("Cast_spell");
        yield return new WaitForSecondsRealtime(1.15f);

        //créer vecteur direction entre chef et joueur
        Vector3 samPosition = GameObject.Find("Sam").transform.position;
        Vector3 direction = samPosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //créer le projectile
        GameObject fire_ball =
            Instantiate(fireBall, transform.position, Quaternion.identity);
        fire_ball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        fire_ball.GetComponent<ProjectileBehaviour>().direction = direction.normalized;

    }

    IEnumerator CastLightning()
    {
        //lancer l'animation
        GetComponent<Animator>().SetTrigger("Cast_spell");
        yield return new WaitForSecondsRealtime(1.15f);
        //prendre l'amplacement du joueur
        Vector3 samPosition = GameObject.Find("Sam").transform.position;
        samPosition -= new Vector3(0, 1, 0);

        //créer l'objet foudre
        Instantiate(explosion, samPosition, Quaternion.identity);
    }

    void InvokeGuards()
    {
        //rendre invincible le chef
        //lancer l'animation
        //faire pop les guardes
    }

    public void enableMove()
    {
        StartCoroutine(IEnableMove());
    }

    IEnumerator IEnableMove()
    {
        yield return new WaitForEndOfFrame();
        canMove = true;
    }

    public void tp_to_fight()
    {
        transform.position = GameObject.Find("Sam").transform.position - new Vector3(0, -4, 0);
    }
}
