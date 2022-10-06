using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random; // Random 모호한 참조 해결

public class Star : MonoBehaviour, ICollectible
{
    // test 2022-09-29 20:38
    public Transform CollectorCollider;
    // public GameObject Player;
    // public float speed;


    // test
    public GameObject G_field;
    //public Transform Player;
    Rigidbody2D playerBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    Vector2 pullForce;

    public static event Action OnStarCollected;
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 4f;

    // 점수 UI
    int score;
    public int type; // 점수 배점
    float size;

    // star 사용 공유 (싱글톤)
    #region Singleton class: Star

    public static Star s;
    //public static gameManager Instance;


    #endregion

    void Start()
    {
        float x = Random.Range(-18.0f, 18.0f);
        float y = Random.Range(-23.0f, 23.0f);

        transform.position = new Vector3(x, y, 0);

        // 점수 UI
        type = Random.Range(1, 4);
        if(type == 1)
        {
            size = 1.0f;
            score = 3;

            
        }
        else if (type == 2)
        {
            size = 0.5f;
            score = 2;

            
        }
        else
        {
            size = 0.2f;
            score = 1;

            
        }
        transform.localScale = new Vector3(size, size, 0);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        s = this;        
    }


    // 점수 획득 구현
    public void Collect()
    {
        //Debug.Log("Star Collected");
        gameManager.I.addScore(score);
        // Destroy(gameObject); // 파괴되지 않고 자석처럼 따라다녀야함
        OnStarCollected?.Invoke();
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
        //OrbitAround();
    }

    /*
    public void OrbitAround()
    {
        transform.RotateAround(Player.transform.position, Vector3.down, speed * Time.deltaTime);
    }
    */
}
