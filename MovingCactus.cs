using UnityEngine;

public class MovingCactus : MonoBehaviour
{
    public float speed = 10.0f; // 移動速度
    public float moveTime = 5.0f; // 移動する時間（秒）

    private float timeElapsed; // 経過時間を追跡する

    void Update()
    {
        if (timeElapsed < moveTime)
        {
            // 時間が moveTime に達するまでオブジェクトを移動させる
            transform.Translate(speed * Time.deltaTime, 0, 0);
            timeElapsed += Time.deltaTime; // 経過時間を更新
        }
        else
        {
            // 指定時間経過後にオブジェクトを非表示または破壊
            Destroy(gameObject);
        }
    }
}
