using UnityEngine;

public static class FloatHelper
{
    public static Vector3 CoverToVector3(this float self)
    {
        return new Vector3(self, self, self);
    }
}