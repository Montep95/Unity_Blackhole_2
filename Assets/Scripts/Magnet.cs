using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 만약 별과 부딪힌다면
        if(collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // 별이 플레이어쪽으로 움직이도록
            star.SetTarget(transform.parent.position);

        }
    }
}
