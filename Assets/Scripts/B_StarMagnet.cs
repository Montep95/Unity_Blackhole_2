using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_StarMagnet : MonoBehaviour
{
    public GameObject b_star;
    
    //test
    [HideInInspector] public Rigidbody2D rb;
    Vector2 force;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 'Player'가 큰 별 Magnet 범위 안에 있으면,
        if (collision.gameObject.TryGetComponent<Player>(out Player Player))
        {
            // 플레이어가 큰 별쪽으로 움직이도록
            Player.SetTarget(transform.parent.position);

            //test - error
            // RigidBody AddForce
            // rb.AddForce(force, ForceMode2D.Impulse);

            // test - 블랙홀이 플레이어 중력장보다 작을경우 흡수되는 로직
            // Player's MagnetCollider = 0.25 == b_starColl = 1.2
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f)
                > (GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.x - 2.0f)
            && (GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f)
            > (GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.y - 2.0f))
            {
                if (collision.gameObject.tag == "b_starColl")
                {
                    Player.SetTarget(transform.parent.position);

                    // 중력장 내 블랙홀과 닿지 않은 것도 destroy하는 문제
                    Destroy(GameObject.FindGameObjectWithTag("b_star"));
                    Debug.Log("블랙홀 파괴");
                    GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.3f, 0.3f, 0);
                }
            }
        }

        // '별' 들이 블랙홀의 Magnet 범위 안에 있으면,
        if (collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // 작은 별이 블랙홀에 흡수되도록
            star.SetTarget(transform.parent.position);

            //test
            GameObject.FindGameObjectWithTag("b_star").transform.localScale += new Vector3(0.03f, 0.03f, 0);
            Destroy(GameObject.FindGameObjectWithTag("star")); //star 제거


        }

        /*
        // test - 블랙홀이 플레이어 중력장보다 작을경우 흡수되는 로직
        if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x)
            > (GameObject.FindGameObjectWithTag("b_star").transform.localScale.x)
        && (GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y)
        > (GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
        {
            if (collision.gameObject.TryGetComponent<B_Star>(out B_Star b_star))
            {
                if (collision.gameObject.tag == "b_star")
                {
                    b_star.SetTarget(transform.parent.position);
                    // 중력장 내 블랙홀과 닿지 않은 것도 destroy하는 문제
                    Destroy(GameObject.FindGameObjectWithTag("b_star"));
                    Debug.Log("블랙홀 파괴");
                    GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.3f, 0.3f, 0);
                }
            }
        }
        */
    }



}
