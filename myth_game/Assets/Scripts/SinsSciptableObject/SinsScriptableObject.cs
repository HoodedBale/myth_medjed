using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SinsObject", menuName = "ScriptableObject/Sins")]
public class SinsScriptableObject : ScriptableObject
{
	[System.Serializable]
	public class SinsObject
	{
		public int m_hellNumber;
		public List<string> SinsName;
	}

	public List<SinsObject> m_sinsObjects = new List<SinsObject>();

}

