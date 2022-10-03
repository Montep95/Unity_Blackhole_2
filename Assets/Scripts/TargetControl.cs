using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    float moveX, moveY;
    [SerializeField] [Range(3f, 10f)] float moveSpeed = 5f;

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x * moveX, transform.position.y * moveY);
    }
}
