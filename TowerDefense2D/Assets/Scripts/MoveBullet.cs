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
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);
    }
}
