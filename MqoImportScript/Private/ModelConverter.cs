//*
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

namespace Root
{
	namespace MQO
	{
		public class MQOConverter
		{
			
			//Entry Vertices Position of object
			Vector3[] EntryVertices(MQO.MQOFormat format,int obj_id)
			{
				int vcount = (int)format.object_list.obj[obj_id].face_list.face_vartex_count;
				
				int face_add = 0;
				Vector3[] vpos = new Vector3[vcount];
				for (int i = 0; i < vcount;)
				{
					if(format.object_list.obj[obj_id].face_list.face[face_add].vartex_count == 3)
					{
						vpos[i] = format.GetVPos(obj_id ,face_add,2);
						vpos[i+1] = format.GetVPos(obj_id ,face_add,0);
						vpos[i+2] = format.GetVPos(obj_id ,face_add,1);
					}
					else if(format.object_list.obj[obj_id].face_list.face[face_add].vartex_count == 4)
					{
						vpos[i] = format.GetVPos(obj_id ,face_add,3);
						vpos[i+1] = format.GetVPos(obj_id ,face_add,0);
						vpos[i+2] = format.GetVPos(obj_id ,face_add,1);
						vpos[i+3] = format.GetVPos(obj_id ,face_add,2);
					}
					i += format.object_list.obj[obj_id].face_list.face[face_add].vartex_count;
					face_add++;
				}
				for(int i = 0; i < vcount; i++)
					vpos[i] = Vector3.Reflect(vpos[i],Vector3.right);
				return vpos;
			}
			
			//Entry Vertives NormalsVector of Face (You must make Normals from face positions)
			Vector3[] EntryNormals(MQO.MQOFormat format,int obj_id)
			{
				int vcount = (int)format.object_list.obj[obj_id].face_list.face_vartex_count;
				
					//Entry Normal vector making
				Vector3 Nvector_1;
				Vector3 Nvector_2;
				Vector3 Nvector;
				
				int face_add = 0;
				Vector3[] normal = new Vector3[vcount];
				
				
				for (int i = 0; i < vcount;)
				{
					if(format.object_list.obj[obj_id].face_list.face[face_add].vartex_count == 3)
					{
						//Entry Normal vector making
						Nvector_1 = format.GetVPos(obj_id ,face_add,1) - format.GetVPos(obj_id ,face_add,0);
						Nvector_2 = format.GetVPos(obj_id ,face_add,2) - format.GetVPos(obj_id ,face_add,0);
						Nvector = Vector3.Cross(Nvector_2,Nvector_1);
						Nvector.Normalize();
						
						normal[i+2] = Nvector;
						normal[i+1] = Nvector;
						normal[i] = Nvector;
					}
					else if(format.object_list.obj[obj_id].face_list.face[face_add].vartex_count == 4)
					{
						//
						Nvector_1 = format.GetVPos(obj_id ,face_add,2) - format.GetVPos(obj_id ,face_add,0);
						Nvector_2 = format.GetVPos(obj_id ,face_add,3) - format.GetVPos(obj_id ,face_add,1);
						Nvector = Vector3.Cross(Nvector_2,Nvector_1);
						Nvector.Normalize();
						
						normal[i+3] = Nvector;
						normal[i+2] = Nvector;
						normal[i+1] = Nvector;
						normal[i] = Nvector;
						
					}
					i += format.object_list.obj[obj_id].face_list.face[face_add].vartex_count;
					face_add++;
				}
				for(int i = 0; i < vcount; i++)
					normal[i] = Vector3.Reflect(normal[i],Vector3.right);
				return normal;
			}
			
			
			//Entry UV of Face
			Vector2[] EntryUV(MQO.MQOFormat format,int obj_id)
			{	
				int vcount = (int)format.object_list.obj[obj_id].face_list.face_vartex_count;
				int fcount = (int)format.object_list.obj[obj_id].face_list.face_count;
				
				int face_add = 0;
				Vector2[] uvs = new Vector2[vcount];
				
				for (int i = 0; i < vcount;)
				{
					if(format.object_list.obj[obj_id].face_list.face[face_add].vartex_count == 3)
					{
						uvs[i] = format.GetVUV(obj_id ,face_add,2);
						uvs[i+1] = format.GetVUV(obj_id ,face_add,0);
						uvs[i+2] = format.GetVUV(obj_id ,face_add,1);
					}
					else if(format.object_list.obj[obj_id].face_list.face[face_add].vartex_count == 4)
					{
						uvs[i] = format.GetVUV(obj_id ,face_add,3);
						uvs[i+1] = format.GetVUV(obj_id ,face_add,0);
						uvs[i+2] = format.GetVUV(obj_id ,face_add,1);
						uvs[i+3] = format.GetVUV(obj_id ,face_add,2);
					}
					i += format.object_list.obj[obj_id].face_list.face[face_add].vartex_count;
					face_add++;
				}
				//for(int i = 0; i < vcount; i++)
					//Debug.Log("uvs: "+ i + ":"  + uvs[i]);
				return uvs;
			}
			
			//Entry Vert/normal/uv object Mesh
			void EntryAttributesForMesh(MQO.MQOFormat format, Mesh[] mesh)
			{
				for(int obj_id = 0; obj_id < format.object_list.obj_count; obj_id++)
				{
					mesh[obj_id].vertices = EntryVertices(format,obj_id);
					mesh[obj_id].normals = EntryNormals(format,obj_id);
					mesh[obj_id].uv = EntryUV(format,obj_id);
				}
			}
			
			//Entry Mesh's Material & Vertex index
			void SetSubMesh(MQO.MQOFormat format, Mesh[] mesh)
			{
				int vcount;
				int fcount;
				int face_add;
				for(int obj_id = 0; obj_id < format.object_list.obj_count; obj_id++)
				{
					vcount = (int)format.object_list.obj[obj_id].face_list.face_vartex_count;
					fcount = (int)format.object_list.obj[obj_id].face_list.face_count;
					face_add = 0;
					
					//サブメッシュ対マテリアル数
					//warning after this line change
					mesh[obj_id].subMeshCount = (int)format.material_list.material_count;
					
					List<int> submesh = new List<int>();
					int v_add = 0;
					for (int i = 0; i < mesh[obj_id].subMeshCount; i++)
					{
						for (int f_add = 0; f_add < fcount; f_add++) {
							if (i == format.object_list.obj[obj_id].face_list.face[f_add].mat) {
								if(format.object_list.obj[obj_id].face_list.face[f_add].vartex_count == 3)
								{
									submesh.Add((int)v_add);
									submesh.Add((int)v_add+1);
									submesh.Add((int)v_add+2);
									v_add += 3;
								}
								else if(format.object_list.obj[obj_id].face_list.face[f_add].vartex_count == 4)
								{
									submesh.Add((int)v_add);
									submesh.Add((int)v_add+1);
									submesh.Add((int)v_add+2);
									submesh.Add((int)v_add+2);
									submesh.Add((int)v_add+3);
									submesh.Add((int)v_add);
									v_add += 4;
								}
							}
						}
						//for(int f = 0; f < submesh.Count; f+=3)
							//Debug.Log(obj_id + "'submesh_" + f + ":" + submesh[f] + "," + submesh[f+1] + "," + submesh[f+2]);
						int[] buf = new int[submesh.Count];
						submesh.CopyTo(buf);
						mesh[obj_id].SetTriangles(buf, i);
						submesh.Clear();
					}
				}
			}
			
			// メッシュをProjectに登録
			void CreateAssetForMesh(MQO.MQOFormat format, Mesh[] mesh)
			{
				for(int i =0; i < format.object_list.obj_count; i++)
				{
					AssetDatabase.CreateAsset(mesh[i], format.folder + "/" + format.object_list.obj[i].obj_name + ".asset");
					AssetDatabase.SaveAssets ();
				}
			}
			
			//Create Mesh object
			public Mesh[] CreateMeshes(MQO.MQOFormat format)
			{
				Mesh[] mesh = new Mesh[format.object_list.obj_count];
				for(int i = 0; i < format.object_list.obj_count; i++)
					mesh[i] = new Mesh();
				
				//Mesh Parametor Entry
				EntryAttributesForMesh(format, mesh);
				//comp
				
				//Set Mesh Material and Triangle
				SetSubMesh(format, mesh);
				CreateAssetForMesh(format, mesh);
				return mesh;
			}
			
			//You must make mqo shader switch
			//Create Material Object
			void EntryColors(MQO.MQOFormat format, Material[] mats)
			{
				// マテリアルの生成 
				for (int i = 0; i < mats.Length; i++)
				{
					// mqoフォーマットのマテリアルを取得 
					MQO.MQOFormat.Material mqoMat = format.material_list.material[i];
					
					switch(mqoMat.shader)
					{
						case 0:
							mats[i] = new Material(Shader.Find("Diffuse"));
							break;
						case 1:
							mats[i] = new Material(Shader.Find("Metasequoia/Constant"));
							break;
						default :
							mats[i] = new Material(Shader.Find("Diffuse"));
							break;
					}
					mats[i].color = mqoMat.col;
					
					// テクスチャが空でなければ登録
					if (mqoMat.tex != "") {
						string path = format.folder + "/" + mqoMat.tex;
						mats[i].mainTexture = AssetDatabase.LoadAssetAtPath(path, typeof(Texture)) as Texture;
						mats[i].mainTextureScale = new Vector2(1, -1);
					}
				}
			}
			
			//マテリアルに必要な色などを登録
			Material[] EntryAttributesForMaterials(MQO.MQOFormat format)
			{
				int count = (int)format.material_list.material_count;
				Material[] mats = new Material[count];
				EntryColors(format, mats);
				return mats;
			}
			
			//マテリアルの登録
			void CreateAssetForMaterials(MQO.MQOFormat format, Material[] mats)
			{
				// 適当なフォルダに投げる
				string path = format.folder + "/Materials/";
				AssetDatabase.CreateFolder(format.folder, "Materials");
				
				for (int i = 0; i < mats.Length; i++)
				{
					string fname = path + format.material_list.material[i].materialName + ".asset";
					AssetDatabase.CreateAsset(mats[i], fname);
				}
			}
			
			// マテリアルの生成
			public Material[] CreateMaterials(MQO.MQOFormat format)
			{
				Material[] materials;
				materials = EntryAttributesForMaterials(format);
				CreateAssetForMaterials(format, materials);
				return materials;
			}
			
			public void ReplaceObject(MQO.MQOFormat format , int obj_id ,GameObject obj, Mesh mesh, UnityEngine.Material[] materials) 
			{
				MeshFilter filter = obj.AddComponent<MeshFilter>();
				filter.mesh = mesh;
				MeshRenderer mren = obj.AddComponent<MeshRenderer>();
				mren.sharedMaterials = materials;
			}
		}
	}
}
//*/