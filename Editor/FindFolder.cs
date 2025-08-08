using UnityEditor;
using UnityEngine;

namespace OneM.LocalizationSystem.Editor
{
    public static class FindFolder
    {
        [MenuItem("OneM/Find/Localization Folder")]
        private static void Find() => Find("Assets/1M Game/Settings/Localization/Tables");

        public static void Find(string path)
        {
            var folder = AssetDatabase.LoadAssetAtPath<Object>(path);
            if (folder == null) return;

            Selection.activeObject = folder;
            EditorGUIUtility.PingObject(folder);
        }
    }
}