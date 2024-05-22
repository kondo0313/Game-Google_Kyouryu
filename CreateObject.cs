using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject movingPlatformPrefab1; // MovingPlatformのプレハブ
    public GameObject movingPlatformPrefab2; // MovingPlatformのプレハブ
    public GameObject movingPlatformPrefab3; // 追加のMovingPlatformのプレハブ
    public float creationInterval = 4.0f; // プラットフォームを生成する間隔（秒）

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
            // 0から1の間でランダムな値を生成
            float randomValue = UnityEngine.Random.value;

            // 40%の確率でPrefab1のみを生成
            if (randomValue < 0.4f)
            {
                Instantiate(movingPlatformPrefab1, transform.position, Quaternion.identity);
            }
            // さらに40%の確率（合計80%まで）でPrefab1とPrefab2を生成
            else if (randomValue < 0.8f)
            {
                Instantiate(movingPlatformPrefab1, transform.position, Quaternion.identity);
                Vector3 positionForPrefab2 = transform.position + new Vector3(-7, 0, 0);
                Instantiate(movingPlatformPrefab2, positionForPrefab2, Quaternion.identity);
            }
            // 10%の確率でPrefab3をy軸方向に1だけずらして生成
            else if (randomValue < 0.9f)
            {
                Vector3 positionForPrefab3 = transform.position + new Vector3(0, 2, 0);
                Instantiate(movingPlatformPrefab3, positionForPrefab3, Quaternion.identity);
            }
            // 残りの10%の確率でPrefab3をy軸方向に3だけずらして生成
            else
            {
                Vector3 positionForPrefab3 = transform.position + new Vector3(0, 4, 0);
                Instantiate(movingPlatformPrefab3, positionForPrefab3, Quaternion.identity);
            }
            timeSinceLastCreation = 0f; // 経過時間をリセット
        }
    }
}
