using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;


namespace Root
{
	public class Format : IComparable
	{
		//convert shift-Jis to UTF-8
		/*
		protected string ConvertByteToString(byte[] bytes)
		{
			
			if (bytes[0] == 0) return "";
			int count;
			for (count = 0; count < bytes.Length; count++) if (bytes[count] == 0) break;
			byte[] buf = new byte[count];
			for (int i = 0; i < count; i++) {
				buf[i] = bytes[i];	
			}
			
			buf = Encoding.Convert(Encoding.GetEncoding(0), Encoding.UTF8, buf);
			return Encoding.UTF8.GetString(buf);
		}

		protected float[] ReadSingles(BinaryReader bin, uint count)
		{
			float[] result = new float[count];
			for (int i = 0; i < count; i++)
			{
				result[i] = bin.ReadSingle();
			}
			return result;
		}
			
		protected Vector3 ReadSinglesToVector3(BinaryReader bin)
		{
			const int count = 3;
			float[] result = new float[count];
			for (int i = 0; i < count; i++)
			{
				result[i] = bin.ReadSingle();
			}
			return new Vector3(result[0], result[1], result[2]);
		}
			
		protected Vector2 ReadSinglesToVector2(BinaryReader bin)
		{
			const int count = 2;
			float[] result = new float[count];
			for (int i = 0; i < count; i++)
			{
				result[i] = bin.ReadSingle();
			}
			return new Vector2(result[0], result[1]);
		}
			
		protected Color ReadSinglesToColor(BinaryReader bin)
		{
			const int count = 4;
			float[] result = new float[count];
			for (int i = 0; i < count; i++)
			{
				result[i] = bin.ReadSingle();
			}
			return new Color(result[0], result[1], result[2], result[3]);
		}
			
		protected Color ReadSinglesToColor(BinaryReader bin, float fix_alpha)
		{
			const int count = 3;
			float[] result = new float[count];
			for (int i = 0; i < count; i++)
			{
				result[i] = bin.ReadSingle();
			}
			return new Color(result[0], result[1], result[2], fix_alpha);
		}

		protected uint[] ReadUInt32s(BinaryReader bin, uint count)
		{
			uint[] result = new uint[count];
			for (int i = 0; i < count; i++)
			{
				result[i] = bin.ReadUInt32();
			}
			return result;
		}

		protected ushort[] ReadUInt16s(BinaryReader bin, uint count)
		{
			ushort[] result = new ushort[count];
			for (uint i = 0; i < count; i++)
			{
				result[i] = bin.ReadUInt16();
			}
			return result;
		}
		
		protected Quaternion ReadSinglesToQuaternion(BinaryReader bin)
		{
			const int count = 4;
			float[] result = new float[count];
			for (int i = 0; i < count; i++)
			{
				result[i] = bin.ReadSingle();
			}
			return new Quaternion(result[0], result[1], result[2], result[3]);
		}
		*/
		
		//Read Single from String Format
		protected float ReadStringsingle(String str, char[] splitIdentifier)
		{
			float result;
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			
			result = Convert.ToSingle(brokenString[1]);
			return result;
		}
		
		//Read int from String Format
		protected int ReadStringInt32(String str, char[] splitIdentifier)
		{
			int result;
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			
			result = Convert.ToInt32(brokenString[1]);
			
			return result;
		}
		
		//Read Uint32 from String Format
		protected uint ReadStringUInt32(String str, char[] splitIdentifier)
		{
			uint result;
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			
			result = Convert.ToUInt32(brokenString[1]);
			
			return result;
		}
		
		//Read Uint 32s from String Format
		protected uint[] ReadStringUInt32s(String str, char[] splitIdentifier,int count)
		{
			uint[] result = new uint[count];
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			for( int i = 0; i < count; i++)
			{
				result[i] = Convert.ToUInt32(brokenString[i+1]);
			}
			return result;
		}
		
		//Read Vector2 from String Format
		protected Vector2[] ReadStringVector2s(string str , char[] splitIdentifier,int count)
		{
			Vector2[] result = new Vector2[count*2];
			
			string[] brokenString;
			
			int ReadAdd = 0;
			float x_result;
			float y_result;
						
			brokenString = str.Split(splitIdentifier,50);
			
			for (int i = 0; i < count; i++)
			{
				x_result = Convert.ToSingle(brokenString[ReadAdd]);
				y_result = Convert.ToSingle(brokenString[ReadAdd+1]);
				
				result[i] = new Vector2(x_result,y_result);
				ReadAdd = ReadAdd + 2;
			}
			return result;
		}
		
		//Read Vector3 from String Format
		protected Vector3 ReadStringVector3(string str , char[] splitIdentifier)
		{
			const int count = 3;
			float[] result = new float[count];
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			
			for (int i = 0; i < count; i++)
			{
				result[i] = Convert.ToSingle(brokenString[i]);
			}
			return new Vector3(result[0], result[1], result[2]);
		}
		
		//Read Color from String Format
		protected Color ReadStringRGB(string str , char[] splitIdentifier)
		{
			const int count = 3;
			float[] result = new float[count];
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			
			for (int i = 0; i < count; i++)
			{
				result[i] = Convert.ToSingle(brokenString[i+1]);
			}
			return new Color(result[0], result[1], result[2]);
		}
		
		//Read RGBA from String Format
		protected Color ReadStringRGBA(string str , char[] splitIdentifier)
		{
			const int count = 4;
			float[] result = new float[count];
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			
			for (int i = 0; i < count; i++)
			{
				result[i] = Convert.ToSingle(brokenString[i+1]);
			}
			return new Color(result[0], result[1], result[2] , result[3]);
		}
		
		//Read Vertex Color from String Format with MQO
		protected Color32[] ReadStringColor32s(string str , char[] splitIdentifier,int count)
		{
			Color32[] result = new Color32[count];
			//mask r g b a
			
			
			string[] brokenString;
			
			brokenString = str.Split(splitIdentifier,50);
			
			UInt32 keeper;
			
			for (int i = 0; i < count; i++)
			{
				keeper = Convert.ToUInt32(brokenString[i+1]);
				result[i].r = (byte)(0x000000ff & keeper);
				result[i].g = (byte)((0x0000ff00 & keeper) >> 8);
				result[i].b = (byte)((0x00ff0000 & keeper) >> 16);
				result[i].a = (byte)((0xff000000 & keeper) >> 24);
				//Debug.Log(result[i]);
			}
			return result;
		}
		
		protected int count = 0;
		public int CompareTo(object obj)
		{
			return count - ((Format)obj).count;
		}
	}

	namespace MQO
	{
		//Mqo loader class
		public class MQOLoader
		{
			public static MQOFormat Load(StreamReader stream, GameObject caller, string path)
			{
				return new MQOFormat(stream, caller, path);
			}
		}
		
		public class MQOFormat : Root.Format
		{
			public string path;			//Full pass
			public string name;			//pass name &.___
			public string folder;			// pass without filename
			public GameObject caller;		//MQO Loader script object
			
			public Header head;
			public Scene scene;
			public bool haveMaterial = false;
			public MaterialList material_list;
			public ObjectList object_list;
			
			int read_count = 0;
			
			public Vector3 GetVPos(int obj_id ,int face_add,int vart_add)
			{
				return object_list.obj[obj_id].vertex_list.vertex
							[ object_list.obj[obj_id].face_list.face[face_add].face_vert_index[vart_add] ].pos;
			}
			
			public Vector2 GetVUV(int obj_id , int face_add, int vart_add)
			{
				return object_list.obj[obj_id].face_list.face[face_add].uv[vart_add];
			}
			
			public uint GetVIndex(int obj_id , int face_add, int vart_add)
			{
				return object_list.obj[obj_id].face_list.face[face_add].face_vert_index[vart_add];
			}
			
			//pass Entry
			void EntryPathes(string path)
			{
				this.path = path;
				string[] buf = path.Split('/');
				this.name = buf[buf.Length-1];
				this.name = name.Split('.')[0];		//without .mqo
				
				//MQO's Folder
				this.folder = buf[0];
				for (int i = 1; i < buf.Length-1; i++)
				this.folder += "/" + buf[i];
			}
			
			public MQOFormat(StreamReader stream, GameObject caller, string path) 	//MQO独自フォーマットクラス
			{
				EntryPathes(path);		
				this.caller = caller;
				
				uint testcount = 1;
				
				//textDate Load with StreamReader
				string entireText = stream.ReadToEnd();
				//to StringReader
				StringReader sreader = new StringReader(entireText);
				try {
					
					string currenttext = sreader.ReadLine();
					
					if(currenttext.StartsWith("Metasequoia Document"))
						this.head = new Header(sreader,currenttext);
					else
						return;
					while( (currenttext = sreader.ReadLine()) != null)
					{
						//Debug.Log(currenttext);
						if(currenttext.StartsWith("Scene {"))
							this.scene = new Scene(sreader);
						
						else if(currenttext.StartsWith("Material "))
						{
							this.material_list = new MaterialList(sreader,currenttext);
							haveMaterial = true;
						}
						
						else if(currenttext.StartsWith("Object "))
						{
							this.object_list = new ObjectList(sreader,currenttext,entireText);
						}
					}
				} catch {
					Debug.Log("Don't read full format");
				}
			}
			
			//Header Comp
			public class Header : Root.Format
			{
				public string magic; // "Metasequoia Document"
				public bool datatype; // false:Binary true:Text
				public float version; // 1.0
			
				public Header(StringReader sreader,String code)
				{					
					string currentText;
			        char[] splitIdentifier = { ' ' };
			        string[] brokenString;
					
					this.magic = code;
					
					currentText = sreader.ReadLine();
					currentText = currentText.Trim();
                    brokenString = currentText.Split(splitIdentifier, 50);
					
					if(brokenString[1] == "Text")
						this.datatype = true;
					else
						this.datatype = false;
					
					this.version = Convert.ToSingle(brokenString[3]);
					/*
					Debug.Log("Header");
					Debug.Log("Magic:" + this.magic);
					Debug.Log("Datatype:" + this.datatype);
					Debug.Log("Version:" + this.version);
					Debug.Log("/Header");
					*/
				}
			}
			
			//Scene Comp Ajust Ver3.0
			public class Scene : Root.Format
			{
				public Vector3 position;
				public Vector3 lookat;
				public float head;
				public float pich;
				public float bank;
				public float ortho;
				public float zoom2;
				public Color amb;
				public uint dirlights_count;
				public Vector3[] dir;
				public Color[] color;
				
				public Scene(StringReader sreader)
				{
					string currentText = sreader.ReadLine();
			        char[] splitIdentifier = { ' ' };
					char[] trimIdentifier =  { '\t' };
					
					while(!currentText.StartsWith("}"))
					{
						//Debug.Log(currentText);
						if(currentText.StartsWith("	pos "))
						{
							this.position = ReadStringVector3(currentText.Substring(5),splitIdentifier);
							//Debug.Log("Pos:"+this.position);
						}
						else if(currentText.StartsWith("	lookat "))
						{
							this.lookat = ReadStringVector3(currentText.Substring(8),splitIdentifier);
							//Debug.Log("Lookat:"+this.Lookat);
						}
						else if(currentText.StartsWith("	head "))
						{
							this.head = ReadStringsingle(currentText,splitIdentifier);
						}
						else if(currentText.StartsWith("	pich "))
						{
							this.pich = ReadStringsingle(currentText,splitIdentifier);
						}
						else if(currentText.StartsWith("	bank "))
						{
							this.bank = ReadStringsingle(currentText,splitIdentifier);
						}
						else if(currentText.StartsWith("	ortho "))
						{
							this.ortho = ReadStringsingle(currentText,splitIdentifier);
						}
						else if(currentText.StartsWith("	zoom2 "))
						{
							this.zoom2 = ReadStringsingle(currentText,splitIdentifier);
						}
						else if(currentText.StartsWith("	amb "))
						{
							this.amb = ReadStringRGB(currentText,splitIdentifier);
						}
						else if(currentText.StartsWith("	dirlights "))
						{
							this.dirlights_count = ReadStringUInt32(currentText,splitIdentifier);
							this.dir = new Vector3[this.dirlights_count];
							this.color = new Color[this.dirlights_count];
							
							int i = 0;
							while(i < this.dirlights_count)
							{
								currentText = sreader.ReadLine();	//
								if(currentText.StartsWith("			dir "))
									this.dir[i] = ReadStringVector3(currentText.Substring(7),splitIdentifier);
								else if(currentText.StartsWith("			color "))
									this.color[i] = ReadStringRGB(currentText,splitIdentifier);
								if(currentText.EndsWith("}"))
									i++;
							}
							currentText = sreader.ReadLine(); // break }
						}
						currentText = sreader.ReadLine();
						currentText.TrimStart(trimIdentifier);
					}
					//Scene's palam
					/*
					Debug.Log("Scene");
					Debug.Log("position:" + this.position);
					Debug.Log("lookat:" + this.lookat);
					Debug.Log("head:" + this.head);
					Debug.Log("pich:" + this.pich);
					Debug.Log("bank:" + this.bank);
					Debug.Log("ortho:" + this.ortho);
					Debug.Log("zoom2:" + this.zoom2);
					Debug.Log("amb Color:" + this.amb);
					Debug.Log("dirlights_count:" + this.dirlights_count);
					for(int i = 0; i < this.dirlights_count; i++)
					{
						Debug.Log(i + "dir_Vector:" + this.dir[i]);
						Debug.Log(i + "dir_color:" + this.color[i]);
					}
					Debug.Log("/Scene");
					*/
					
				}
			}
			
			//MaterialList Comp
			public class MaterialList : Root.Format
			{
				public uint material_count; //
				public Material[] material; //
			
				public MaterialList(StringReader sreader,String beforeCode)
				{
					char[] splitIdentifier = { ' ' };
					
					this.material_count = ReadStringUInt32(beforeCode,splitIdentifier);
					//Debug.Log("MaterialCount:" + material_count);
					
					string currentText = sreader.ReadLine();					
					
					this.material = new Material[this.material_count];
					
					for (int i = 0; i < this.material_count; i++)
					{
						this.material[i] = new Material(currentText);
						currentText = sreader.ReadLine();
					}
				}
			}
			
			//Material comp
			public class Material : Root.Format
			{
				public string materialName; //Write with " %s "
				public uint shader;
				public uint vcol; 		// 0:nothing 1:Use
				public Color col; 		// RGBA (%.3f , %.3f , %.3f , %.3f) 0-1 float
				
				public float dif; 		// diffuse 	(%.3f) 0-1 float
				public float amb; 		// ambient 	(%.3f) 0-1 float
				public float emi; 		// emissive 	(%.3f) 0-1 float
				public float spc; 		// specula 	(%.3f) 0-1 float
				public float power; 	// specula power (%.2f) 0-100 float
				public string tex = "";		// texture path
				public string aplane = "";	// aplane(alpha) texture path
				public string bump = "";		// bump
				public uint proj_type;// Mapping Type 0:UV 1:flat 2:entou 3:sphere
				
				//Warning : There material chank will change material2
				//		  : so if change material2 you can search this chank
					
				public Material(String currentText)
				{
			        char[] splitIdentifier = {')'};
					char[] secondSplitIdentifier = {'(',' '};
			        string[] brokenString  = null;
					
					int firstDC = (currentText.IndexOf('\"')) + 1;
					int length = (currentText.IndexOf('\"',firstDC) - firstDC);
					
					// Read Material Name
					this.materialName = currentText.Substring(firstDC,length);
					//Debug.Log ("MatName:" + this.materialName);
					currentText = currentText.Remove(firstDC-2,length + 3);
					
					//Read Texture's Name(Path)
					if(currentText.Contains("tex(\""))
					{
						firstDC = currentText.IndexOf('\"') + 1;
						length = (currentText.IndexOf('\"',firstDC) - firstDC);
						this.tex = currentText.Substring(firstDC,length);
						//Debug.Log("TexName:" + this.tex);
						currentText = currentText.Remove(firstDC-5,length + 7);
						//Debug.Log (currentText);
					}
					
					if(currentText.Contains("aplane(\""))
					{
						firstDC = currentText.IndexOf('\"',length) + 1;
						length = (currentText.IndexOf('\"',firstDC) - firstDC);
						this.aplane = currentText.Substring(firstDC,length);
						//Debug.Log ("AlphaName:" + this.aplane);
						currentText = currentText.Remove(firstDC-8,length + 10);
						//Debug.Log (currentText);
					}
					
					if(currentText.Contains("bump(\""))
					{
						firstDC = currentText.IndexOf('\"',length) + 1;
						length = (currentText.IndexOf('\"',firstDC) - firstDC);
						this.bump = currentText.Substring(firstDC,length);
						//Debug.Log ("BumpName:" + this.bump);
						currentText = currentText.Remove(firstDC-6,length + 8);
						//Debug.Log (currentText);
					}
					
					//Debug.Log("Read Material");
					//Read Param
					
					brokenString = currentText.Split(splitIdentifier,50);
					foreach(string str in brokenString)
					{
						if(str.StartsWith(" shader("))
						{
							this.shader = ReadStringUInt32(str.Trim(),secondSplitIdentifier);
							//Debug.Log("shader:" + this.shader);
						}
						else if(str.StartsWith(" vcol("))
						{
							this.vcol = ReadStringUInt32(str.Trim(),secondSplitIdentifier);
							//Debug.Log("vcol:" + this.vcol);
						}
						else if(str.StartsWith(" col("))
						{
							this.col = ReadStringRGBA(str.Trim(),secondSplitIdentifier);
							//Debug.Log("Color:" + this.col);
						}
						else if(str.StartsWith(" dif("))
						{
							this.dif = ReadStringsingle(str.Trim(),secondSplitIdentifier);
							//Debug.Log("Diffuse:" + this.dif);
						}
						else if(str.StartsWith(" amb("))
						{
							this.amb = ReadStringsingle(str.Trim(),secondSplitIdentifier);
							//Debug.Log("amb:" + this.amb);
						}
						else if(str.StartsWith(" emi("))
						{
							this.emi = ReadStringsingle(str.Trim(),secondSplitIdentifier);
							//Debug.Log("emi:" + this.emi);
						}
						else if(str.StartsWith(" spc("))
						{
							this.spc = ReadStringsingle(str.Trim(),secondSplitIdentifier);
							//Debug.Log("spc:" + this.spc);
						}
						else if(str.StartsWith(" power("))
						{
							this.power = ReadStringsingle(str.Trim(),secondSplitIdentifier);
							//Debug.Log("power:" + this.power);
						}
					}
					//Debug.Log("Read Materiar///////");
				}
			}
			
			//ObjectList yet
			public class ObjectList : Root.Format
			{
				public uint obj_count = 0; //
				public Obj[] obj;
				
				public ObjectList(StringReader sreader,String FirstCode,String entireText)
				{
					char[] splitIdentifier = {'\"'};
					
					string[] namecontena = FirstCode.Split(splitIdentifier);
					
					string obj_name;
					string currenttext;
					//count obj
					StringReader count = new StringReader(entireText);
					string countstr = count.ReadLine();
					
					while(!countstr.StartsWith("Eof"))
					{
						countstr = count.ReadLine();
						if(countstr.StartsWith("Object "))
						{
							obj_count++;
							//Debug.Log(obj_count);
						}
					}
					//Debug.Log("ObjectCount:" + obj_count);
					
					this.obj = new Obj[this.obj_count];
					
					for (int i = 0; i < this.obj_count; i++)
					{	
						if(i != 0)
						{
							currenttext = sreader.ReadLine();
							namecontena = currenttext.Split(splitIdentifier);
						}
						obj_name = namecontena[1];
						//Debug.Log("Object" + i + ":" + obj_name + " Now reading...");
						this.obj[i] = new Obj(sreader,obj_name);
						//Debug.Log("Object" + i + ":" + obj_name + " Now readout");
					}
				}
			}
			
			public class Obj : Root.Format
			{
				public string obj_name;
				/*
				public uint uid;
				public uint depth;
				public uint folding;
				public Vector3 scale;
				public Vector3 rotation;
				public Vector3 translation;
				public uint patch;
				public uint parchtri;
				public uint segment;
				//public uint visible;
				public uint locking;
				public uint shading;
				public float facet;
				public Color SideColor;
				public uint color_type;
				public uint mirror;
				public uint mirror_axis;
				public uint lathe;
				public uint lathe_axis;
				*/
				public uint visible;
				public uint shading;
				public float facet;
				
				public VertexList vertex_list;
				public FaceList face_list;
				
				public Obj(StringReader sreader,string name)
				{
					this.obj_name = name;
					
					String currentText = sreader.ReadLine();
					String[] brokenstring;
					char[] split_space = {' '};
					
					uint vartex_count;
					uint face_count;
					uint polygon_count;
					
					while(!currentText.StartsWith("}"))
					{
						//Debug.Log(currentText);
						if(currentText.StartsWith("	visible"))
						{
							this.visible = ReadStringUInt32(currentText,split_space);
						}
						else if(currentText.StartsWith("	shading"))
						{
							this.shading = ReadStringUInt32(currentText,split_space);
						}
						else if(currentText.StartsWith("	facet"))
						{
							this.facet = ReadStringsingle(currentText,split_space);
						}
						else if(currentText.StartsWith("	vertex") && !currentText.StartsWith("	vertexattr") )
						{
							//Debug.Log("Reading vert");
							vartex_count = ReadStringUInt32(currentText,split_space);
							this.vertex_list = new VertexList(sreader,vartex_count);
						}
						else if(currentText.StartsWith("	face") && !currentText.StartsWith("	facet"))
						{
							//Debug.Log("Reading face");
							face_count = ReadStringUInt32(currentText,split_space);
							polygon_count = face_count;
							this.face_list = new FaceList(sreader,face_count,polygon_count);
						}
						currentText = sreader.ReadLine();
					}	
				}
			}
			
			public class VertexList : Root.Format
			{
				public uint vert_count;
				public Vertex[] vertex;
				
				public VertexList(StringReader sreader,uint count)
				{
					this.vert_count = count;
					this.vertex = new Vertex[vert_count];
					//Debug.Log("Vert_count:" + this.vert_count);
					//Debug.Log("read vertex");
					for (int i = 0; i < this.vert_count; i++)
						this.vertex[i] = new Vertex(sreader);
				}
			}
			
			public class Vertex : Root.Format
			{
				public Vector3 pos;
				
				public Vertex(StringReader sreader)
				{
					string currencttext;
					char[] split_space = { ' ' };
					currencttext = sreader.ReadLine();
					//Debug.Log("V ct: " + currencttext);
					
					this.pos = ReadStringVector3(currencttext,split_space);
					//Debug.Log("Vert_Pos :" + this.pos);
				}
			}
			
			public class FaceList : Root.Format
			{
				public uint face_count;
				public Face[] face;
				public int face_vartex_count = 0;
				
				public FaceList(StringReader sreader,uint count,uint p_count)
				{
					this.face_count = count;
					this.face = new Face[this.face_count];
					for (int i = 0; i < this.face_count; i++)
					{
						this.face[i] = new Face(sreader);
						this.face_vartex_count += this.face[i].vartex_count;
						if(face[i].vartex_count == 4)
							p_count++;
						
					}
					//Debug.Log(this.face_vartex_count);
				}
			}
			
			public class Face : Root.Format
			{
				public int vartex_count;
				public uint[] face_vert_index;
				public int mat = -1;
				public Vector2[] uv;
				public Color32[] vcol;
				
				public Face(StringReader sreader)
				{
					char[] splitIdentifier = {')'};
					char[] secondSplitIdentifier = {'(',' '};
					string[] brokenstring = null;
					
					String format;
					
					String currenttext = sreader.ReadLine();
					//Debug.Log("read:" + currenttext);
					if(currenttext.StartsWith("		3"))
					{
						//Debug.Log("reading 3V face");
						brokenstring = currenttext.Split(splitIdentifier,50);
						foreach(string str in brokenstring)
						{
							//Debug.Log("Now Read:"+ str);
							if(str.StartsWith("		3"))
							{
								this.vartex_count = 3;
								this.face_vert_index = new uint[this.vartex_count];
								this.face_vert_index = ReadStringUInt32s(str.Substring(4),secondSplitIdentifier,this.vartex_count);
								this.uv = new Vector2[this.vartex_count];
								this.uv[0] = Vector2.zero;
								this.uv[1] = Vector2.zero;
								this.uv[2] = Vector2.zero;
								//Debug.Log("readed 3 Index:" + this.face_vert_index[0]+ " " + this.face_vert_index[1]+ " " + this.face_vert_index[2]);
							}
							else if(str.StartsWith(" M"))
							{
								this.mat = ReadStringInt32(str.Trim(),secondSplitIdentifier);
								//Debug.Log("readed MatNum:" + this.mat);
							}
							else if(str.StartsWith(" UV"))
							{
								this.uv = new Vector2[this.vartex_count];
								this.uv = ReadStringVector2s(str.Substring(4),secondSplitIdentifier,this.vartex_count);
								//format = System.String.Format( "read: {0:F5} {1:F5}", this.uv[0].x , this.uv[0].y );
								//Debug.Log(format);
								//Debug.Log("readed 3 UV:" + this.uv[0]+ " " + this.uv[1]+ " " + this.uv[2]);
							}
							else if(str.StartsWith(" COL"))
							{
								this.vcol = new Color32[this.vartex_count];
								this.vcol =  ReadStringColor32s(str.Trim(),secondSplitIdentifier,this.vartex_count);
							}
						}
					}
					else if(currenttext.StartsWith("		4"))
					{
						///*
						//*/
						//Debug.Log("reading 4V face");
						brokenstring = currenttext.Split(splitIdentifier,50);
						foreach(string str in brokenstring)
						{
							//Debug.Log("Now Read:"+ str);
							if(str.StartsWith("		4"))
							{
								this.vartex_count = 4;
								this.face_vert_index = new uint[this.vartex_count];
								this.face_vert_index = ReadStringUInt32s(str.Substring(4),secondSplitIdentifier,this.vartex_count);
								this.uv = new Vector2[this.vartex_count];
								this.uv[0] = Vector2.zero;
								this.uv[1] = Vector2.zero;
								this.uv[2] = Vector2.zero;
								this.uv[3] = Vector2.zero;
								//Debug.Log("readed 3 Index:" + this.face_vert_index[0]+ " " + this.face_vert_index[1]+ " " + this.face_vert_index[2]);
							}
							else if(str.StartsWith(" M"))
							{
								this.mat = ReadStringInt32(str.Trim(),secondSplitIdentifier);
								//Debug.Log("readed MatNum:" + this.mat);
							}
							else if(str.StartsWith(" UV"))
							{
								this.uv = new Vector2[this.vartex_count];
								this.uv = ReadStringVector2s(str.Substring(4),secondSplitIdentifier,this.vartex_count);
								//Debug.Log("readed 4 UV:" + this.uv[0]+ " " + this.uv[1]+ " " + this.uv[2]+ " " + this.uv[3]);
							}
							else if(str.StartsWith(" COL"))
							{
								this.vcol = new Color32[this.vartex_count];
								this.vcol =  ReadStringColor32s(str.Trim(),secondSplitIdentifier,this.vartex_count);
							}
						}
					}
				}
			}
		}
	}
}