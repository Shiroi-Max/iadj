using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbitratorManager : MonoBehaviour
{
    [SerializeField] private Arbitrator basic;
    [SerializeField] private Arbitrator following;
    private Arbitrator _actual;

    public Arbitrator Actual
    {
        get { return _actual; }
    }

    void Start()
    {
        _actual = basic;
    }

    public void StartFollowing()
    {
        _actual = following;
    }

    public void StartBasic()
    {
        _actual = basic;
    }
}
