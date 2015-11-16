using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickEventButtons : MonoBehaviour {


	[SerializeField] private GameObject _placer;

	[SerializeField] private bool _clicked = false;


	public void HarpoonClick(GameObject objectToSpawn)
	{
		_clicked = true;
		_placer = Instantiate (objectToSpawn, Vector3.zero, Quaternion.identity) as GameObject;
		//Debug.Log ("eerste klik");



	}

	void Update()
	{
		if (_clicked) {
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			position.y -= 10;

			_placer.transform.position = position;


			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				//_placer.transform.position = i;
				
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.tag == "TurretField") {
						Destroy (hit.transform.gameObject);
						//Debug.Log ("hier komt hij neer");
						
						
					}
					else
					{
						Destroy(_placer);
						
					}
				}


				_clicked = false;
				//Debug.Log ("Klik reset");


			}

		}

	}
}
