using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 追加

public class ReturnToTitle : MonoBehaviour
{
    public int timeCount;

    void Start()
    {
        // （ポイント）設定した時間が経過すると「GoTitle」メソッドを呼び出す
        Invoke("GoTitle", timeCount);
    }

    void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
