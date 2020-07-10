
using System.Collections;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject interactionTouchSprite;
    public float offSetY;
    public Vector3 scaleInteractionTouch;
    protected GameObject instanciatedSprite;

    public abstract void interact();

    public void Start()
    {
        instanciatedSprite = Instantiate(interactionTouchSprite, transform);
        instanciatedSprite.transform.position = transform.position;
        instanciatedSprite.transform.localScale = scaleInteractionTouch;
        instanciatedSprite.transform.Translate(new Vector3(0, offSetY, 0));
        instanciatedSprite.GetComponent<SpriteRenderer>().sortingOrder = 4;
        instanciatedSprite.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            instanciatedSprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            instanciatedSprite.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            interact();
        }
    }

}
