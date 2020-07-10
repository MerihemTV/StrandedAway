using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    public float destroyTime = 3f;
    public float speed;
    public Vector3 direction;
    public int projectileDamage;
    public Sprite[] projectile_Sprites;
    public float hitStunForce=10f;
    public float slowCoeff = 1;
    public bool canSlow = false;
    public float SlowTime = 0;
    private float cheatTimer = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds(destroyTime));
    }

    // Update is called once per frame
    void Update()
    {
        cheatTimer -= Time.deltaTime;
        transform.position += direction.normalized * Time.deltaTime * speed;
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && cheatTimer<=0)
        {
            collision.GetComponent<Ennemy>().health -= projectileDamage;
            Destroy(gameObject);
        }
        else if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<SamController>().hp -= projectileDamage;
            if (canSlow)
            {
                collision.GetComponent<SamController>().changeSpeedTemporary(SlowTime,slowCoeff);
            }
            if (gameObject.name!="Thunder(Clone)")
            {
                Destroy(gameObject);
            }
        }
    }


        IEnumerator HitStunProjectileEnnemy(Collider2D collision)
    {
        GameObject ennemy = collision.gameObject;
        Transform trans = this.transform;
        Vector2 direction;
        direction.x = ennemy.transform.position.x - trans.position.x;
        direction.y = ennemy.transform.position.y - trans.position.y;
        Debug.Log(direction);
        Debug.Log(hitStunForce);
        Debug.Log(direction * hitStunForce);
        ennemy.GetComponent<Ennemy>().hitten = true;
        ennemy.GetComponent<Rigidbody2D>().AddForce(direction * hitStunForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        ennemy.GetComponent<Rigidbody2D>().drag = 10000;
        Debug.Log(ennemy.GetComponent<Rigidbody2D>().drag);
        yield return new WaitForSeconds(0.1f);
        ennemy.GetComponent<Rigidbody2D>().drag = 0;
        ennemy.GetComponent<Ennemy>().hitten = false;
    }

    IEnumerator HitStunProjectilePlayer(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        Transform trans = this.transform;
        Vector2 direction;
        direction.x = player.transform.position.x - trans.position.x;
        direction.y = player.transform.position.y - trans.position.y;
        Debug.Log(direction);
        Debug.Log(hitStunForce);
        Debug.Log(direction * hitStunForce);
        player.GetComponent<Ennemy>().hitten = true;
        player.GetComponent<Rigidbody2D>().AddForce(direction * hitStunForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        player.GetComponent<Rigidbody2D>().drag = 10000;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<Rigidbody2D>().drag = 0;
        player.GetComponent<Ennemy>().hitten = false;
    }
}
