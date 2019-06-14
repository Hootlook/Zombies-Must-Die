/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using BeardedManStudios.Forge.Networking.Generated;

public class EntityBase : EntityBehavior
{

}

interface IEntityBase
{
    void OnInteract(int player);
}