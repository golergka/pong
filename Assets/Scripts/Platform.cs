using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
	public float Speed;

	Field m_Field;
	Field Field
	{
		get
		{
			if (m_Field == null)
			{
				m_Field = ServiceProvider.GetService<Field>();
			}
			return m_Field;
		}
	}

	PlatformController m_Controller;
	PlatformController Controller
	{
		get
		{
			if (m_Controller == null)
			{
				m_Controller = gameObject.GetComponent<PlatformController>();
			}
			return m_Controller;
		}
	}

	public void FixedUpdate()
	{
		// Create movement vector according to input
		var speed = Controller.Direction * Speed;
		var delta = speed * Time.fixedDeltaTime;

		// Limit movement by field's bounds
		var myBounds = collider.bounds;
		var fieldBounds = Field.Bounds;
		var maxDelta = fieldBounds.max.z - myBounds.max.z;
		var minDelta = fieldBounds.min.z - myBounds.min.z;
		delta = Mathf.Max(minDelta,delta);
		delta = Mathf.Min(maxDelta,delta);

		// Apply movement
		var movement = new Vector3(0,0,delta);
		transform.position += movement;
	}

}
