using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject panel;

    // OnTriggerStay = 흡수되는 로직
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 만약 별과 부딪힌다면
        if(collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // 별이 플레이어쪽으로 움직이도록
            star.SetTarget(transform.parent.position);

        }

        // test - 만약 블랙홀과 부딪힌다면
        if (collision.gameObject.TryGetComponent<B_Star>(out B_Star bs))
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.5f > GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.5f > GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.y))
            {
                // 블랙홀이 플레이어쪽으로 움직이도록
                bs.SetTarget(transform.parent.position);
                Destroy(collision.gameObject);

                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.1f, 0.1f, 0);
                if (Camera.main.orthographicSize < 20.0f &&
                    (Camera.main.transform.position.x > -4.5 && Camera.main.transform.position.x < 4.5))
                {
                    Camera.main.orthographicSize += 0.5f;

                }
                /*
                // 플레이어(블랙홀) 감속 한계치 설정
                if (moveSpeed > 0.4f)
                {
                    moveSpeed -= 0.2f;
                    //pushForce -= 0.2f;
                }
                */
            }
        }
    }


    /*
    // OnTriggerEnter = 닿았을때 로직
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "b_starColl")
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.5f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.5f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                Debug.Log("블랙홀이 흡수됨");

                // Destroy(GameObject.FindGameObjectWithTag("b_star"));
                Destroy(collision.gameObject);

                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.1f, 0.1f, 0);
                if (Camera.main.orthographicSize < 20.0f &&
                    (Camera.main.transform.position.x > -4.5 && Camera.main.transform.position.x < 4.5))
                {
                    Camera.main.orthographicSize += 0.5f;

                }
                // 플레이어(블랙홀) 감속 한계치 설정
                if (moveSpeed > 0.4f)
                {
                    moveSpeed -= 0.2f;
                    //pushForce -= 0.2f;
                }
            }
        }

        else if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.5f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
            && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.5f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
        {
            panel.SetActive(true); // 재시작 패널 활성화
            Time.timeScale = 0.0f; // Unity 모든 시간 Stop
                                    // gameManager.I.retry();
        }
    }
    */
}

