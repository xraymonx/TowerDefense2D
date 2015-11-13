using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    public float maxLifeTime;
    private float lifeTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
		maxLifeTime = (maxLifeTime * Time.deltaTime);

		transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);

		if (maxLifeTime == lifeTime) 
		{
			Destroy(this.gameObject);
		
		
		}
	}

    void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);
    }
}
