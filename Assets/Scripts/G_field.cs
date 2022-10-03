using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_field : MonoBehaviour
{
    #region Singleton class: G_field

    // test
    public static G_field G;
    //public static gameManager Instance;

    // test (2022-09-29 14:33)
    public GameObject Player;

    #endregion

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector]
    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }

    private void Awake()
    {
        G = this; //test

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
        //transform.localScale = new Vector3(transform.localScale.x + 0.5f * 2 * Time.deltaTime,
        //                                    transform.localScale.y + 0.5f * 2 * Time.deltaTime, 0);
    }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        /*
        if (gameObject.tag == "star")
        {
            
            // test (2022-09-29 20:30)
            transform.localScale = new Vector3(transform.localScale.x + 0.15f * 1 * Time.deltaTime,
                                                transform.localScale.y + 0.15f * 1 * Time.deltaTime, 0);
        }
        */

    }
}

