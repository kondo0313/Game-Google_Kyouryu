using UnityEngine;

public class CreatePlatform2 : MonoBehaviour
{
    public GameObject movingPlatformPrefab; // MovingPlatformのプレハブ
    public float creationInterval = 3.0f; // プラットフォームを生成する間隔（秒）
    public float creationProbability = 0.33f; // プラットフォームを生成する確率（0から1の間）

    private float timeSinceLastCreation;

    void Start()
    {
        // 初期設定
        timeSinceLastCreation = creationInterval;
    }

    void Update()
    {
        if (CreatePteranodon.isPteranodonCreated) // フラグを確認
            return; // Cubeが既に生成されていれば何もしない

        // 経過時間を更新
        timeSinceLastCreation += Time.deltaTime;

        if (timeSinceLastCreation >= creationInterval)
        {
            if (Random.value < creationProbability) // 生成の確率を判断
            {
                Instantiate(movingPlatformPrefab, transform.position, Quaternion.identity);
            }
            timeSinceLastCreation = 0f; // 経過時間をリセット
        }
    }
}
