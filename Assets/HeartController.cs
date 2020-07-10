using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    public GameObject Sam;
    int hp;
    public int numOfHearts;

    public Image[] hearts;

    //public static HeartController instance;

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //        Debug.Log("plus d'une instance de hearts");
    //        return;
    //    }
    //    instance = this;
    //    DontDestroyOnLoad(this);
    //}

    public Sprite[] hearts_sprites;
    // Start is called before the first frame update
    void Start()
    {
        numOfHearts = Sam.GetComponent<SamController>().hp/4;
    }

    // Update is called once per frame
    void Update()
    {
        hp = Sam.GetComponent<SamController>().hp;
        //for (int i = 0; i < hearts.Length; i++)
        //{
        //    if (hp > numOfHearts)
        //    {
        //        Sam.GetComponent<SamController>().hp = numOfHearts;
        //    }

        //    if (i < (hp))
        //    {
        //        hearts[i].sprite = hearts_sprites[4];
        //    }
        //    else
        //    {
        //        hearts[i].sprite = hearts_sprites[0];
        //    }

        //    if (i < numOfHearts)
        //    {
        //        hearts[i].enabled = true;
        //    }
        //    else
        //    {
        //        hearts[i].enabled = false;
        //    }
        //}
        for (int i = 0; i < hearts.Length; i++)
        {
            //if (hp > numOfHearts*4)
            //{
            //    Sam.GetComponent<SamController>().hp = numOfHearts;
            //}
            if (4*(i+1) <=hp)
            {
                hearts[i].sprite = hearts_sprites[4];

            }

            else if ((4*(i+1)) -1 <= (hp))
            {
                hearts[i].sprite = hearts_sprites[3];
            }
            else if ((4*(i+1))-2 <= hp)
            {
                hearts[i].sprite = hearts_sprites[2];
            }
            else if ((4*(i+1))-3 <=hp)
            {
                hearts[i].sprite = hearts_sprites[1];
            }
            else
            {
                hearts[i].sprite = hearts_sprites[0];
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }
}
