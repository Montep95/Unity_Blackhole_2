using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject panel;

    // OnTriggerStay = ����Ǵ� ����
    private void OnTriggerStay2D(Collider2D collision)
    {
        // ���� ���� �ε����ٸ�
        if(collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // ���� �÷��̾������� �����̵���
            star.SetTarget(transform.parent.position);

        }

        // test - ���� ��Ȧ�� �ε����ٸ�
        if (collision.gameObject.TryGetComponent<B_Star>(out B_Star bs))
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                Debug.Log("��Ȧ�� �÷��̾�� �ٰ����� ��");
                // ��Ȧ�� �÷��̾������� �����̵���
                bs.SetTarget(transform.parent.position);
            }
        }
    }


    // OnTriggerEnter = ������� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<B_Star>(out B_Star bs))
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f < GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                panel.SetActive(true); // ����� �г� Ȱ��ȭ
                Time.timeScale = 0.0f; // Unity ��� �ð� Stop
                                       // gameManager.I.retry();
            }
        }
    }
}
