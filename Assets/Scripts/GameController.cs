using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                        // 追加
using UnityEngine.SceneManagement;  // 追加

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timeLabel;
    public int timeCount;

    void Start()
    {
        timeLabel.text = "Time:" + timeCount;

        StartCoroutine(Timer());
    }

    // （テクニック）コルーチン
    private IEnumerator Timer()
    {
        // （ポイント）処理を繰り返す
        while (true)
        {
            // （ポイント）処理を一定時間だけ中断させる
            yield return new WaitForSeconds(1);

            timeCount -= 1;
            timeLabel.text = "Time:" + timeCount;

            if (timeCount < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
