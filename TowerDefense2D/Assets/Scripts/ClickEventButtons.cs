using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickEventButtons : MonoBehaviour {

	[SerializeField] private Button _myButton = null;
	[SerializeField] private GameObject _placer;

	[SerializeField] private bool _clicked = false;


	public void HarpoonClick()
	{
		_clicked = true;
		Debug.Log ("eerste klik");

	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0) && _clicked) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				if(hit.transform.tag == "TurretField")
				{
					Destroy (hit.transform.gameObject);
					Rigidbody placerInstance;
					placerInstance = Instantiate(_placer, hit.transform.position, Quaternion.Euler(0,0,0)) as Rigidbody;
					Debug.Log ("hier komt hij neer");


				}
			}
			_clicked = false;
			Debug.Log("Klik reset");
		}

	}


}
