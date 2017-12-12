using System;
using UnityEngine;

namespace UnityEditor.VFX
{
    [VFXInfo(category = "Utility")]
    class VFXOperatorSampleTexture2DArray : VFXOperator
    {
        override public string name { get { return "Sample Texture2DArray"; } }

        public class InputProperties
        {
            [Tooltip("The texture to sample from.")]
            public Texture2DArray texture = null;
            [Tooltip("The texture coordinate used for the sampling.")]
            public Vector2 uv = Vector2.zero;
            [Min(0), Tooltip("The array slice to sample from.")]
            public float slice = 0.0f;
            [Min(0), Tooltip("The mip level to sample from.")]
            public float mipLevel = 0.0f;
        }

        override protected VFXExpression[] BuildExpression(VFXExpression[] inputExpression)
        {
            if (inputExpression.Length != 4)
            {
                return new VFXExpression[] {};
            }

            return new[] { new VFXExpressionSampleTexture2DArray(inputExpression[0], inputExpression[1], inputExpression[2], inputExpression[3]) };
        }
    }
}
