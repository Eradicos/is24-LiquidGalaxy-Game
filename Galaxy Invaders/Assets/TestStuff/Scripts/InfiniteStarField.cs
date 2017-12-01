using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InfiniteStarField : MonoBehaviour {

    private Transform thisTransform;
    private ParticleSystem.Particle[] points;
    public ParticleSystem particleSystem;

    public int maxStars = 1000;
    public float starSize = 0.2f;
    public int starDistance = 100;
    public int starClipDistance = 10;

    private float starDistanceSqr;
    private float starClipDistanceSqr;

	// Use this for initialization
	void Start () {
        thisTransform = transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
    }
	
	// Update is called once per frame
	void Update () {
        if (points == null) createStars();

        for (int i = 0; i < maxStars; i++)
        {
            
            if ((points[i].position - thisTransform.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + thisTransform.position;
            }

            if ((points[i].position - thisTransform.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - thisTransform.position).sqrMagnitude / starClipDistanceSqr;
                points[i].color = new Color(1, 1, 1, percent);
                points[i].size = starSize * percent;
            }
        }

        particleSystem.SetParticles(points, points.Length);

	}

    private void createStars()
    {
        points = new ParticleSystem.Particle[maxStars];

        for (int i = 0; i < maxStars; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + thisTransform.position;
            points[i].startColor = new Color(1,1,1,1);
            points[i].startSize = starSize;
        }
    }
}
