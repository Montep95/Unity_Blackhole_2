using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;

    // 중력장 속도
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;
    
    // 근접 거리
    [SerializeField] [Range(0f, 3f)] float contactDistance = 1f;

    bool follow = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        followTarget();
    }

    void followTarget()
    {

        if(Vector2.Distance(transform.position, target.position) > contactDistance && follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true; // 별의 중력장 영역 접촉면에 player가 닿으면 follow를 true로
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false; // 떨어지면 다시 false로 설정
    }
}
