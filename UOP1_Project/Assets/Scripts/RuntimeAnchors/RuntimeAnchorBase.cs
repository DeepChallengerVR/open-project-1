﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.Events;

public class RuntimeAnchorBase<T> : DescriptionBaseSO where T : UnityEngine.Object
{
	[HideInInspector] public bool isSet = false; // Any script can check if the transform is null before using it, by just checking this bool

	public UnityAction AnchorProvided;

	private T _value;
	public T Value
	{
		get { return _value; }
		set
		{
			_value = value;
			isSet = _value != null;
			
			//Notify whoever is waiting for this anchor
			if(AnchorProvided != null)
			{
				AnchorProvided.Invoke();
				Debug.Log(AnchorProvided.GetInvocationList()[0].Method.Name);
			}
			
		}
	}

	public void OnDisable()
	{
		_value = null;
		isSet = false;
	}
}