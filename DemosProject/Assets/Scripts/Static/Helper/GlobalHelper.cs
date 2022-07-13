using UnityEngine;

public static class GlobalHelper
{
    /// <summary>
    /// 获取场景中的格子坐标
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static Vector3 GetGridPos(int x, int y, EGridPivot gridPivot = EGridPivot.LeftBottom)
    {
        if (!GameStart.GameConfig)
        {
            Debug.LogError("GameConfig is null");
            return Vector3.positiveInfinity;
        }

        //获取一个单元格大小
        int gridSize = GameStart.GameConfig.GridSize;
        float half = (float)gridSize / 2;
        Vector3 result = new Vector3(x * gridSize, y * gridSize);
        Vector3 offset = Vector3.zero;
        switch (gridPivot)
        {
            case EGridPivot.Center:
                offset = new Vector3(-half, -half);
                break;
            case EGridPivot.LeftTop:
                offset = new Vector3(0, -gridSize);
                break;
            case EGridPivot.MiddleTop:
                offset = new Vector3(-half, -gridSize);
                break;
            case EGridPivot.RightTop:
                offset = new Vector3(-gridSize, -gridSize);
                break;
            case EGridPivot.RightMiddle:
                offset = new Vector3(-gridSize, -half);
                break;
            case EGridPivot.RightBottom:
                offset = new Vector3(-gridSize, 0);
                break;
            case EGridPivot.MiddleBottom:
                offset = new Vector3(-half, 0);
                break;
            case EGridPivot.LeftMiddle:
                offset = new Vector3(0, -half);
                break;
        }

        result += offset;
        return result;
    }
}