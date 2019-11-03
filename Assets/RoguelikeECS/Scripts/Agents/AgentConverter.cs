using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class AgentConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    public float maxHealth;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new AgentComponent());
        dstManager.AddComponentData(entity, new HealthComponent(){health = maxHealth});
    }
}
