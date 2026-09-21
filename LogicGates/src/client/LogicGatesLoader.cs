using EccsLogicWorldAPI.Client.Hooks;
using LogicAPI.Client;
using LogicWorld;
using System;

namespace FoxFireFive.LogicGates.Client
{
    public class LogicGatesLoader : ClientMod
    {
        protected override void Initialize()
        {
            WorldHook.worldLoading += () =>
            {
                try
                {
                    EditNandGateMenu.Setup();
                }
                catch (Exception e)
                {
                    Logger.Error("Could not setup NAND Gate UI");
                    SceneAndNetworkManager.TriggerErrorScreen(e);
                }

                try
                {
                    EditNorGateMenu.Setup();
                }
                catch (Exception e)
                {
                    Logger.Error("Could not setup NOR Gate UI");
                    SceneAndNetworkManager.TriggerErrorScreen(e);
                }

                try
                {
                    EditOrGateMenu.Setup();
                }
                catch (Exception e)
                {
                    Logger.Error("Could not setup OR Gate UI");
                    SceneAndNetworkManager.TriggerErrorScreen(e);
                }
            };
        }
    }
}