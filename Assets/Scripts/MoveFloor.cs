using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private Vector3 pos;
    private int num = 1;
    public float speed;

    void Update()
    {
        // 現在位置の取得
        pos = transform.position;

        // （テクニック）
        // numの数字が「１」の時は「右方向」に移動
        // numの数字が「-１」の時は「左方向」に移動
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * num);

        if (pos.x > 15)
        {
            num = -1;
        }
        if (pos.x < 6.5f)
        {
            num = 1;
        }
    }
}
