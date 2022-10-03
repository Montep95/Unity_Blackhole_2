using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_StarCollector : MonoBehaviour
{
    /*
    public GameObject g_field;// 중력장(가시성) 키우기
    public GameObject MagnetCollider; // 중력장 키우기
    */

    /*test
    public GameObject panel;
    public GameObject star;
    public GameObject b_star;
    public GameObject b_starCollider;
    */

    // private -> public 변경 (2022-09-29 13:41)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();

        }

        // Collector와 반대의 조건 달기
    }
}