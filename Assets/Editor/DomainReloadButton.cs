using UnityEditor.Compilation;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class DomainReloadButton : EditorWindow
    {
        [MenuItem("Tools/LordGames/Domain Reload Tool")]
        public static void ShowWindow()
        {
            GetWindow<DomainReloadButton>("Domain Reload");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Reload Domain"))
            {
                EditorApplication.ExecuteMenuItem("File/Save Project");
                CompilationPipeline.RequestScriptCompilation();
            }
        }
    }
}