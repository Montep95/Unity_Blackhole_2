using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_StarCollector : MonoBehaviour
{
    // private -> public 변경 (2022-09-29 13:41)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();

        }

        // Collector와 반대의 조건 달기
        if (collision.gameObject.tag == "star")
        {
            Debug.Log("블랙홀이 별을 먹음");

            // 중력장 내 블랙홀과 닿지 않은 것도 Destroy하는 문제
            // Destroy(GameObject.FindGameObjectWithTag("star"));
            Destroy(collision.gameObject);

            // '적 블랙홀 성장중' 로직
            GameObject.FindGameObjectWithTag("b_star").transform.localScale += new Vector3(0.02f, 0.02f, 0);
        }
    }
}