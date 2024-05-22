using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject pauseCanvasPrefab; // ポーズキャンバスのプレハブ

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground"))
        {
            // Ground 以外に接触したらゲームをポーズ
            PauseGame();
        }
    }

    // ゲームをポーズするメソッド
    private void PauseGame()
    {
        Instantiate(pauseCanvasPrefab, Vector3.zero, Quaternion.identity); // ポーズキャンバスを生成
        Time.timeScale = 0; // ゲームの時間を停止
    }
}
