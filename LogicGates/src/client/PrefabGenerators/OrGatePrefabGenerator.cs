using System.Collections.Generic;
using JimmysUnityUtilities;
using LogicAPI.Data;
using LogicWorld.Rendering.Dynamics;
using LogicWorld.SharedCode.Components;
using UnityEngine;

namespace FoxFireFive.LogicGates.Client
{
    public class OrGatePrefabGenerator : DynamicPrefabGenerator<int>
    {
        private static readonly Color24 BlockColor = new(0xE6C600);

        protected override int GetIdentifierFor(ComponentData componentData)
        {
            return componentData.InputCount;
        }

        public override (int inputCount, int outputCount) GetDefaultPegCounts()
        {
            return (inputCount: 2, outputCount: 1);
        }

        protected override Prefab GeneratePrefabFor(int inputCount)
        {
            Block prefabBlock = new()
            {
                MeshName = "BufferBody",
                RawColor = BlockColor
            };

            ComponentOutput prefabOutput = new()
            {
                Rotation = new(90f, 0f, 0f)
            };

            List<ComponentInput> prefabInputs = [];

            if (inputCount == 3)
            {
                setBlockScaleX(1.5f);
                setOutputPositionX(0f);
                addInput(-0.5f);
                addInput(0f);
                addInput(0.5f);
            }
            else
            {
                float num = Mathf.Ceil(inputCount / 2f - 0.01f);
                float num2 = (num - 1f) / 2f;
                setBlockScaleX(num);
                setBlockPositionX(num2);
                setOutputPositionX(num2);
                float num3 = (num - 0.5f) / (inputCount - 1f);

                for (int i = 0; i < inputCount; i++)
                {
                    addInput(-0.25f + i * num3);
                }
            }

            Prefab prefab = new()
            {
                Blocks = [prefabBlock],
                Outputs = [prefabOutput],
                Inputs = [.. prefabInputs]
            };

            return prefab;

            // Helpers
            void addInput(float xPosition)
            {
                prefabInputs.Add(new()
                {
                    Position = new(xPosition, 1, -0.5f),
                    Rotation = new(-90, 0, 0),
                    Length = 0.62f
                });
            }

            void setBlockPositionX(float blockPositionX)
            {
                prefabBlock.Position = new(blockPositionX, 0f, 0f);
            }

            void setBlockScaleX(float blockScaleX)
            {
                prefabBlock.Scale = new(blockScaleX, 1f, 1f);
            }

            void setOutputPositionX(float outputPositionX)
            {
                prefabOutput.Position = new(outputPositionX, 0.5f, 0.5f);
            }
        }
    }
}