using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FluentBehaviourTree;

public class NewBehaviourScript : MonoBehaviour {
    public Transform target;
    public float speed = 10f;
    private IBehaviourTreeNode tree;

	private void Start () {
        var builder = new BehaviourTreeBuilder();
        //if Dist < 0.5 doA else doB
        tree = builder.
            Selector("Find Target").
                Sequence("At Target").
                    Condition("At Target", t => {
                        Debug.Log("Is At Target");
                        var dist = Vector3.Distance(transform.position, target.position);
                        return dist < 0.5f;
                    }).
                    Do("Idle", t => {
                        Debug.Log("Idle");
                        return BehaviourTreeStatus.Success;
                    }).
                End().
                Do("Go to Target", t =>
                {
                    Debug.Log("Go to target");
                    var dist = Vector3.Distance(transform.position, target.position);
                    transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
                    return BehaviourTreeStatus.Success;
                }).
            End().
            Build();
	}
	
	private void Update () {
        tree.Tick(new TimeData(Time.deltaTime));
	}
}
