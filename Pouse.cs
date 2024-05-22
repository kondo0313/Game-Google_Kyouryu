using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理に必要
using UnityEngine.UI; // UIのTextクラスを使用するために必要

public class Pouse : MonoBehaviour
{
    public Text pauseText;

    void Start(){
        // スコアとリトライの指示をテキストに設定
        pauseText.text = "Score Result: \n" + Score.score + "\n Restart Please Enter [R]";
    }

    void Update()
    {
        // 「R」キーが押されたらリトライ
        if (Input.GetKeyDown(KeyCode.R))
        {
            RetryGame();
        }
    }

    // ゲームをリトライするメソッド
    private void RetryGame()
    {
        // ゲームの状態を初期化
        InitializeGameState();

        // 現在のシーンをリロードしてゲームをリスタート
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ゲームの状態を初期化するメソッド（必要に応じてカスタマイズ）
    private void InitializeGameState()
    {
        Score.score = 0;
        MaterialColorChanger.colorChangeFlag = 0;
        Sun.angleChanged = true;
        Time.timeScale = 1; // ゲームの時間を停止を解除


    }
}
