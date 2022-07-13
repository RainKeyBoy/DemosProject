using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig", order = 0)]
public class GameConfig : ScriptableObject
{
    /// <summary>
    /// 像素粒度
    /// </summary>
    public int AssetsPixelsPerUnit = 100;

    /// <summary>
    /// 格子数量，像素单位 
    /// </summary>
    public int GridSize = 10;
}