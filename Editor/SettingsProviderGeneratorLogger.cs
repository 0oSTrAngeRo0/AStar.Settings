using System;
using System.Text;
using UnityEngine;

namespace AStar.Settings
{
    public partial class SettingsProviderGenerator
    {
        private static StringBuilder m_LoggerBuilder;

        private static void BeginLog()
        {
            if (m_LoggerBuilder == null) m_LoggerBuilder = new StringBuilder();
            m_LoggerBuilder.Clear();
            m_LoggerBuilder.Append("Code Generated in [");
            m_LoggerBuilder.Append(M_DIRECTORY);
            m_LoggerBuilder.Append("]:\n");
        }

        private static void LogMessageForClass(Type type, string filename)
        {
            m_LoggerBuilder.Append(type.FullName);
            m_LoggerBuilder.Append("\t\t");
            m_LoggerBuilder.Append(filename);
            m_LoggerBuilder.Append("\n");
        }
        
        private static void EndLog()
        {
            Debug.Log(m_LoggerBuilder.ToString());
            m_LoggerBuilder.Clear();
        }
    }
}