using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SamController : MonoBehaviour
{
    [SerializeField] int _hp;
    public int hp
    {
        get { return _hp; }
        set
        {
            if (_hp > value)
            {
                if (!invincible)
                {
                    StartCoroutine(Invulnerability());
                    if (cursed)
                    {
                        _hp = value - additionalCursedDamage;
                    }
                    else _hp = value;
                }
            }
            else
            {
                if (value > maxhp)
                {
                    _hp = maxhp;
                }
                else
                    _hp = value;
            }
            if (_hp <= 0)
            {
                SamDeath();
            }
        }
    }
    public int maxhp = 12;
    public bool canMove = true;
    public float moveSpeed = 3f;
    private float actual_speed = 0f;
    public int karma = 0;


    public bool cursed = false;
    public int additionalCursedDamage;


    public float invincibleTime = 1f;
    public bool invincible = false;
    public bool hitten = false;
    public float hitStunForce = 5f;

    public MeleeWeapon sword = null;

    private RangeWeapon rangeWeapon = null;
    private bool canShoot = true;
    Vector3 projectile_direction;
    Sprite projectile_sprite;


    public Animator animator;



    public static SamController instance;
    #region singleton


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("plus d'une instance de sam trouvé");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    #endregion



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g") && sword!=null)
        {
            animator.SetTrigger("Attack");
        }

        if (rangeWeapon != null && canShoot)
        {
            if (Input.GetKeyDown("f"))
            {
                StartCoroutine(shoot(rangeWeapon.TimeBetweenShots));
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_Animation_MoveRight") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_idle_right"))
                {
                    // On tire à droite
                    projectile_direction = new Vector3(1, 0, 0);
                    projectile_sprite = rangeWeapon.projectile.GetComponent<ProjectileBehaviour>().projectile_Sprites[0];

                }
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_Animation_Move_Up") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_idle_up"))
                {
                    // On tire en haut
                    projectile_direction = new Vector3(0, 1, 0);
                    projectile_sprite = rangeWeapon.projectile.GetComponent<ProjectileBehaviour>().projectile_Sprites[1];


                }
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_Animation_Move_Left") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_idle_left"))
                {
                    // On tire à gauche
                    projectile_direction = new Vector3(-1, 0, 0);
                    projectile_sprite = rangeWeapon.projectile.GetComponent<ProjectileBehaviour>().projectile_Sprites[2];

                }
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_Animation_Move_Down") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sam_idle_down"))
                {
                    // On itre en bas
                    projectile_direction = new Vector3(0, -1, 0);
                    projectile_sprite = rangeWeapon.projectile.GetComponent<ProjectileBehaviour>().projectile_Sprites[3];

                }
                GameObject projectile = Instantiate(rangeWeapon.projectile, transform.position + projectile_direction * 1.3f, Quaternion.identity) as GameObject;
                projectile.GetComponent<ProjectileBehaviour>().direction = projectile_direction;
                projectile.GetComponent<SpriteRenderer>().sprite = projectile_sprite;
            }
        }

        if (hitten == false)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                actual_speed = Input.GetAxisRaw("Horizontal") * moveSpeed;
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                actual_speed = Input.GetAxisRaw("Vertical") * moveSpeed;
            }
            else
            {
                actual_speed = 0;
            }

            animator.SetFloat("Speed", Mathf.Abs(actual_speed));

            //HAUT
            if (canMove)
            {
                if (Input.GetKeyDown("up") && !Input.GetKey("down") && !Input.GetKey("right") && !Input.GetKey("left"))
                {
                    animator.SetTrigger("Go_up");
                }

                if (Input.GetKey("up"))
                {
                    if (Input.GetKey("right"))
                    {
                        transform.position += new Vector3(moveSpeed * Time.fixedDeltaTime * 0.8f, moveSpeed * Time.fixedDeltaTime * 0.8f, 0);
                    }
                    else if (Input.GetKey("left"))
                    {
                        transform.position += new Vector3(-moveSpeed * Time.fixedDeltaTime * 0.8f, moveSpeed * Time.fixedDeltaTime * 0.8f, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(0, moveSpeed * Time.fixedDeltaTime, 0);
                    }
                }

                if (Input.GetKey("right") && Input.GetKeyUp("up"))
                {
                    animator.SetTrigger("Go_right");
                }

                if (Input.GetKey("left") && Input.GetKeyUp("up"))
                {
                    animator.SetTrigger("Go_left");
                }

                if (Input.GetKey("down") && Input.GetKeyUp("up"))
                {
                    animator.SetTrigger("Go_down");
                }

                //Bas
                if (Input.GetKeyDown("down") && !Input.GetKey("up") && !Input.GetKey("right") && !Input.GetKey("left"))
                {
                    animator.SetTrigger("Go_down");
                }

                if (Input.GetKey("down"))
                {
                    if (Input.GetKey("right"))
                    {
                        transform.position += new Vector3(moveSpeed * Time.fixedDeltaTime * 0.8f, -moveSpeed * Time.fixedDeltaTime * 0.8f, 0);
                    }
                    else if (Input.GetKey("left"))
                    {
                        transform.position += new Vector3(-moveSpeed * Time.fixedDeltaTime * 0.8f, -moveSpeed * Time.fixedDeltaTime * 0.8f, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(0, -moveSpeed * Time.fixedDeltaTime, 0);
                    }

                }

                if (Input.GetKey("right") && Input.GetKeyUp("down"))
                {
                    animator.SetTrigger("Go_right");
                }

                if (Input.GetKey("left") && Input.GetKeyUp("down"))
                {
                    animator.SetTrigger("Go_left");
                }

                if (Input.GetKey("up") && Input.GetKeyUp("down"))
                {
                    animator.SetTrigger("Go_up");
                }


                //Droite

                if (Input.GetKeyDown("right") && !Input.GetKey("down") && !Input.GetKey("up") && !Input.GetKey("left"))
                {
                    animator.SetTrigger("Go_right");

                }
                if (Input.GetKey("right") && !Input.GetKey("down") && !Input.GetKey("up") && !Input.GetKey("left"))
                {
                    transform.position += new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0);
                }

                if (Input.GetKey("down") && Input.GetKeyUp("right"))
                {
                    animator.SetTrigger("Go_down");
                }

                if (Input.GetKey("left") && Input.GetKeyUp("right"))
                {
                    animator.SetTrigger("Go_left");
                }

                if (Input.GetKey("up") && Input.GetKeyUp("right"))
                {
                    animator.SetTrigger("Go_up");
                }

                //GAUCHE

                if (Input.GetKeyDown("left") && !Input.GetKey("down") && !Input.GetKey("right") && !Input.GetKey("up"))
                {
                    animator.SetTrigger("Go_left");
                }
                if (Input.GetKey("left") && !Input.GetKey("down") && !Input.GetKey("right") && !Input.GetKey("up"))
                {
                    transform.position += new Vector3(-moveSpeed * Time.fixedDeltaTime, 0, 0);
                }

                if (Input.GetKey("down") && Input.GetKeyUp("left"))
                {
                    animator.SetTrigger("Go_down");
                }

                if (Input.GetKey("right") && Input.GetKeyUp("left"))
                {
                    animator.SetTrigger("Go_right");
                }

                if (Input.GetKey("up") && Input.GetKeyUp("left"))
                {
                    animator.SetTrigger("Go_up");
                }
            }
        }


    }

    public void SavePlayer()
    {
        Debug.Log("SAUVEGARDE ZEBI");
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {

        Debug.Log("CHARGEMENT ZEBI");

        PlayerData data = SaveSystem.LoadPlayer();

        karma = data.karma;
        hp = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        SceneManager.LoadScene(data.zone);
    }

    public void SamDeath()
    {
        SceneManager.LoadScene("Spaceship");
        ZoneName.zone = "Vaisseau";
        hp = maxhp;
        transform.position = new Vector3(-10f, -3f, 0f);
        Inventory.instance.items.Clear();
        Inventory.instance.onItemChangedCallBack.Invoke();


    }

    public IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSecondsRealtime(invincibleTime);
        invincible = false;
    }

    public void EquipRangeWeapon(RangeWeapon rw)
    {
        rangeWeapon = rw;
    }

    public void EquipMeleeWeapon(MeleeWeapon mw)
    {
        sword = mw;
    }

    IEnumerator shoot(float timeShoot)
    {
        canShoot = false;
        yield return new WaitForSeconds(timeShoot);
        canShoot = true;
    }

    IEnumerator HitStunClassic()
    {
        Transform sam_trans = GameObject.Find("Sam").transform;
        Vector2 direction;
        direction.x = this.transform.position.x - sam_trans.position.x;
        direction.y = this.transform.position.y - sam_trans.position.y;
        Debug.Log(direction);
        Debug.Log(hitStunForce);
        Debug.Log(direction * hitStunForce);
        hitten = true;
        this.GetComponent<Rigidbody2D>().AddForce(direction * hitStunForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        this.GetComponent<Rigidbody2D>().drag = 10000;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Rigidbody2D>().drag = 0;
        hitten = false;
    }

    public void changeSpeedTemporary(float SlowTime, float slowCoeff)
    {
        StartCoroutine(slowPlayer(SlowTime, slowCoeff));
    }

    IEnumerator slowPlayer(float SlowTime, float slowCoeff)
    {
        float tmp = moveSpeed;
        moveSpeed *= slowCoeff;
        yield return new WaitForSeconds(SlowTime);
        moveSpeed = tmp;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
