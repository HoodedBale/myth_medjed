using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

[CreateAssetMenu(fileName = "SinsObject", menuName = "ScriptableObject/Sins")]
public class SinsScriptableObject : ScriptableObject
{
	[System.Serializable]
	public class SinsObject
	{
		public int m_hellNumber;
		public List<string> SinsName;
	}
	public class MiniSins
	{
		public int m_hellNumber;
		public string SinsName;

		public MiniSins(int number, string tempsinsName)
		{
			m_hellNumber = number;
			SinsName = tempsinsName;
		}
	}

	//TOtal 9
	//Hell element[0] = number 2, [1] = 3, ...., [8] = 10, 

	public List<SinsObject> m_sinsObjects = new List<SinsObject>();


	public List<MiniSins> GenerateSinList(int maxHellNumber, int numberOfSins, bool Reincarnation = false)
	{
		List<MiniSins> tempSins = new List<MiniSins>();

		if (Reincarnation)
		{
			MiniSins temp = new MiniSins(10, m_sinsObjects[m_sinsObjects.Count - 1].SinsName[0]);
			tempSins.Add(temp);
		}

		//Get total number of sins requires
		for(int i = 0; i < numberOfSins; ++i)
		{
			string tempName;
			int hellNumberTemp = Random.Range(2, maxHellNumber + 1);

			if (HellElement(hellNumberTemp) != null)
			{
				tempName = GetRandomSins(hellNumberTemp); 
			}
			else
			{
				--i;
				continue;
			}
			Debug.Log("I value " + i + " The hell number : " + hellNumberTemp + "  Sins name : " + tempName);
			MiniSins temp = new MiniSins(hellNumberTemp, tempName);
			tempSins.Add(temp);
		}
		
		return MakeDistinct(tempSins);
	}

	//hell 4 7 5 //list 3 5 8 4

	//need make sure no extra stamps
	public bool CompareWithList(List<MiniSins> currentSins, List<int> stampNumber)
	{
		int counter = 0;
		List<int> tempCurrentSins = ConvertCurrentSinsWithoutDuplicate(currentSins);


		if (stampNumber.Count != tempCurrentSins.Count)
			return false;

		//stamp					     currentsins
		//4  6 8 9 7 2               4 6 7 8 9 
		foreach (var inkNumber in stampNumber)
		{
			foreach(var sins in tempCurrentSins)
			{
				if (sins == inkNumber)
				{
					++counter;
					break;
				}
			}
		}
		if (counter == stampNumber.Count)
			return true;
		else
			return false;

	}

	List<int> ConvertCurrentSinsWithoutDuplicate(List<MiniSins> currentSins)
	{
		List<int> temp = new List<int>();
		foreach(var test in currentSins)
		{
			temp.Add(test.m_hellNumber);
		}
		temp = temp.Distinct().ToList();
		return temp;
	}

	public string GetRandomSins(int hellNumber)
	{
		//int randomNumber = Random.Range(0, m_sinsObjects[hellNumber].SinsName.Count);
		SinsObject temp = HellElement(hellNumber);
		if (temp != null)
		{
			return temp.SinsName[Random.Range(0, temp.SinsName.Count - 1)];
		}
		return null;
	}

	public SinsObject HellElement(int hellNumber)
	{
		foreach(var hell in m_sinsObjects)
		{
			if (hell.m_hellNumber == hellNumber)
				return hell;
		}
		return null;
	}

	public List<MiniSins> MakeDistinct(List<MiniSins> sins)
    {
		var temp = new List<MiniSins>();
		for(int i = 0 ; i < sins.Count; i++)
        {
			if(temp.Count == 0)
            {
				temp.Add(sins[i]);
			}
			else
            {
				bool dontAdd = false;
				for (int j = 0; j < temp.Count; j++)
				{
					if(sins[i].SinsName == temp[j].SinsName)
                    {
						dontAdd = true;
					}
				}

				if(!dontAdd)
					temp.Add(sins[i]);
			}
        }
		return temp;
    }

	public string ConvertListOfSinsToString(List<MiniSins> list)
    {
		string temp = "";
		foreach(MiniSins s in list)
        {
			temp += "- " + s.SinsName + '\n';
        }
		return temp;

    }
}

