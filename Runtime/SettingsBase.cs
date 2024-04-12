using System;
using System.IO;
using UnityEngine;

namespace AStar.Settings
{
    public abstract class SettingsBase<T> : ScriptableObject where T : SettingsBase<T>
    {
        private static T m_Instance;

        public static T Instance
        {
            get
            {
                if (m_Instance != null) return m_Instance;
                LoadOrCreate();
                return m_Instance;
            }
        }

        public static void LoadOrCreate()
        {
            string path = GetFilePathStatic();
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                T settings = CreateInstance<T>();
                JsonUtility.FromJsonOverwrite(data, settings);
                m_Instance = settings;
            }
            else
            {
                m_Instance = CreateInstance<T>();
                m_Instance.SaveCurrentSettings();
            }
        }

        public void SaveCurrentSettings()
        {
            string root = GetDirectoryPath();
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
            
            string path = GetFilePathStatic();
            string data = JsonUtility.ToJson(m_Instance, true);
            // Debug.Log(data);
            File.WriteAllText(path, data);
        }

        public string GetFilePath() => GetFilePathStatic();
        
        public static string GetFilePathStatic()
        {
            string root = GetDirectoryPath();
            string path = Path.Combine(root, $"{typeof(T).Name}.json");
            return path;
        }

        private static string GetDirectoryPath() => Application.streamingAssetsPath;
    }
}