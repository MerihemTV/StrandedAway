using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ArenaSpikes : MonoBehaviour
{
    public int damageOnCollision = 1;
    public float hitStunForceSam = 17f;
    public GameObject arenaCenter;
    public GameObject tilemapGameObject;
    Tilemap tilemap;

    void Start()
    {
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (tilemap != null && collision.gameObject.tag == "Player")
        {
            SamController.instance.hp -= damageOnCollision;
            StartCoroutine(HitStunEnnemy(collision));
        }
    }

    IEnumerator HitStunEnnemy(Collision2D collision)
    {
        GameObject sam = GameObject.Find("Sam");
        Vector2 direction;
        direction = arenaCenter.transform.position - sam.transform.position;
        sam.GetComponent<SamController>().hitten = true;
        sam.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        sam.GetComponent<Rigidbody2D>().AddForce(direction * hitStunForceSam, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        sam.GetComponent<Rigidbody2D>().drag = 10000;
        yield return new WaitForSeconds(0.1f);
        sam.GetComponent<Rigidbody2D>().drag = 0;
        sam.GetComponent<SamController>().hitten = false;
    }
}
