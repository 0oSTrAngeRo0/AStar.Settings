using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace AStar.Settings
{
    public abstract class SettingsProviderBase<TProvider, TSettings> : SettingsProvider
        where TProvider : SettingsProviderBase<TProvider, TSettings>, new()
        where TSettings : SettingsBase<TSettings>, new()
    {
        private SerializedObject m_SerializedObject;

        protected abstract TSettings GetInstance();

        public SettingsProviderBase() : base($"Project/{typeof(TSettings).Name}", SettingsScope.Project, null)
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            m_SerializedObject = new SerializedObject(GetInstance());
        }

        public override void OnGUI(string searchContext)
        {
            Editor inspector = Editor.CreateEditor(GetInstance());
            inspector.OnInspectorGUI();
            if (GUILayout.Button("Select Settings"))
            {
                string path = GetInstance().GetFilePath().Replace(Application.dataPath, "Assets");
                Object asset = AssetDatabase.LoadMainAssetAtPath(path);
                EditorGUIUtility.PingObject(asset);
            }

            if (GUILayout.Button("Save Settings"))
                GetInstance().SaveCurrentSettings();
            m_SerializedObject.ApplyModifiedProperties();
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            if (m_SerializedObject != null)
                m_SerializedObject.Dispose();
            GetInstance().SaveCurrentSettings();
        }

        protected static SettingsProvider CreateProviderInternal()
        {
            TProvider provider = new TProvider();
            // provider.label = $"Project/{typeof(TSettings).Name}";
            SerializedObject serializedObject = new SerializedObject(provider.GetInstance());
            IEnumerable<string> keywords = GetSearchKeywordsFromSerializedObject(serializedObject);
            provider.keywords = provider.keywords.Union(keywords);
            serializedObject.Dispose();
            return provider;
        }
    }
}