using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	[SerializeField] private float _speed;
	private float _ScreenWidth;
	private Vector3 _CameraPos;
	private Camera _Camera;


	// Use this for initialization
	void Start () {
	
		_ScreenWidth = Screen.width;
		_Camera = Camera.main;
		_CameraPos = _Camera.transform.position;
	}

	
	// Update is called once per frame
	void Update () {
	
		_Camera.transform.position = _CameraPos;
		MouseScrolling ();
	}
	void MouseScrolling()
	{
		if (Input.mousePosition.x <= _ScreenWidth - _ScreenWidth) 
		{
			//Debug.Log ("hey");
			_CameraPos.x -= _speed;

		}
	
		if(Input.mousePosition.x >= _ScreenWidth)
		{
			//Debug.Log("hey2");
			_CameraPos.x += _speed;

		}

	}
}
