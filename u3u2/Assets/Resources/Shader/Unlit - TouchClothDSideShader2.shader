// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Mobile/Unlit/TouchClothShader2"
{
	Properties 
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTexture("_MainTexture", 2D) = "black" {}
		_SubTexture ("_SubTexture(Alpha)", 2D) = "black" {} 
	 	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5  // 爆光度 
	}
	
	SubShader 
	{
		Tags{ "Queue"="Geometry" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "RenderType"="Opaque" }
		Pass
		{
			Lighting Off
			Cull Off
			ZWrite On
			ZTest LEqual
			Fog{ Mode Off }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			//#include "UnityCG.cginc"

			fixed4 _Color;
			sampler2D _MainTexture;
			sampler2D _SubTexture;
			fixed _Cutoff;
			
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
				float4 Tex2D1=tex2D(_MainTexture, IN.texcoord);
				Tex2D1.a = tex2D(_SubTexture, IN.texcoord).r;
				clip(Tex2D1.a - _Cutoff);
				fixed4 col = Tex2D1 * _Color * 2.2f;
				return col;
			}
			
			ENDCG
		}
	}
	Fallback "Diffuse"
}