using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlockForBuilding))]
public class BlockForBuildingEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		EditorGUILayout.LabelField("Number of blocks", BlockForBuilding.NumberOfBlocks.ToString());
		DrawDefaultInspector();
	}
}
