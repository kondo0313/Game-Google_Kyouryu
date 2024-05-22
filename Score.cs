using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
    private Color originalColor; // 元の色を保持
    private int lastColorChangeScore = 0; // 最後に色を変更したスコア
    public GameObject objectToHide; // 非表示にするオブジェクト

    void Start()
    {
        // 初期色を保存
        originalColor = scoreText.color;
         MeshRenderer renderer = objectToHide.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = false; // レンダラーを無効にする
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + score;

        // スコアが前回の色変更から1000ポイント増加した場合、テキストの色を反転
        if ((score - lastColorChangeScore) >= 1000)
        {
            scoreText.color = scoreText.color == originalColor ? 
                new Color(1f - originalColor.r, 1f - originalColor.g, 1f - originalColor.b) : // 色を反転
                originalColor; // 元の色に戻す

            lastColorChangeScore = score; // 色変更スコアを更新
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        // 他のオブジェクトがトリガーに入った際にスコアを加算
        score += 100;
    }
}
