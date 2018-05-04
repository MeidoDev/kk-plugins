using BepInEx;
using System;
using System.Collections;

namespace NoVampire
{
    [BepInPlugin(GUID: "meidodev.kk.no-vampire", Name: "NoVampire", Version: "1.0")]
    public class NoVampire : BaseUnityPlugin
	{
        void Awake()
        {
            Hooks.InstallHooks();
        }
	}
}