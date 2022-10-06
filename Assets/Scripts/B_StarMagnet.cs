using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_StarMagnet : MonoBehaviour
{
    public GameObject b_star;
    public GameObject panel;
    public GameObject gameManager;

    //test
    [HideInInspector] public Rigidbody2D rb;
    Vector2 force;

    // OnTriggerStay = 흡수되는 로직
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 만약 별과 부딪힌다면
        if (collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // 별이 플레이어쪽으로 움직이도록
            star.SetTarget(transform.parent.position);

        }

        // test - 만약 블랙홀과 부딪힌다면
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.5f < GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.5f < GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.y))
            {
                Debug.Log("플레이어가 블랙홀에 흡수되는 중");
                
                player.SetTarget(transform.parent.position);

                // test - 플레이어가 흡수될때 마우스 클릭이 발생하면 타겟을 해제하는 로직 
                // (2022-10-05 22:51) - XXX
                if (Input.GetMouseButtonDown(0))
                {
                    b_star.GetComponent<B_Star>().hasTarget = false;
                }
            }
        }
    }


    /*
    // OnTriggerEnter = 닿았을때 로직
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.5f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.5f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                panel.SetActive(true); // 재시작 패널 활성화
                Time.timeScale = 0.0f; // Unity 모든 시간 Stop
                                       // gameManager.I.retry();
            }
        }
    }
    */
    

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // '별' 들이 블랙홀의 Magnet 범위 안에 있으면,
        if (collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // 작은 별이 블랙홀에 흡수되도록
            star.SetTarget(transform.parent.position);

            //test
            GameObject.FindGameObjectWithTag("b_star").transform.localScale += new Vector3(0.03f, 0.03f, 0);
            Destroy(GameObject.FindGameObjectWithTag("star")); //star 제거


        }
    }
    */
}
