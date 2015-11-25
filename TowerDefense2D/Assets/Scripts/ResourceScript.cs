using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceScript : MonoBehaviour {

	[SerializeField] private int _resources;
	[SerializeField] private Text textField;

	public bool checkResources = false;

	// Use this for initialization
	void Start () {
		_resources = 100;
		UpdateUI ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddingResources()
	{
		_resources = _resources + 100;
		UpdateUI();

	}
	public void RemovingResources(int Amount)
	{
		_resources = _resources - Amount; 
		UpdateUI ();

	}
	public bool CheckForResources(int Amount)
	{
		if (Amount <= _resources) 
		{
			return true;
		}
		else
		{
			return false;
		}

	}
	void UpdateUI()
	{
		textField.text =""+ _resources;

	}
}
