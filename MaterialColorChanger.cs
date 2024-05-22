using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    public Material targetMaterial; // 変更するマテリアル
    public Color initialColor = Color.white; // 初期色
    public Color alternateColor = Color.black; // 交代する色

    private int lastScoreMilestone = 0; // 最後に色を変更したスコアの節目
    public static int colorChangeFlag = 0; // 色の変更を示すフラグ（0か1）
    void Start()
    {
        // 初期色を設定
        targetMaterial.color = initialColor;
    }
    void Update()
    {
        // フラグの値をコンソールに出力
        //Debug.Log("Color Change Flag: " + colorChangeFlag);
        // スコアが最後の節目から1000以上増加したか確認
        if (Score.score >= lastScoreMilestone + 1000)
        {
            ToggleColorChangeFlag();
        }

        // エンターキーが押されたか確認
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    ToggleColorChangeFlag();
        //}
    }

    void ToggleColorChangeFlag()
    {
        lastScoreMilestone += 1000; // 次の節目を更新
        colorChangeFlag = 1 - colorChangeFlag; // フラグを切り替える（0⇔1）
        ChangeMaterialColor();
    }

    void ChangeMaterialColor()
    {
        // 現在の色に応じて色を切り替える
        if (colorChangeFlag == 0)
            targetMaterial.color = initialColor;
        else
            targetMaterial.color = alternateColor;
    }
}
