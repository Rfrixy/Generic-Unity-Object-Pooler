using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{

	public GameObject objectToPool;
	public int amountToPool = 2;
	public bool shouldExpand = true;

}

public class ObjectPooler : MonoBehaviour
{
	public static ObjectPooler SharedInstance;
	public List<ObjectPoolItem> itemsToPool;


	public List<List<GameObject>> pooledObjectsList;
	public List<GameObject> pooledObjects;
	private List<int> positions;

	void Awake()
	{

		SharedInstance = this;

		pooledObjectsList = new List<List<GameObject>>();
		pooledObjects = new List<GameObject>();
		foreach (ObjectPoolItem item in itemsToPool)
		{
			pooledObjects = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjects.Add(obj);
			}
			pooledObjectsList.Add(pooledObjects);
		}

		positions = new List<int>();
		for (int i = 0; i < pooledObjectsList.Count; i++)
		{
			positions.Add(0);
		}
	}



	public GameObject GetPooledObject(int index)
	{

		int curSize = pooledObjectsList[index].Count;
		for (int i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
		{

			if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
			{
				positions[index] = i % curSize;
				return pooledObjectsList[index][i % curSize];
			}
		}

		if (itemsToPool[index].shouldExpand)
		{

			GameObject obj = (GameObject)Instantiate(itemsToPool[index].objectToPool);
			obj.SetActive(false);
			obj.transform.parent = this.transform;
			pooledObjectsList[index].Add(obj);
			return obj;

		}
		return null;
	}

	public List<GameObject> GetAllPooledObjects(int index)
	{
		return pooledObjectsList[index];
	}
}
