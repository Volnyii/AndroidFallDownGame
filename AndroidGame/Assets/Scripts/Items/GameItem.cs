using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private ObjectType _objectType;

    public ObjectType ObjectType => _objectType;
    public int Value => _value; 
}
