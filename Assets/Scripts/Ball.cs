using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 『変数』の定義（まずは変数という単語を頭にインプットしましょう）
    // ↓これを記載する
    public float moveSpeed;

    public AudioClip coinGet;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // HorizontalとVerticalのスペルに注意（ポイント）
        float moveH = Input.GetAxis("Horizontal"); // -1.0
        float moveV = Input.GetAxis("Vertical"); // 1.0
        Vector3 movement = new Vector3(moveH, 0, moveV); // new Vector3(-1.0, 0, 1.0)
        rb.AddForce(movement * moveSpeed); // (-1.0, 0, 1.0 * 3)=(-3.0, 0, 3.0)
    }

    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手に「Coin」という「Tag」がついていたならば（条件）
        if (other.CompareTag("Coin"))
        {
            // ぶつかった相手を破壊する（実行）
            Destroy(other.gameObject);

            AudioSource.PlayClipAtPoint(coinGet, transform.position);
        }
    }
}
