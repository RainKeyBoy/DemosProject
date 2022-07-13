using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameStart : MonoBehaviour
{
    /// <summary>
    /// 游戏配置
    /// </summary>
    public static GameConfig GameConfig;

    /// <summary>
    /// 世界的父物体
    /// </summary>
    public Transform WorldParent;

    /// <summary>
    /// 2D完美像素的脚本
    /// </summary>
    public PixelPerfectCamera PixelPerfectCamera;

    /// <summary>
    /// 主摄像机
    /// </summary>
    public Camera MainCamera;

    private void Awake()
    {
        //加载游戏配置
        if (!GameConfig)
        {
            GameConfig = Resources.Load<GameConfig>("GameConfig");
        }

        if (!GameConfig)
        {
            Debug.LogError("GameConfig load failed!!!");
            return;
        }

        //获取2D完美像素的尺寸
        int assetsPixelPerUnit = GameConfig.AssetsPixelsPerUnit;
        int gridSize = GameConfig.GridSize;

        if (PixelPerfectCamera)
        {
            PixelPerfectCamera.assetsPPU = assetsPixelPerUnit;
        }
        else
        {
            Debug.LogError("PixelPerfectCamera is null!!!");
        }

        if (WorldParent)
        {
            float offsetPos = (float)gridSize / 2 / assetsPixelPerUnit;
            float scale = (float)1 / assetsPixelPerUnit;
            WorldParent.position = new Vector3(offsetPos, offsetPos, 0);
            WorldParent.rotation = quaternion.identity;
            WorldParent.localScale = scale.CoverToVector3();
        }
        else
        {
            Debug.LogError("WorldParent is null!!!");
        }
    }
}