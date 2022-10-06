using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // test (2022-09-29 13:44)
    bool hasTarget;
    Vector3 targetPosition;
    public float moveSpeed = 4.0f;

    public GameObject g_field;// 중력장(가시성) 키우기
    public GameObject MagnetCollider; // 중력장 키우기

    //test
    public GameObject panel;
    public GameObject star;
    public GameObject b_star;
    public GameObject b_starCollider;

    // test (Add Orbit)
    public GameObject[] Orbits;
    public int HasOrbit;
    public int maxHasOrbit;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector] public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
        //transform.localScale = new Vector3(transform.localScale.x + 0.5f * 2 * Time.deltaTime,
        //                                transform.localScale.y + 0.5f * 2 * Time.deltaTime, 0);
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

    // test (2022-09-29 13:44)
    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;
        }
    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }

    void Update()
    {

    }
}

