using UnityEngine;

public class CreatePteranodon : MonoBehaviour
{
    public static bool isPteranodonCreated = false;

    public GameObject movingPlatformPrefab;
    public float creationInterval = 3.0f;
    public float creationProbability = 0.33f;

    private float timeSinceLastCreation;
    private float resetFlagAfter = 3.0f;
    private float timeSinceFlagSet;

    public float High = -0.5f;

    void Start()
    {
        timeSinceLastCreation = creationInterval;
    }

    void Update()
    {
        if (isPteranodonCreated)
        {
            timeSinceFlagSet += Time.deltaTime;

            if (timeSinceFlagSet >= resetFlagAfter)
            {
                isPteranodonCreated = false;
                timeSinceFlagSet = 0f;
            }
        }
        else
        {
            timeSinceLastCreation += Time.deltaTime;

            if (timeSinceLastCreation >= creationInterval)
            {
                if (Random.value < creationProbability)
                {
                    Vector3 position = transform.position;

                    // 50%の確率でY座標を+1
                    if (Random.value < 0.5f)
                    {
                        position.y += High;
                    }

                    Instantiate(movingPlatformPrefab, position, Quaternion.identity);
                    isPteranodonCreated = true;
                    timeSinceFlagSet = 0f;
                }
                timeSinceLastCreation = 0f;
            }
        }
    }
}
