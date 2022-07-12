using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.U2D;

public class GameStart : MonoBehaviour
{
    /// <summary>
    /// 每一个格子的大小
    /// </summary>
    public int GridSize = 10;
    
    /// <summary>
    /// 2D完美像素的脚本
    /// </summary>
    public PixelPerfectCamera PixelPerfectCamera;

    /// <summary>
    /// 世界的父物体
    /// </summary>
    public Transform WorldParent;

    /// <summary>
    /// 主摄像机
    /// </summary>
    public Camera MainCamera;

    private void Awake()
    {
        //获取2D完美像素的尺寸
        if (PixelPerfectCamera &&
            WorldParent)
        {
            int assetsPixelsPerUnit = PixelPerfectCamera.assetsPPU;
            float posOffset = (float)GridSize / 2 / assetsPixelsPerUnit;
            float scaOffset = (float)1 / assetsPixelsPerUnit;
            WorldParent.position = new Vector3(posOffset, posOffset, 0);
            WorldParent.rotation = Quaternion.identity;
            WorldParent.localScale = new Vector3(scaOffset, scaOffset, scaOffset);
        }
    }
}