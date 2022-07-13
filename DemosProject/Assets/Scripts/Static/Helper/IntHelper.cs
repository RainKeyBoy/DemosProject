using UnityEngine;

public static class IntHelper
{
    public static Vector3 CoverToVector3(this int self)
    {
        return new Vector3(self, self, self);
    }
}