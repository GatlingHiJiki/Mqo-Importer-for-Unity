using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class MQOLoaderScript {

	//--------------------------------------------------------------------------------
	// ファイル読み込み
	
	GameObject Root_obj;
	public Object mqo;
	
	StreamReader LoadFile(Object obj, string path) {
		FileStream f = new FileStream(path, FileMode.Open, FileAccess.Read);
		StreamReader r = new StreamReader(f);
		return r;
	}
		
	// MQOファイル読み込み
	void LoadMQOFile() {
		string path = AssetDatabase.GetAssetPath(this.mqo);
		
		StreamReader stream = this.LoadFile(this.mqo, path);
		
		Root.MQO.MQOFormat format = Root.MQO.MQOLoader.Load(stream, Root_obj, path);
		BurnUnityFormatForMQO(format);
		stream.Close();
	}
		
	// Use this for initialization
	public MQOLoaderScript (Object mqoFile) {
		this.mqo = mqoFile;
		
		if (this.mqo != null) {
			LoadMQOFile();
		}
		Debug.Log("Comp");
		this.mqo = null;
	}
	//*
	//--------------------------------------------------------------------------------
	// MQOファイル出力
	
	Mesh[] meshes;
	Material[] materials;
	
	void EndOfScript(Root.MQO.MQOFormat format)
	{
		AssetDatabase.Refresh();
		
		this.meshes = null;
		this.materials = null;
		this.mqo = null;
	}
	
	// MQOファイルをUnity形式に変換
	void BurnUnityFormatForMQO(Root.MQO.MQOFormat format) {
		Root_obj = new GameObject(format.name);
		format.caller = Root_obj;
		
		Root.MQO.MQOConverter conv = new Root.MQO.MQOConverter();
		
		this.meshes = conv.CreateMeshes(format);
		Debug.Log("Maked meshes");
		
		this.materials = conv.CreateMaterials(format);
		Debug.Log("Maked materials");
		
		//Object prefab = UnityEditor.PrefabUtility.CreateEmptyPrefab(format.folder + "/" + format.name + ".prefab");
		GameObject[] child = new GameObject[format.object_list.obj_count];
		for(int obj_id = 0;obj_id < format.object_list.obj_count; obj_id++)
		{
			child[obj_id] = new GameObject(format.object_list.obj[obj_id].obj_name);
			conv.ReplaceObject(format , obj_id ,child[obj_id] ,meshes[obj_id] ,materials);
			child[obj_id].transform.parent = Root_obj.transform;
		}
		Debug.Log("Comp Prefab");
		
		/*Object[] prefab = new Object[format.object_list.obj_count];
		for(int t = 0 ; t < format.object_list.obj_count; t++) {
			prefab[t] = EditorUtility.CreateEmptyPrefab(format.folder + "/" + format.object_list.obj[t].obj_name + ".prefab");
			EditorUtility.ReplacePrefab(child[t], prefab[t], ReplacePrefabOptions.ConnectToPrefab);
		}*/
		Object Root_Prefab = EditorUtility.CreateEmptyPrefab(format.folder + "/" + format.name + ".prefab");
		EditorUtility.ReplacePrefab(Root_obj, Root_Prefab, ReplacePrefabOptions.ConnectToPrefab);
		EndOfScript(format);
	}//*/
}
