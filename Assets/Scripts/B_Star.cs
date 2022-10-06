using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random; // Random 모호한 참조 해결

public class B_Star : MonoBehaviour
{
    public GameObject star;

    //test
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector]
    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }
    // test
    public Transform b_star;
    Rigidbody2D b_starBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    // Vector2 pullForce;

    //Not used
    //public static event Action OnStarCollected;
    
    Rigidbody2D rb;

    public bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 0.5f;

    // 크기 지정
    public int type; // 크기 유형
    float size;

    // star 사용 공유 (싱글톤)
    #region Singleton class: B_Star

    public static B_Star bs;
    //public static gameManager Instance;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // test - 별 중력장
        b_starBody = b_star.GetComponent<Rigidbody2D>();
        //

        float x = Random.Range(-31.0f, 31.0f);
        float y = Random.Range(13.0f, 47.0f);

        transform.position = new Vector3(x, y, 0);

        // 점수 UI
        type = Random.Range(1, 4);
        if (type == 1)
        {
            size = 0.5f;
        }
        else if (type == 2)
        {
            size = 1.5f;
        }
        else
        {
            size = 3.5f;
        }
        transform.localScale = new Vector3(size, size, 0);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bs = this;
    }

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

    public void Update()
    {

    }
}
