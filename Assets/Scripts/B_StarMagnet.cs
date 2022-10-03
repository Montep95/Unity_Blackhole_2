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
        // 'Player'�� ū �� Magnet ���� �ȿ� ������,
        if (collision.gameObject.TryGetComponent<Player>(out Player Player))
        {
            // �÷��̾ ū �������� �����̵���
            Player.SetTarget(transform.parent.position);

            //test - error
            // RigidBody AddForce
            // rb.AddForce(force, ForceMode2D.Impulse);

            // test - ��Ȧ�� �÷��̾� �߷��庸�� ������� ����Ǵ� ����
            // Player's MagnetCollider = 0.25 == b_starColl = 1.2
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f)
                > (GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.x - 2.0f)
            && (GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f)
            > (GameObject.FindGameObjectWithTag("b_starColl").transform.localScale.y - 2.0f))
            {
                if (collision.gameObject.tag == "b_starColl")
                {
                    Player.SetTarget(transform.parent.position);

                    // �߷��� �� ��Ȧ�� ���� ���� �͵� destroy�ϴ� ����
                    Destroy(GameObject.FindGameObjectWithTag("b_star"));
                    Debug.Log("��Ȧ �ı�");
                    GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.3f, 0.3f, 0);
                }
            }
        }

        // '��' ���� ��Ȧ�� Magnet ���� �ȿ� ������,
        if (collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // ���� ���� ��Ȧ�� ����ǵ���
            star.SetTarget(transform.parent.position);

            //test
            GameObject.FindGameObjectWithTag("b_star").transform.localScale += new Vector3(0.03f, 0.03f, 0);
            Destroy(GameObject.FindGameObjectWithTag("star")); //star ����


        }

        /*
        // test - ��Ȧ�� �÷��̾� �߷��庸�� ������� ����Ǵ� ����
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
                    // �߷��� �� ��Ȧ�� ���� ���� �͵� destroy�ϴ� ����
                    Destroy(GameObject.FindGameObjectWithTag("b_star"));
                    Debug.Log("��Ȧ �ı�");
                    GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.3f, 0.3f, 0);
                }
            }
        }
        */
    }



}
