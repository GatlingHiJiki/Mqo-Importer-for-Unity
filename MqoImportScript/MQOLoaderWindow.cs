using UnityEngine;
using System.Collections;
using UnityEditor;


public class MQOLoaderWindow : EditorWindow {
	Object mqoFile = null;
	
	[MenuItem ("Importer/MQO Loader")]
	static void Init() {
		var window = (MQOLoaderWindow)EditorWindow.GetWindow<MQOLoaderWindow>(true, "MQOLoader");
		window.Show();
	}
	
	void OnGUI() {
		const int height = 20;
		int width = (int)position.width - 16;
		
		mqoFile = EditorGUI.ObjectField(
			new Rect(0, 0, width, height), "MQO File" ,mqoFile, typeof(Object));
		
		int buttonHeight = height * 3;
		if (mqoFile != null) {
			if (GUI.Button(new Rect(0, buttonHeight, width / 2, height), "Convert")) {
				MQOLoaderScript mqoLoader = new MQOLoaderScript(mqoFile);	
				mqoFile = null;		//read out 
			}
		} else {
			EditorGUI.LabelField(new Rect(0, buttonHeight, width, height), "Missing", "Select MQO File");
		}
	}
}

