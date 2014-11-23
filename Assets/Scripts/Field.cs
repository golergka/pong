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

	public float	GoalsDelta		= 0.5f;
	public int		BlocksHeight	= 10;
	public float	BlockSize		= 1f;
	public float	BlockMargin		= 0.1f;
	public float	BlockDepthDown	= -10f;
	public float	BlockDepthUp	= -3f;
	public float	MaxBallDistance = 10f;
	public float	MinBallDistance = 5f;
	public Material BlocksMaterial;

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
		leftPosition.x = - targetWidth / 2 - GoalsDelta;
		rightPosition.x = targetWidth / 2 + GoalsDelta;
		LeftGoal.position = leftPosition;
		RightGoal.position = rightPosition;
	}

	void Start()
	{
		SetAspectRatio(Camera.main.aspect);
		int blocksWidth = Mathf.CeilToInt(BlocksHeight * Camera.main.aspect);
		r_Blocks = new Transform[blocksWidth * BlocksHeight];
		for(int x = 0; x < blocksWidth; x++)
		{
			for(int y = 0; y < BlocksHeight; y++)
			{
				var block = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
				block.parent = transform;
				block.localPosition = new Vector3(
						((float) x - (float) blocksWidth / 2) * BlockSize,
						BlockDepthDown,
						((float) y - (float) BlocksHeight / 2) * BlockSize
					);
				block.localScale = new Vector3(BlockSize - BlockMargin, BlockSize - BlockMargin, BlockSize - BlockMargin);
				block.renderer.material = BlocksMaterial;
				r_Blocks[x * BlocksHeight + y] = block;
			}
		}
	}

	Transform[] r_Blocks;

	void Update()
	{
		if (r_Blocks == null)
			return;
		var ball = ServiceProvider.GetService<Game>().MainBall;
		foreach(var b in r_Blocks)
		{
			var pos = b.position;
			var flatPos = new Vector2(pos.x, pos.z);
			var flatBallPos = new Vector2(ball.transform.position.x, ball.transform.position.z);
			var sqDist = (flatPos - flatBallPos).SqrMagnitude();
			var t = (sqDist - MinBallDistance) / (MaxBallDistance - MinBallDistance);
			pos.y = Mathf.Lerp(BlockDepthUp,BlockDepthDown,t);
			b.transform.position = pos;
		}
	}
}
