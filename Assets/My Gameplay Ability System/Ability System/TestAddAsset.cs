using System.Collections;
using System.Collections.Generic;
using AbilitySystem;
using AbilitySystem.Authoring;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay Ability System/TestAddAsset")]
public class TestAddAsset : ScriptableObject
{
    [SerializeField]
    protected Projectile projectile;
    [SerializeField]
    public string name;
    [SerializeField]
    public string age;
}

