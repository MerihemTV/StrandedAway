using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{
    [SerializeField] float _health;
    public float health
    {
        get { return _health; }
        set
        {
            if (_health > value && !invincible)
            {
                StartCoroutine(Invulnerability());
                StartCoroutine(HitStunClassic());
                _health = value;
            }
            else if (_health < value)
            {
                _health = value;
            }
        }
    }
    protected bool invincible = false;
    protected float invincibleTime = 0.7f;
    public float maxHealth;
    public Slider slider;
    public GameObject healthBar;
    public int damageOnCollision = 10;
    protected Transform target;
    public Animator animator;
    public float hitStunForceSelf = 9f;
    public float hitStunForceSam = 17f;
    public bool hitten = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        healthBar.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    //toujours appeller cette fonction dans le update des classe héritant de Ennemy
    protected IEnumerator ManageHealth()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBar.SetActive(true);
        }

        if (health <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");

            yield return new WaitForSeconds(0.8f);
            gameObject.SetActive(false);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    protected float CalculateHealth()
    {
        return health / maxHealth;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == "sword")
            {
                health -= SamController.instance.sword.DamageOnHit;
                StartCoroutine(Invulnerability());
                //Start animation invulnerability;
                StartCoroutine(HitStunClassic());
            }
        }
        
    }
    
    public void startInvulnerability()
    {
        StartCoroutine(Invulnerability());
    }

    public IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSecondsRealtime(invincibleTime);
        invincible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (SamController.instance.hp - damageOnCollision != 0)
            {
                StartCoroutine(HitStunEnnemy());
            }
            SamController.instance.hp = SamController.instance.hp - damageOnCollision;
        }
    }

    protected void SpriteAnimation()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            animator.SetFloat("vertical_move", direction.y);
            animator.SetFloat("horizontal_move", 0);
        }
        else
        {
            animator.SetFloat("horizontal_move", direction.x);
            animator.SetFloat("vertical_move", 0);
        }
    }

    //a appeler chaque fois qu'un ennemi subit un coup
    IEnumerator HitStunClassic()
    {
        Transform sam_trans = GameObject.Find("Sam").transform;
        Vector2 direction;
        direction.x= transform.position.x - sam_trans.position.x;
        direction.y = transform.position.y - sam_trans.position.y;
        hitten = true;
        GetComponent<Rigidbody2D>().AddForce(direction*hitStunForceSelf, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody2D>().drag = 10000;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().drag = 0;
        hitten = false;
    }


    IEnumerator HitStunEnnemy()
    {
        GameObject sam = GameObject.Find("Sam");
        Vector2 direction;
        direction.x = sam.transform.position.x - this.transform.position.x;
        direction.y = sam.transform.position.y - this.transform.position.y;
        sam.GetComponent<SamController>().hitten = true;
        sam.GetComponent<Rigidbody2D>().AddForce(direction * hitStunForceSam, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        sam.GetComponent<Rigidbody2D>().drag = 10000;
        yield return new WaitForSeconds(0.1f);
        sam.GetComponent<Rigidbody2D>().drag = 0;
        sam.GetComponent<SamController>().hitten = false;
    }

}
