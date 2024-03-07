using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 『変数』の定義（まずは変数という単語を頭にインプットしましょう）
    // ↓これを記載する
    public float moveSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // HorizontalとVerticalのスペルに注意（ポイント）
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveH, 0, moveV);
        rb.AddForce(movement * moveSpeed);
    }
}
