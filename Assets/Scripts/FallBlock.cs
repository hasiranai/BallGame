using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float interval = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // （ポイント）Invoke（"呼び出すメソッド名", 呼び出すまでの時間）
            // Fallという名前のメソッドを２秒後に呼び出す
            Invoke("Fall", interval);
        }
    }

    void Fall()
    {
        // （ポイント）isKinematicを無効化する
        rb.isKinematic = false;
    }
}
