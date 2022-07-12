using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using UnityEditor.Experimental;
using UnityEngine;

namespace UnityEditor
{
    public class AssetsRename : Editor
    {
        /// <summary>
        /// Rename all selected objs
        /// </summary>
        [MenuItem("Assets/RRename")]
        public static void RenameAssets()
        {
            //Find all selected objs
            Object[] objs = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

            //Sort objs by name
            Dictionary<string, Object> objDict = new Dictionary<string, Object>();
            foreach (var obj in objs)
            {
                objDict.Add(obj.name, obj);
            }

            List<string> objKeys = new List<string>(objDict.Keys);
            objKeys.Sort();

            List<Object> objList = new List<Object>();
            foreach (string objName in objKeys)
            {
                objList.Add(objDict[objName]);
            }


            //Input newe prefix name
            string newNamePrefix = EditorInputDialog.Show("Please intput new name for assets", "Name", "");

            //Rename
            for (int i = 0; i < objList.Count; i++)
            {
                Object obj = objList[i];
                string path = AssetDatabase.GetAssetPath(obj);
                if (path != string.Empty)
                {
                    string newName = string.Empty;
                    if (objList.Count <= 1)
                    {
                        newName = newNamePrefix;
                    }
                    else
                    {
                        newName = string.Format("{0}_{1}", newNamePrefix, i.ToString());
                    }

                    AssetDatabase.RenameAsset(path, newName);
                }
            }
        }
    }
}