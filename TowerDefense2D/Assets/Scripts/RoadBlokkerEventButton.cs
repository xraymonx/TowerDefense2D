using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoadBlokkerEventButton : MonoBehaviour {
	
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
		_placer = Instantiate (objectToSpawn, Vector3.zero, Quaternion.identity) as GameObject;
		_clicked = true;

		
	}
	
	void Update()
	{
		if (_clicked) {
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			position.y -= 20;
			

			
			
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				//_placer.transform.position = i;
				
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.tag == "BlokkerField")
					{
						if(resourceScript.CheckForResources(_PlacerCost) == true)
						{
							position.y += 10;
							Destroy (hit.transform.gameObject);
							resourceScript.RemovingResources(_PlacerCost);

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
			_placer.transform.position = position;
		}
		
	}
}
