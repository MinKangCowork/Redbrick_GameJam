using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChainable 
{
    public enum ESynergy
    {
        Human,
        Spirit,
        Animal,
        Malloc
    }
    public ESynergy SynergyType { get; set; }
    public List<IChainable> NearSynergy {  get; set; }
    public void Chain(int count);
    public void Synergy();
}