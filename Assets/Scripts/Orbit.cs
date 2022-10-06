using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed;
    Vector3 offSet; // 플레이어와 공전물체와의 거리

    // Start is called before the first frame update
    void Start()
    {
        // 공전물체에서 플레이어의 위치를 빼면 둘 사이의 거리
        offSet = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offSet; // 둘의 거리만큼 리셋
        // transform.Rotate(new Vector3(-0.2f, -0.2f, 0) * 2);
        transform.RotateAround(target.position, Vector3.back, orbitSpeed * Time.deltaTime * 5); // 회전을 하는 로직
        offSet = transform.position - target.position; // 둘의 거리만큼 이동
    }
}
