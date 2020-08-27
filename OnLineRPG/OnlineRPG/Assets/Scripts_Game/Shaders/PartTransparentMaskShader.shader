Shader "UI/PartTransparentMask"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
 
		_ColorMask ("Color Mask", Float) = 15
 
 
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
		
 
 
	//-------------------add----------------------
		[Toggle] _IsRect ("Use Rect", Int) = 1
		_RectPos("Rect Top Left", vector) = (0,0,0,0)
		_RectSize("Rect Width Height", vector) = (0,0,0,0)
        _CircleCenter("Circle Center", vector) = (0, 0, 0, 0)
        _Radius ("Circle Radius", Range (0,1000)) = 1000 // sliders
    //-------------------add----------------------
	}
 
	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}
		
		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp] 
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}
 
		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask [_ColorMask]
 
		Pass
		{
			Name "Default"
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
 
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
 
			#pragma multi_compile __ UNITY_UI_ALPHACLIP
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
 
			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
				float4 worldPosition : TEXCOORD1;
				UNITY_VERTEX_OUTPUT_STEREO
 
			};
			
			fixed4 _Color;
			fixed4 _TextureSampleAdd;
			float4 _ClipRect;
			//-------------------add----------------------
            float _Radius;
            float2 _CircleCenter;
            float _IsRect;
            float4 _RectPos;
            float4 _RectSize;
            //-------------------add----------------------
			
			float RectCheck(float2 pos, float2 leftTop, float2 size)
			{
			    if (pos.x >= leftTop.x && pos.x <= (leftTop.x + size.x)
			        && pos.y <= leftTop.y && pos.y >= (leftTop.y - size.y))
			        return 0;
			    return 1;
			}
			
			v2f vert(appdata_t IN)
			{
				v2f OUT;
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
				OUT.worldPosition = IN.vertex;
				OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
 
				OUT.texcoord = IN.texcoord;
				
				OUT.color = IN.color * _Color;
				return OUT;
			}
 
			sampler2D _MainTex;
 
			fixed4 frag(v2f IN) : SV_Target
			{
				half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;
				
				color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
				
				#ifdef UNITY_UI_ALPHACLIP
				clip (color.a - 0.001);
				#endif
				//-------------------add----------------------
				if (_IsRect == 0)
               	    color.a*=(distance(IN.worldPosition.xy, _CircleCenter.xy) > _Radius);
               	else
               	    color.a*=RectCheck(IN.worldPosition.xy, _RectPos.xy, _RectSize.xy);
               	color.rgb*= color.a;
               	//-------------------add----------------------
				return color;
			
			}
		ENDCG
		}
	}
}