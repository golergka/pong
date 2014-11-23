using UnityEngine;
using System.Collections;

public class Field : Service
{
	public Bounds Bounds
	{
		get
		{
			return collider.bounds;
		}
	}

	public Transform LeftGoal;
	public Transform RightGoal;

	public void SetAspectRatio(float _Aspect)
	{
		var boxCollider = collider as BoxCollider;
		if (boxCollider == null)
		{
			Debug.LogError("Expected box collider!");
			return;
		}
		var size = boxCollider.size;
		var height = size.z;
		var targetWidth = height * _Aspect;
		size.x = targetWidth;
		boxCollider.size = size;
		var leftPosition = transform.position;
		var rightPosition = transform.position;
		leftPosition.x = - targetWidth / 2 - 0.5f;
		rightPosition.x = targetWidth / 2 + 0.5f;
		LeftGoal.position = leftPosition;
		RightGoal.position = rightPosition;
	}

	void Start()
	{
		SetAspectRatio(Camera.main.aspect);
	}
}
