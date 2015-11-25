using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickEventButtons : MonoBehaviour {

	[SerializeField] private GameObject resourceControllertje;
	[SerializeField] private GameObject _placer;

	[SerializeField] private bool _clicked = false;
	[SerializeField] private int _PlacerCost;


	private GameObject resourceGameObject;
	ResourceScript resourceScript;
	void Start()
	{
		resourceGameObject = GameObject.FindWithTag ("Resource");
		resourceScript = resourceGameObject.GetComponent<ResourceScript>();

	}
	public void HarpoonClick(GameObject objectToSpawn)
	{
		_clicked = true;
		_placer = Instantiate (objectToSpawn, Vector3.zero, Quaternion.identity) as GameObject;

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
					if (hit.transform.tag == "TurretField")
					{
						if(resourceScript.CheckForResources(_PlacerCost) == true)
						{
							Destroy (hit.transform.gameObject);
							resourceScript.RemovingResources(_PlacerCost);
							Debug.Log("Hij doet het.");
						}
						else
						{
							Destroy(_placer);	
						}
					}
					else
					{
						Destroy(_placer);
					}

				}
				_clicked = false;

			}

		}

	}
}
