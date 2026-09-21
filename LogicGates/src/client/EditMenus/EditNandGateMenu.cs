using EccsGuiBuilder.Client.Layouts.Helper;
using EccsGuiBuilder.Client.Wrappers;
using EccsGuiBuilder.Client.Wrappers.AutoAssign;
using LogicAPI.Data.BuildingRequests;
using LogicSettings;
using LogicUI.MenuParts;
using LogicWorld.BuildingManagement;
using LogicWorld.UI;
using System.Collections.Generic;

namespace FoxFireFive.LogicGates.Client
{
    public class EditNandGateMenu : EditComponentMenu, IAssignMyFields
    {
        [AssignMe]
        public InputSlider InputCountSlider;

        [Setting_Secret("FoxFireFive.LogicGates.Secret.MaxPegsAllowed_NandGate")]
        private static int MaxPegs { get; set; } = 4;

        public static void Setup()
        {
            WS.window("FoxFireFive.LogicGates.NandGate")
            .setYPosition(150)
            .configureContent(content => content
                .layoutVerticalInnerCentered()
                .add(WS.textLine.setLocalizationKey("FoxFireFive.LogicGates.EditMenu.InputCount"))
                .add(WS.slider.injectionKey(nameof(InputCountSlider)).setInterval(1).setMin(2).setMax(MaxPegs).fixedSize(500, 45))
            ).add<EditNandGateMenu>().build();
        }

        protected override void OnStartEditing()
        {
            InputCountSlider.SetValueWithoutNotify(FirstComponentBeingEdited.Component.Data.InputCount);
        }

        public override void Initialize()
        {
            base.Initialize();
            InputCountSlider.OnValueChangedInt += value =>
            {
                BuildRequestManager.SendBuildRequest(new BuildRequest_ChangeDynamicComponentPegCounts(FirstComponentBeingEdited.Address, value, 1));
            };
        }

        protected override IEnumerable<string> GetTextIDsOfComponentTypesThatCanBeEdited()
        {
            yield return "FoxFireFive.LogicGates.NandGate";
        }
    }
}