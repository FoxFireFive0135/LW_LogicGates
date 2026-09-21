using LogicAPI.Server.Components;

namespace FoxFireFive.LogicGates.Server
{
    public class XnorGate : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            Outputs[0].On = Inputs[0].On == Inputs[1].On;
        }
    }
}
