// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unlit alpha-blended shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Mobile/Unlit/Base2" {
Properties {
	_MainTexture("_MainTexture", 2D) = "black" {}
	_SubTexture("_SubTexture(Alpha)", 2D) = "black" {}
}

SubShader {
	Tags{ "Queue"="Geometry" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "RenderType"="Opaque" }
	
	Lighting Off
	Cull Back
	ZWrite On
	ZTest LEqual
	Fog{ Mode Off }
	
	Blend SrcAlpha OneMinusSrcAlpha 
	
	Pass {  
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTexture;
			sampler2D _SubTexture;
			
			appdata_t vert (appdata_t v)
			{
				appdata_t o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}
	
			fixed4 frag (appdata_t IN) : COLOR
			{
				fixed4 col = tex2D(_MainTexture, IN.texcoord);
				col.a = tex2D(_SubTexture, IN.texcoord).r;
				return col;
			}
		ENDCG
	}
}

}