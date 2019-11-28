using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Patrol : MonoBehaviour
{
	private NavMeshAgent agent;

	private int currentWaypoint =0;

	[SerializeField] private Transform[] wayPoints;
	private void Awake()
	{
		currentWaypoint = 0;
		if (this.agent==null)
		{
			this.agent = GetComponent<NavMeshAgent>();
		}
	}

	private void Start()
	{
		this.agent.SetDestination(this.wayPoints[this.currentWaypoint].position);
		Debug.Log(this.currentWaypoint);
	}

	private void Update()
	{
		if(Math.Abs(this.transform.position.x - wayPoints[currentWaypoint].position.x) < 0.5f && Math.Abs(this.transform.position.z - wayPoints[currentWaypoint].position.z) < 0.5f)
		{
			this.currentWaypoint++;
			this.currentWaypoint %= wayPoints.Length;
			Debug.Log(currentWaypoint);
			this.agent.SetDestination(this.wayPoints[this.currentWaypoint].position);
		}
	}

	public void Respawn()
	{
		this.currentWaypoint = Random.Range(0, this.wayPoints.Length);
		this.transform.position = this.wayPoints[this.currentWaypoint].position;
		this.currentWaypoint++;
		this.currentWaypoint %= wayPoints.Length;
		this.agent.SetDestination(this.wayPoints[this.currentWaypoint].position);
		Debug.Log("Respawn done at "+this.transform.position);
	}
}
