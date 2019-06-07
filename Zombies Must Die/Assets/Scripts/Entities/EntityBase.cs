using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : EntityBehavior
{

}

interface IEntityBase
{
    void OnInteract(Transform from);
}