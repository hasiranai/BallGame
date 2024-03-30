using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public Vector3 pos;
    public Transform warpTran;

    private void OnTriggerEnter(Collider other)
    {
        // （考え方）触れた瞬間にボールに新しい位置情報をセットする
        // 「0.5f」のように「小数」を使用する場合には必ず「f」を書くこと（ポイント）
        // 「f」は「float（浮動小数点）」の略
        //other.gameObject.transform.position = pos;  元の処理
        other.gameObject.transform.position = warpTran.position;
    }
}
