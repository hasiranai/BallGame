using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   // 追加

public class GameStart : MonoBehaviour
{
    // 先頭に必ず「public」をつけること（重要）
    public void OnStartButtonCilcked()
    {
        SceneManager.LoadScene("Main");
    }
}
