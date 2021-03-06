﻿using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{

	private int _scorePoints;
    private float _killcounter;

    private SpawnerMaster _spawnerMaster;

    public float Killcounter
    {
        get { return _killcounter; }
        private  set { _killcounter = value; }
    }

	public int ScorePoints
	{
		get { return _scorePoints; }
		private set { _scorePoints = value; }
	}

	public float Factor = 10;

	private bool _counting;

	private Score _instance = null;

	// Use this for initialization
	void Start()
	{
        _spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
        if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
			_counting = true;
			_scorePoints = 0;
		}else if (_instance != this)
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (_counting)
		{
			_scorePoints = (int)(Factor * Time.timeSinceLevelLoad);
		    _killcounter = _spawnerMaster.getKillCount();
		}
	}

	public void Stop()
	{
		_counting = false;
	}

	public void Reset()
	{
		_counting = true;
	}
}
