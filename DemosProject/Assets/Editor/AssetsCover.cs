using System;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityEditor
{
    public class AssetsTools : Editor
    {
        [MenuItem("Assets/PNG/CoverToPixelSprites")]
        public static void CoverToPixelSprites()
        {
            Object[] objs = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);

            string value = EditorInputDialog.Show("Please input [Pixel Per Unit] of int type", "Pixel Per Unit", "");
            int pixelPerUnit = int.Parse(value);

            foreach (Object obj in objs)
            {
                if (obj && obj is Texture)
                {
                    string path = AssetDatabase.GetAssetPath(obj);

                    TextureImporter tex = AssetImporter.GetAtPath(path) as TextureImporter;
                    if (tex)
                    {
                        tex.textureType = TextureImporterType.Sprite;
                        tex.spritePixelsPerUnit = pixelPerUnit;
                        tex.filterMode = FilterMode.Point;
                        tex.textureCompression = TextureImporterCompression.Uncompressed;
                    }

                    AssetDatabase.ImportAsset(path);
                }
            }
        }
    }
}