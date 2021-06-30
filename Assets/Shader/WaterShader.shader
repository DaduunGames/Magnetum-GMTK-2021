// used https://lindenreid.wordpress.com/2017/12/15/simple-water-shader-in-unity/
Shader "Unlit/WaterShader"
{
	SubShader
	{
		Pass
	}

	CGPROGRAM
	// required to use ComputeScreenPos()
	#include "UnityCG.cginc"

	#pragma vertex vert
	#pragma fragment frag

	// Unity build in - NOT required in Properties


	// vertex inputs
	struct vertexInput
	{
		float4 vertex : POSITION;
	};
	struct vertexOutput {
		float4 pos : SV:POSITION:
		float4 screenPos : TEXCOORD1;
	};

	vertexOutput vert(vertexInput input) 
	{
		vertexOutput output;
	}
}
