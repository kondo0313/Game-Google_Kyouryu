using UnityEngine;

public class CreatePlatform1 : MonoBehaviour
{
    public GameObject movingPlatformPrefab; // MovingPlatformのプレハブ
    public float creationInterval = 3.0f; // プラットフォームを生成する間隔（秒）

    private float timeSinceLastCreation;

    void Start()
    {
        // ゲーム開始時に最初のプラットフォームを生成するための設定
        timeSinceLastCreation = creationInterval;
    }

    void Update()
    {
        // 経過時間を更新
        timeSinceLastCreation += Time.deltaTime;

        // 指定された間隔が経過したらプラットフォームを生成
        if (timeSinceLastCreation >= creationInterval)
        {
            Instantiate(movingPlatformPrefab, transform.position, Quaternion.identity);
            timeSinceLastCreation = 0f; // 経過時間をリセット
        }
    }
}
