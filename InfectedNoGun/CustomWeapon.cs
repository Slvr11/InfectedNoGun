using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using InfinityScript;

namespace CustomWeapon
{
    public class CustomWeapon : BaseScript
    {
        public CustomWeapon()
        {
            PlayerConnected += CustomWeapon_PlayerConnected;
        }

        void CustomWeapon_PlayerConnected(Entity obj)
        {
            obj.SpawnedPlayer += () => OnPlayerSpawned(obj);
            if (obj.SessionTeam == "axis")
            {
                obj.TakeAllWeapons();
            }
        }
        public void OnPlayerSpawned(Entity player)
        {
            if (player.SessionTeam == "axis")
            {
                player.TakeAllWeapons();
                player.GiveWeapon("flare_mp");
                player.SetOffhandPrimaryClass("flash");
                player.SetOffhandSecondaryClass("flash");
                player.SetPerk("specialty_lowprofile", true, true);
                player.SetPerk("specialty_marathon", true, true);
                player.SetPerk("specialty_finalstand", true, true);
            }
        }
    }
}

