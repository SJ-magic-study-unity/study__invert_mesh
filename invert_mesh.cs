/************************************************************
参考URL
	【Unity5】スキンメッシュを裏返す方法
		http://www.gogogogo.jp/issue/diary/%E4%B8%80%E4%BA%BA%E5%A4%A7%E5%AD%A6/unity5/3962/
************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invert_mesh : MonoBehaviour {

	/******************************
	******************************/
	void Start () {
		// for skinmesh
		/*
		SkinnedMeshRenderer renderer = GetComponent<SkinnedMeshRenderer>();
		Mesh mesh = renderer.sharedMesh;
		*/
		
		// for mesh filter
		MeshFilter filter = GetComponent<MeshFilter>();
		Mesh mesh = filter.mesh;

		for(int m=0; m < mesh.subMeshCount; m++) { //ポリゴンのインデックスを取得する
			int[] triangles = mesh.GetTriangles(m);
			
			//ポリゴンなので３つずつインクリメントしてループ
			for (int i = 0; i < triangles.Length; i += 3) {
				//２番目と３番目の頂点インデックスを入れ替えて三角形を反転する
				int index = triangles[i+1]; triangles[i+1] = triangles[i+2];
				triangles[i+2] = index;
			}
			
			//ポリゴンのインデックスをメッシュに戻す
			mesh.SetTriangles(triangles, m);
		}
		
		//法線を再計算する
		mesh.RecalculateNormals();		
	}
	
	/******************************
	******************************/
	void Update () {
		
	}
}
