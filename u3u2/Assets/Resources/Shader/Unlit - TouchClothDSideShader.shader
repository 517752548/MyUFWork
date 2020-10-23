// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Mobile/Unlit/TouchClothDSideShader"
{
Properties 
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTexture("_MainTexture", 2D) = "black" {}
	}
	
	SubShader 
	{
		Tags{ "Queue"="Geometry" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "RenderType"="Opaque" }
		Pass
		{
			Lighting Off
			Cull Off
			ZWrite On
			Fog{ Mode Off }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			//#include "UnityCG.cginc"

			fixed4 _Color;
			sampler2D _MainTexture;

			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			appdata_t vert (appdata_t v)
			{
				appdata_t o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}

			fixed4 frag (appdata_t IN) : COLOR
			{
				fixed4 col = tex2D(_MainTexture, IN.texcoord) * _Color * 2.2f;
				return col;
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
}