using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 5f; // ジャンプの力

    private bool isJumping = false; // ジャンプ中かどうか
    private bool isCrouching = false; // しゃがみ中かどうか
    public AudioClip jumpSound; // ジャンプ時の音
    private AudioSource audioSource; // オーディオソース
    public GameObject pauseCanvasPrefab; // ポーズキャンバスのプレハブ
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // AudioSource コンポーネントの取得
    }

    void Update()
    {
        // ↑キーでジャンプ（長押し対応）
        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded())
        {
            Jump();
        }

        // ↓キーでしゃがむ（長押し対応）
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Crouch();
        }
        else
        {
            StopCrouching();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        else
        {
            // Ground 以外に接触したらゲームをポーズ
            PauseGame();
        }
    }

    // ジャンプ処理
    private void Jump()
    {
        if (!isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            audioSource.PlayOneShot(jumpSound);
        }
    }

    // しゃがむ処理
    private void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
        }
    }

    // しゃがむのをやめる処理
    private void StopCrouching()
    {
        if (isCrouching)
        {
            isCrouching = false;
        }
    }

    // 地面に接地しているかを判定するメソッド
    private bool IsGrounded()
    {
        float distanceToGround = 1.82f;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, distanceToGround))
        {
            return hit.collider.CompareTag("Ground");
        }

        return false;
    }

    // ゲームをポーズするメソッド
    private void PauseGame()
    {
        Instantiate(pauseCanvasPrefab, Vector3.zero, Quaternion.identity); // ポーズキャンバスを生成
        Time.timeScale = 0; // ゲームの時間を停止
    }
}
