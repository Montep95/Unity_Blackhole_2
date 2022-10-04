using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{

    //test (2022-09-29 20:57)
    public GameObject Player;
    public GameObject g_field; // �߷���(���ü�) Ű���
    public GameObject MagnetCollider; // �� �߷��� Ű���
    //private vector3 originscale; // �߷��� �׷��� ���� ũ��
    //private vector3 originscale2; // �߷��� ���� ũ��
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
    // Star.cs ���� type(���� ũ������)�� ������
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



    private void awake()
    {

    }


    /*
    // Awake(), Start()�� �޸� Ȱ��ȭ �ɶ����� ȣ��
    private void OnEnable()
    {

    }
    */

    // private -> public ���� (2022-09-29 13:41)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }

        if (collision.gameObject.tag == "star")
        {
            Debug.Log("���� �����");

            // �߷��� �� ��Ȧ�� ���� ���� �͵� Destroy�ϴ� ����
            Destroy(GameObject.FindGameObjectWithTag("star"));

            GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.05f, 0.05f, 0);
            Camera.main.orthographicSize += 0.5f;
            
            /* ���� ũ�⺰ ������ �� 
            if (g_type == 1)
            {
                Debug.Log("ū ���� ���");
                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.1f, 0.1f, 0);
                Camera.main.orthographicSize += 0.7f;
            }
            if (g_type == 2)
            {
                Debug.Log("�߰� ���� ���");
                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.05f, 0.05f, 0);
                Camera.main.orthographicSize += 0.4f;
            }
            else
            {
                Debug.Log("�Ϲ� ���� ���");
                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.02f, 0.02f, 0);
                Camera.main.orthographicSize += 0.15f;
            }
            */
        }


        // test - ��Ȧ ��� ����
        if (collision.gameObject.tag == "b_starColl")
        {
            if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.x
                && GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y + 1.0f > GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
            {
                Debug.Log("��Ȧ�� �����");
                Destroy(GameObject.FindGameObjectWithTag("b_star"));
                GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.3f, 0.3f, 0);
                Camera.main.orthographicSize += 1.0f;
            }            
        }

        //// ��Ȧ�� �÷��̾��� MagnetCollider ���� �ȿ� ������,
        //if (collision.gameObject.TryGetComponent<B_Star>(out B_Star bs))
        //{
        //    if (collision.gameObject.tag == "MagnetCollider")
        //    {
        //        if ((Player.transform.localScale.x + 3.0f > bs.transform.localScale.x) && (Player.transform.localScale.y + 3.0f > bs.transform.localScale.y))
        //        {
        //            Debug.Log("��Ȧ ���ǹ� ����");
        //            bs.SetTarget(transform.parent.position);

        //            // �߷��� �� ��Ȧ�� ���� ���� �͵� destroy�ϴ� ����
        //            Destroy(GameObject.FindGameObjectWithTag("b_star"));
        //            Debug.Log("��Ȧ �ı�");
        //            GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale += new Vector3(0.3f, 0.3f, 0);
        //        }
        //    }
        //}

        /*
        // test - ��Ȧ�� �÷��̾� �߷��庸�� ������� ����Ǵ� ����
        if ((GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.x)
            > (GameObject.FindGameObjectWithTag("b_star").transform.localScale.x)
        && (GameObject.FindGameObjectWithTag("MagnetCollider").transform.localScale.y)
        > (GameObject.FindGameObjectWithTag("b_star").transform.localScale.y))
        {
            if(collision.gameObject.TryGetComponent<B_Star>(out B_Star b_star))
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

        //if (collision.gameObject.tag == "b_starColl")
        //{            
        //    panel.SetActive(true); // ����� �г� Ȱ��ȭ
        //    Time.timeScale = 0.0f; // Unity ��� �ð� Stop
        //    // gameManager.I.retry();            
        //}
    }
}
