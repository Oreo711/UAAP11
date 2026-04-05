using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DefaultNamespace.Miscellaneous
{
	public class CoroutineRunner : MonoBehaviour
	{
		public Coroutine StartCoroutine (IEnumerator coroutine)
		{
			return StartCoroutine(coroutine);
		}

		public void StopCoroutine (Coroutine coroutine)
		{
			StopCoroutine(coroutine);
		}
	}
}
