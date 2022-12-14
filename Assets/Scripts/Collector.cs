using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{

    //test (2022-09-29 20:57)
    public GameObject Player;
    public GameObject gameManager;
    public GameObject g_field; // 중력장(가시성) 키우기
    public GameObject MagnetCollider; // 실 중력장 키우기
    //private vector3 originscale; // 중력장 그래픽 원래 크기
    //private vector3 originscale2; // 중력장 원래 크기
    public float x;
    public float y;
    public float z;

    //test
    public GameObject panel;
    public GameObject star;
    public GameObject b_star;
    public GameObject b_starCollider;
    float cameraSize;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    // test (2022-10-01 15:12)
    private Vector3 gf;
    // Star.cs 에서 type(별의 크기종류)을 가져옴
    //public int g_type = GameObject.FindGameObjectWithTag("star").GetComponent<Star>().type;

    [HideInInspector]
    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }

    private void Start()
    {
        cameraSize = Camera.main.orthographicSize;
    }



    private void Awake()
    {

    }


    /*
    // Awake(), Start()와 달리 활성화 될때마다 호출
    private void OnEnable()
    {

    }
    */

    // private -> public 변경 (2022-09-29 13:41)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }

        if (collision.gameObject.tag == "star")
        {
            Debug.Log("별이 흡수됨");

            // 중력장 내 블랙홀과 닿지 않은 것도 Destroy하는 문제
            // Destroy(GameObject.FindGameObjectWithTag("star"));
            Destroy(collision.gameObject);

            // 중력장 키우기 로직
            GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.02f, 0.02f, 0);

            // 카메라 줌 아웃 한계치 설정
            if (Camera.main.orthographicSize < 20.0f &&
                (Camera.main.transform.position.x > -4.5 && Camera.main.transform.position.x < 4.5))
            {
                Camera.main.orthographicSize += 0.5f;
            }

            // 플레이어(블랙홀) 감속 한계치 설정
            if (Player.GetComponent<Player>().moveSpeed > 0.4f)
            {
                Player.GetComponent<Player>().moveSpeed -= 0.2f;
                gameManager.GetComponent<gameManager>().pushForce -= 0.2f;
            }

            /* 별의 크기별 지정할 것 
            if (g_type == 1)
            {
                Debug.Log("큰 별을 흡수");
                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.1f, 0.1f, 0);
                Camera.main.orthographicSize += 0.7f;
            }
            if (g_type == 2)
            {
                Debug.Log("중간 별을 흡수");
                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.05f, 0.05f, 0);
                Camera.main.orthographicSize += 0.4f;
            }
            else
            {
                Debug.Log("일반 별을 흡수");
                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.02f, 0.02f, 0);
                Camera.main.orthographicSize += 0.15f;
            }
            */
        }


        // test - 블랙홀 흡수 조건
        if (collision.gameObject.tag == "b_starColl")
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                Debug.Log("블랙홀이 흡수됨");

                // Destroy(GameObject.FindGameObjectWithTag("b_star"));
                Destroy(collision.gameObject);

                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.15f, 0.15f, 0);
                if(Camera.main.orthographicSize < 20.0f && 
                    (Camera.main.transform.position.x > -4.5 && Camera.main.transform.position.x < 4.5))
                {
                    Camera.main.orthographicSize += 1.0f;

                }
                if(Player.GetComponent<Player>().moveSpeed > 0.4f)
                {
                    Player.GetComponent<Player>().moveSpeed -= 0.4f;
                    
                    // 참조오류
                    // gameManager.GetComponent<gameManager>().pushForce -= 0.2f;

                }
            }            
        }
    }
}
