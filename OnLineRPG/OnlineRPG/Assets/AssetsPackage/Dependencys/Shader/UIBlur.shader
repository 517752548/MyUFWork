Shader "UI/Blur/UIBlur" {
	Properties{
		_Color("Tint", Color) = (1, 1, 1, 1)
		_BlurSize("BlurSize", Range(0, 10)) = 5.0
		_Vibrancy("Vibrancy", Range(0, 2)) = 0.2
		_Hui("Hui", Range(0, 1)) = 0.2

		[PerRendererData]_MainTex("Main Tex (RGB)", 2D) = "white" {}
		[HideInInspector]
		_StencilComp("Stencil Comparison", Float) = 8
		[HideInInspector]
		_Stencil("Stencil ID", Float) = 0
		[HideInInspector]
		_StencilOp("Stencil Operation", Float) = 0
		[HideInInspector]
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		[HideInInspector]
		_StencilReadMask("Stencil Read Mask", Float) = 255
		[HideInInspector]
		_ColorMask("Color Mask", Float) = 15
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip("Use Alpha Clip", Float) = 0
	}

		Category{

			Tags {
				"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane"
				"CanUseSpriteAtlas" = "True"
			}

			Stencil {
				Ref[_Stencil]
				Comp[_StencilComp]
				Pass[_StencilOp]
				ReadMask[_StencilReadMask]
				WriteMask[_StencilWriteMask]
			}


				Cull Off
				Lighting Off
				ZWrite Off
				ZTest[unity_GUIZTestMode]
				Blend SrcAlpha OneMinusSrcAlpha
				ColorMask[_ColorMask]


			SubShader {

			GrabPass {
				Tags { "LightMode" = "Always" }
			}
			
			// Vertical blur
			Pass {
			    Name "VERTICAL"
			    Tags { "LightMode" = "Always" }
			   
			    CGPROGRAM
			    #pragma vertex vert
			    #pragma fragment frag
			    #pragma fragmentoption ARB_precision_hint_fastest
			    #include "UnityCG.cginc"
			   
			    struct appdata_t {
			        float4 vertex : POSITION;
			        float2 texcoord: TEXCOORD0;
					float4 color    : COLOR;
			    };
			   
			    struct v2f {
			        float4 vertex : POSITION;
			        float4 uvgrab : TEXCOORD0;
					float4 color    : COLOR;
			    };

				half4 _Color;

			    v2f vert (appdata_t v) {
			        v2f o;
			        //o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vertex = UnityObjectToClipPos(v.vertex);
			        #if UNITY_UV_STARTS_AT_TOP
			        float scale = -1.0;
			        #else
			        float scale = 1.0;
			        #endif
			        o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
			        o.uvgrab.zw = o.vertex.zw;
					o.color = v.color * _Color;
			        return o;
			    }
			   
			    sampler2D _GrabTexture;
			    float4 _GrabTexture_TexelSize;
			    float _BlurSize;
			   
			    half4 frag( v2f i ) : COLOR {
			        half4 sum = half4(0,0,0,0);
					_BlurSize = _BlurSize*i.color.a;
			        #define GRABPIXEL(weight,kernely) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x, i.uvgrab.y + _GrabTexture_TexelSize.y * kernely * _BlurSize * 1.61, i.uvgrab.z, i.uvgrab.w))) * weight

			        sum += GRABPIXEL(0.05, -4.0);
			        sum += GRABPIXEL(0.09, -3.0);
			        sum += GRABPIXEL(0.12, -2.0);
			        sum += GRABPIXEL(0.15, -1.0);
			        sum += GRABPIXEL(0.18,  0.0);
			        sum += GRABPIXEL(0.15, +1.0);
			        sum += GRABPIXEL(0.12, +2.0);
			        sum += GRABPIXEL(0.09, +3.0);
			        sum += GRABPIXEL(0.05, +4.0);
			       
			        return sum;
			    }
			    
			    ENDCG
			}

			GrabPass {
			    Tags { "LightMode" = "Always" }
			}

			// Horizontal blur
			Pass {
			    Name "HORIZONTAL"
			
			    Tags { "LightMode" = "Always" }
			   
			    CGPROGRAM
			    #pragma vertex vert
			    #pragma fragment frag
			    #pragma fragmentoption ARB_precision_hint_fastest
			    #include "UnityCG.cginc"
			   
			   struct appdata_t {
			        float4 vertex : POSITION;
			        float2 texcoord: TEXCOORD0;
					float4 color    : COLOR;
			    };
			   
			    struct v2f {
			        float4 vertex : POSITION;
			        float4 uvgrab : TEXCOORD0;
					float4 color    : COLOR;
			    };

				half4 _Color;
			   
			    v2f vert (appdata_t v) {
			        v2f o;
					//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vertex = UnityObjectToClipPos(v.vertex);
			        #if UNITY_UV_STARTS_AT_TOP
			        float scale = -1.0;
			        #else
			        float scale = 1.0;
			        #endif
			        o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
			        o.uvgrab.zw = o.vertex.zw;
					o.color = v.color * _Color;
			        return o;
			    }
			   
			    sampler2D _GrabTexture;
			    float4 _GrabTexture_TexelSize;
			    float _BlurSize;
			   
			    half4 frag( v2f i ) : COLOR {
			        half4 sum = half4(0,0,0,0);
					_BlurSize = _BlurSize*i.color.a;
			        #define GRABPIXEL(weight,kernelx) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx * _BlurSize * 1.61, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w))) * weight

			        sum += GRABPIXEL(0.05, -4.0);
			        sum += GRABPIXEL(0.09, -3.0);
			        sum += GRABPIXEL(0.12, -2.0);
			        sum += GRABPIXEL(0.15, -1.0);
			        sum += GRABPIXEL(0.18,  0.0);
			        sum += GRABPIXEL(0.15, +1.0);
			        sum += GRABPIXEL(0.12, +2.0);
			        sum += GRABPIXEL(0.09, +3.0);
			        sum += GRABPIXEL(0.05, +4.0);
			       
			        return sum;
			    }
			    
			    ENDCG
			}
			  
			GrabPass {
			    Tags { "LightMode" = "Always" }
			}
			
			 //Vertical blur
			Pass {
			    Name "VERTICAL"
			    Tags { "LightMode" = "Always" }
			   
			    CGPROGRAM
			    #pragma vertex vert
			    #pragma fragment frag
			    #pragma fragmentoption ARB_precision_hint_fastest
			    #include "UnityCG.cginc"
			   
			    struct appdata_t {
			        float4 vertex : POSITION;
			        float2 texcoord: TEXCOORD0;
					float4 color    : COLOR;
			    };
			   
			    struct v2f {
			        float4 vertex : POSITION;
			        float4 uvgrab : TEXCOORD0;
					float4 color    : COLOR;
			    };

				half4 _Color;
			   
			    v2f vert (appdata_t v) {
			        v2f o;
					//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vertex = UnityObjectToClipPos(v.vertex);
			        #if UNITY_UV_STARTS_AT_TOP
			        float scale = -1.0;
			        #else
			        float scale = 1.0;
			        #endif
			        o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
			        o.uvgrab.zw = o.vertex.zw;
					o.color = v.color * _Color;
			        return o;
			    }
			   
			    sampler2D _GrabTexture;
			    float4 _GrabTexture_TexelSize;
			    float _BlurSize;
			   
			    half4 frag( v2f i ) : COLOR {
			        half4 sum = half4(0,0,0,0);
					_BlurSize = _BlurSize*i.color.a;
			        #define GRABPIXEL(weight,kernely) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x, i.uvgrab.y + _GrabTexture_TexelSize.y * kernely * _BlurSize, i.uvgrab.z, i.uvgrab.w))) * weight

			        sum += GRABPIXEL(0.05, -4.0);
			        sum += GRABPIXEL(0.09, -3.0);
			        sum += GRABPIXEL(0.12, -2.0);
			        sum += GRABPIXEL(0.15, -1.0);
			        sum += GRABPIXEL(0.18,  0.0);
			        sum += GRABPIXEL(0.15, +1.0);
			        sum += GRABPIXEL(0.12, +2.0);
			        sum += GRABPIXEL(0.09, +3.0);
			        sum += GRABPIXEL(0.05, +4.0);
			       
			        return sum;
			    }
			    
			    ENDCG
			}


			GrabPass {                         
			    Tags { "LightMode" = "Always" }
			}

			// Horizontal blur
			Pass {
			    Name "HORIZONTAL"
			
			    Tags { "LightMode" = "Always" }
			   
			    CGPROGRAM
			    #pragma vertex vert
			    #pragma fragment frag
			    #pragma fragmentoption ARB_precision_hint_fastest
			    #include "UnityCG.cginc"
			   
			    struct appdata_t {
			        float4 vertex : POSITION;
			        float2 texcoord: TEXCOORD0;
					float4 color    : COLOR;
			    };
			   
			    struct v2f {
			        float4 vertex : POSITION;
			        float4 uvgrab : TEXCOORD0;
					float4 color    : COLOR;
			    };

				half4 _Color;
			   
			    v2f vert (appdata_t v) {
			        v2f o;
					//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vertex = UnityObjectToClipPos(v.vertex);
			        #if UNITY_UV_STARTS_AT_TOP
			        float scale = -1.0;
			        #else
			        float scale = 1.0;
			        #endif
			        o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
			        o.uvgrab.zw = o.vertex.zw;
					o.color = v.color * _Color;
			        return o;
			    }
			   
			    sampler2D _GrabTexture;
			    float4 _GrabTexture_TexelSize;
			    float _BlurSize;
			   
			    half4 frag( v2f i ) : COLOR {
			        half4 sum = half4(0,0,0,0);
					_BlurSize = _BlurSize*i.color.a;
			        #define GRABPIXEL(weight,kernelx) tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx * _BlurSize, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w))) * weight

			        sum += GRABPIXEL(0.05, -4.0);
			        sum += GRABPIXEL(0.09, -3.0);
			        sum += GRABPIXEL(0.12, -2.0);
			        sum += GRABPIXEL(0.15, -1.0);
			        sum += GRABPIXEL(0.18,  0.0);
			        sum += GRABPIXEL(0.15, +1.0);
			        sum += GRABPIXEL(0.12, +2.0);
			        sum += GRABPIXEL(0.09, +3.0);
			        sum += GRABPIXEL(0.05, +4.0);
			       
			        return sum;
			    }
			    
			    ENDCG
			}

			 
			GrabPass {                         
			    Tags { "LightMode" = "Always" }
			}

			Pass {
				Name "Default"
				Tags { "LightMode" = "Always" }

				Name "Default"
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest

				#pragma target 2.0

				#include "UnityCG.cginc"
				#include "UnityUI.cginc" 

				#pragma multi_compile __ UNITY_UI_ALPHACLIP

				struct appdata_t
				{
					float4 vertex   : POSITION;
					float2 texcoord : TEXCOORD0;
					float4 color    : COLOR;

					UNITY_VERTEX_INPUT_INSTANCE_ID


				};

				struct v2f {
					float4 vertex : POSITION; 
					float4 uvgrab : TEXCOORD0; 
					float4 color    : COLOR;

					float4 worldPosition : TEXCOORD1;
					UNITY_VERTEX_OUTPUT_STEREO
				};

				half4 _Color; 
				fixed4 _TextureSampleAdd;
				float _Vibrancy;
				sampler2D _GrabTexture;
				float4 _GrabTexture_TexelSize;
				float _Hui;
				float4 _ClipRect;

				v2f vert(appdata_t v) {
					v2f o;
					o.worldPosition = v.vertex;
					//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.vertex = UnityObjectToClipPos(o.worldPosition);
 
					#if UNITY_UV_STARTS_AT_TOP
					float scale = -1.0;
					#else
					float scale = 1.0;
					#endif
					o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
					o.uvgrab.zw = o.vertex.zw;
					o.color = v.color * _Color;
					return o;

				}

				float4 frag(v2f i) : COLOR{

					half4 color = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(i.uvgrab) + _TextureSampleAdd);
					color.rgb *= 1 + _Vibrancy;
					color = color*i.color;
					color = lerp(color, i.color, _Hui);

					color.a *= UnityGet2DClipping(i.worldPosition.xy, _ClipRect);

					#ifdef UNITY_UI_ALPHACLIP
					clip(color.a - 0.001);
					#endif
					return color;
				}

				ENDCG
			}
		}
	}
}