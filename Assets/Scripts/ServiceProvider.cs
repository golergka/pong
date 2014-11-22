using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class ServiceProvider
{
	static Dictionary<Type,Service> m_Services = new Dictionary<Type,Service>();

	public static T GetService<T>()
		where T : Service
	{
		var type = typeof(T);
		if (!m_Services.ContainsKey(type))
		{
			var go = new GameObject("_" + type.ToString());
			var service = go.AddComponent<T>();
			m_Services[type] = service;
		}
		return (T) m_Services[type];
	}

	public static void Register(Service _Service)
	{
		m_Services[_Service.GetType()] = _Service;
	}
}
