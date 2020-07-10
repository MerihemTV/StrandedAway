    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : FollowingEnnemy
{
    private bool peaceful = true;
    public GameObject dialogueCanvas;
    private int damageOnCollisionTemp;

    void Start()
    {
        damageOnCollisionTemp = damageOnCollision;
        health = maxHealth;
        slider.value = CalculateHealth();
        healthBar.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        damageOnCollision = 0;
    }

    private void Update()
    {
        if (health <= 0)
        {
            SamController.instance.cursed = true;
            Debug.Log("cursed : " + SamController.instance.cursed);
        }
        StartCoroutine(ManageHealth());
        if (!peaceful)
        {
            IA();
        }

    }

    protected override void IA()
    {
        base.IA();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (peaceful)
        {
            Debug.Log("lancer dialogue ... puis petite pose");
            dialogueCanvas.SetActive(true);
        }
        if (collision.gameObject.tag == "sword" && peaceful)
        {
            Debug.Log("passage en mode combat");
            peaceful = false;
        }
        else if (collision.gameObject.tag == "sword" && !peaceful)
        {
            health -= 10;   //modifier cette valeur
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (peaceful)
        {
            dialogueCanvas.SetActive(false);
        }
    }

    public void helpHim()
    {
        dialogueCanvas.SetActive(false);
        Debug.Log("message de la lich avant le départ du joueur");
        ChefHouse.instance.HaveSeenLich = true;
    }
    public void attackHim()
    {
        damageOnCollision = damageOnCollisionTemp;
        Debug.Log("message de la lich avant le combat");
        peaceful = false;
        dialogueCanvas.SetActive(false);
    }
}
