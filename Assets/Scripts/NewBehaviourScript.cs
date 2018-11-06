using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FluentBehaviourTree;

public class NewBehaviourScript : MonoBehaviour {
    IBehaviourTreeNode tree;


	void Start () {
        var builder = new BehaviourTreeBuilder();
        tree = builder.
            Selector("mySelector").
                Do("actionx", t => {
                    Debug.Log("action x");
                    return BehaviourTreeStatus.Running;
                }).
                Sequence("mySequence").
                    Do("action1", t =>
                    {
                        Debug.Log("Action 1");
                        return BehaviourTreeStatus.Success;
                    }).
                    Do("action2", t =>
                    {
                        Debug.Log("Action 2");
                        return BehaviourTreeStatus.Success;
                    }).
                End().
            End().
            Build();
	}
	

	void Update () {
        tree.Tick(new TimeData(Time.deltaTime));
	}
}
