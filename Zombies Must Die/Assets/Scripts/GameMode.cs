using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A gamemode class network object, owned and instantiated by the server
/// </summary>
public class GameMode : GameManagerBehavior
{

    // Use this for initialization
    void Start()
    {
        //safety check lol
        if (!networkObject.IsServer)
        {
            return;
        }

        NetworkManager.Instance.Networker.playerAccepted += (player, sender) =>
        {
            MainThreadManager.Run(() =>
            {
                //Do some counting logic here for a gamemode, eg, assign team to newly joined player, or restart round if enough people joined
                //Remember to remove players from counter in playerDisconnected event as well
            });
        };

        //Handle disconnection
        NetworkManager.Instance.Networker.playerDisconnected += (player, sender) =>
        {
            MainThreadManager.Run(() =>
            {
                //Loop through all players and find the player who disconnected, store all it's networkobjects to a list
                List<NetworkObject> toDelete = new List<NetworkObject>();
                foreach (var no in sender.NetworkObjectList)
                {
                    if (no.Owner == player)
                    {
                        //Found him
                        toDelete.Add(no);
                    }
                }

                //Remove the actual network object outside of the foreach loop, as we would modify the collection at runtime elsewise. (could also use a return, too late)
                if (toDelete.Count > 0)
                {
                    for (int i = toDelete.Count - 1; i >= 0; i--)
                    {
                        sender.NetworkObjectList.Remove(toDelete[i]);
                        toDelete[i].Destroy();
                    }
                }
            });
        };
    }
}