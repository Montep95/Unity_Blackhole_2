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
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                Debug.Log("블랙홀이 플레이어로 다가오는 중");
                // 블랙홀이 플레이어쪽으로 움직이도록
                bs.SetTarget(transform.parent.position);
            }
        }
    }


    // OnTriggerEnter = 닿았을때 로직
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<B_Star>(out B_Star bs))
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                panel.SetActive(true); // 재시작 패널 활성화
                Time.timeScale = 0.0f; // Unity 모든 시간 Stop
                                       // gameManager.I.retry();
            }
        }
    }
}
