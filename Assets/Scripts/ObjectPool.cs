using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	public GameObject ObjectPrefab;
	int _initialAmount = 500;
	bool _createOnEmptyList = true;

	private Queue<GameObject> _objectList;
	private List<GameObject> _objectFreeList;

	// Use this for initialization
	public void Init (GameObject prefab, int initialAmount, bool createOnEmptyList) {
		ObjectPrefab = prefab;
		_initialAmount = initialAmount;
		_createOnEmptyList = createOnEmptyList;
		DontDestroyOnLoad(this);
		_objectList = new Queue<GameObject>();
		_objectFreeList = new List<GameObject>();

		AddToPool(_initialAmount);
	}

	private GameObject CreateObject()
	{
		GameObject obj = GameObject.Instantiate(ObjectPrefab);
		DontDestroyOnLoad(obj);
		return obj;
	}

	private void AddToPool(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			PushToPool(CreateObject());
		}
	}

	public void PushToPool(GameObject obj)
	{
		if (_objectFreeList.Contains(obj))
		{
			_objectFreeList.Remove(obj);
		}
		obj.SetActive(false);
		_objectList.Enqueue(obj);
	}

	public GameObject PullFromPool()
	{
		GameObject obj = null;
		if (_objectList.Count > 0)
		{
			obj = _objectList.Dequeue();
			_objectFreeList.Add(obj);
			obj.SetActive(true);
		}
		else
		{
			if (_createOnEmptyList)
			{
				obj = CreateObject();
				_objectFreeList.Add(obj);
				obj.SetActive(true);
			}
		}
		return obj;
	}

	public void Reset()
	{
		List<GameObject> objects = new List<GameObject>();
		foreach (GameObject obj in _objectFreeList)
		{
			objects.Add(obj);
		}
		foreach (GameObject obj in objects)
		{
			PushToPool(obj);
		}
	}
}
