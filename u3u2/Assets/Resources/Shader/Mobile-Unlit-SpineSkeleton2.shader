// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unlit alpha-blended shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Mobile/Unlit/SpineSkeleton2" {
	Properties {
		_MainTex("_MainTexture", 2D) = "black" {}
		_SubTex("_SubTexture(Alpha)", 2D) = "black" {}
	}

	SubShader {
		Tags{ "Queue"="Transparent" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "RenderType"="Transparent" }
		
		Cull Back
		ZWrite Off
		Lighting Off
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

			sampler2D _MainTex;
			sampler2D _SubTex;
			
			appdata_t vert (appdata_t v)
			{
				appdata_t o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}

			fixed4 frag (appdata_t IN) : COLOR
			{
				fixed4 col = tex2D(_MainTex, IN.texcoord);
				col.a = tex2D(_SubTex, IN.texcoord).r;
				return col;
			}
			ENDCG
		}
	}
}
