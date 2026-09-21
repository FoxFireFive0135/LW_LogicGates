using LogicAPI.Server.Components;

namespace FoxFireFive.LogicGates.Server
{
    public class NorGate : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            for (int i = 0; i < Inputs.Count; i++)
            {
                if (Inputs[i].On)
                {
                    Outputs[0].On = false;
                    return;
                }
            }

            Outputs[0].On = true;
        }
    }
}
