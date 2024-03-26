using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 追加

public class Ball : MonoBehaviour
{
    // 『変数』の定義（まずは変数という単語を頭にインプットしましょう）
    // ↓これを記載する
    public float moveSpeed;

    public AudioClip coinGet;
    public AudioClip keyObj;

    public float jumpSpeed;  // ジャンプ

    public GameObject[] coinIcons;

    public GameObject key;

    private Rigidbody rb;

    private bool isJumping = false;

    private int coinCount = 0;

    private Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ballの現在位置を取得する
        pos = transform.position;

        if (pos.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }

        // HorizontalとVerticalのスペルに注意（ポイント）
        float moveH = Input.GetAxis("Horizontal"); // -1.0
        float moveV = Input.GetAxis("Vertical"); // 1.0
        Vector3 movement = new Vector3(moveH, 0, moveV); // new Vector3(-1.0, 0, 1.0)
        rb.AddForce(movement * moveSpeed); // (-1.0, 0, 1.0 * 3)=(-3.0, 0, 3.0)

        // ジャンプ
        // 空中ジャンプ禁止に改良
        // 「&&」は「A && B」AかつB・・・＞AとBの両方の条件が揃った時
        // 「==」は「左右が等しい」という意味
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.velocity = Vector3.up * jumpSpeed;

            // isJumpingという名前の箱の中身を「true」にする
            isJumping = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手に「Coin」という「Tag」がついていたならば（条件）
        if (other.CompareTag("Coin"))
        {
            // ぶつかった相手を破壊する（実行）
            Destroy(other.gameObject);

            AudioSource.PlayClipAtPoint(coinGet, transform.position);

            // コインを１枚取得するごとに「coinCount」を１ずつ増加させる
            coinCount += 1;

            coinIcons[coinCount - 1].SetActive(false);

            // 追加
            if (coinCount == 1)
            {
                key.SetActive(true);

                AudioSource.PlayClipAtPoint(keyObj, transform.position);
            }

            // もしも「coinCount」が２になったら（条件）
            if (coinCount == 2)
            {
                // GameClearシーンに遷移する
                // 遷移させるシーンは名前で特定できるので「一言一句」合致させること（ポイント）
                SceneManager.LoadScene("GameClear");
            }
        }
    }

    // ジャンプの復活
    // OnCollisionEnterのスペルに注意
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
