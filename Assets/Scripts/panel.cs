using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Button OnClick - Run
    public void retry()
    {
        gameManager.I.retry(); // gameManager의 retry()함수 호출
    }
}
