using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EntryPoint : MonoBehaviour
{
	private void Awake ()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
}
