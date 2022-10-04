using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target; // 플레이어의 위치를 담을 변수
    public float speed;

    // 카메라이동, 화면크기 제한
    public Vector2 center;
    public Vector2 size;
    float height;
    float width;
    
    void Start()
    {
        // 카메라이동, 화면크기 제한
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    // 카메라이동, 화면크기 제한
    private void OnDrawGizmos() // 변수 값을 시각적으로 보이게 하기 위한 함수
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size); // center를 중심으로 size크기의 큐브를 표시
    }

    void LateUpdate() // 플레이어가 움직인 후에 카메라가 따라가는 함수
    { // LateUpdate는 Update함수가 호출된 후에 호출됩니다.

        // transform.position = new Vector3(target.position.x, target.position.y, -10f);
        
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        // 카메라 위치는 매 프레임마다 조금씩 플레이어에게 다가가게됨
        // Time.deltaTime에 speed 변수를 선언해서 곱해줌

        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        // 카메라의 Z값을 -10f로 고정시켜줘야함
        // 이 타겟변수에 Unity에서 타겟할 대상을 끌어서 넣기

        // 카메라이동, 화면크기 제한
        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);
        float ly = size.x * 0.5f - width;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    
        //if((target.transform.localScale.x > 7) && (target.transform.localScale.y > 7))
        //{
        //    size.x += 1;
        //    size.y += 1;
        //}
    }
}
