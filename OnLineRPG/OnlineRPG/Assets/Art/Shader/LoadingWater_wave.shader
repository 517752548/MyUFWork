// Shader created with Shader Forge v1.38
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Mobile/Particles/Additive,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32697,y:32665,varname:node_3138,prsc:2|emission-2319-OUT,alpha-9807-OUT;n:type:ShaderForge.SFN_Tex2d,id:3931,x:32021,y:32753,ptovrint:False,ptlb:Main_Texture,ptin:_Main_Texture,varname:node_3931,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2048-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9807,x:32481,y:33044,varname:node_9807,prsc:2|A-9806-A,B-4836-OUT;n:type:ShaderForge.SFN_Panner,id:8657,x:31261,y:32306,varname:node_8657,prsc:2,spu:1,spv:0|UVIN-836-UVOUT,DIST-937-OUT;n:type:ShaderForge.SFN_TexCoord,id:836,x:30688,y:32243,varname:node_836,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:4285,x:31761,y:33111,ptovrint:False,ptlb:Noise1_Texture,ptin:_Noise1_Texture,varname:node_4285,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:438f3d4ad93cf6c4daeb0a4114301798,ntxv:0,isnm:False|UVIN-5743-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2670,x:30484,y:32693,varname:node_2670,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4030,x:31314,y:32755,varname:node_4030,prsc:2,spu:1,spv:0|UVIN-2670-UVOUT,DIST-9027-OUT;n:type:ShaderForge.SFN_Multiply,id:2319,x:32410,y:32796,varname:node_2319,prsc:2|A-3931-RGB,B-3171-RGB,C-9806-RGB;n:type:ShaderForge.SFN_Tex2d,id:3171,x:32075,y:33327,ptovrint:False,ptlb:Mask_Texture,ptin:_Mask_Texture,varname:node_3171,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4836,x:32304,y:33321,varname:node_4836,prsc:2|A-7339-OUT,B-3171-A;n:type:ShaderForge.SFN_Color,id:9806,x:32042,y:32957,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9806,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9705882,c3:0.9705882,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4886,x:31887,y:33327,ptovrint:False,ptlb:Noise2_Texture,ptin:_Noise2_Texture,varname:_node_4285_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:438f3d4ad93cf6c4daeb0a4114301798,ntxv:0,isnm:False|UVIN-4572-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5629,x:30487,y:33303,varname:node_5629,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4572,x:31667,y:33379,varname:node_4572,prsc:2,spu:0,spv:1|UVIN-2553-UVOUT,DIST-3391-OUT;n:type:ShaderForge.SFN_Multiply,id:7339,x:32075,y:33127,varname:node_7339,prsc:2|A-4285-R,B-4886-R,C-9475-OUT;n:type:ShaderForge.SFN_Slider,id:9475,x:31503,y:33273,ptovrint:False,ptlb:liang,ptin:_liang,varname:node_9475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Slider,id:493,x:30989,y:33853,ptovrint:False,ptlb:V1,ptin:_V1,varname:node_493,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Panner,id:2553,x:31222,y:33371,varname:node_2553,prsc:2,spu:1,spv:0|UVIN-5629-UVOUT,DIST-9743-OUT;n:type:ShaderForge.SFN_Slider,id:2127,x:30623,y:33696,ptovrint:False,ptlb:U1,ptin:_U1,varname:_node_493_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:3391,x:31502,y:33646,varname:node_3391,prsc:2|A-8769-T,B-493-OUT;n:type:ShaderForge.SFN_Time,id:7972,x:30689,y:33537,varname:node_7972,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9743,x:30989,y:33570,varname:node_9743,prsc:2|A-7972-T,B-2127-OUT;n:type:ShaderForge.SFN_Time,id:8769,x:31162,y:33646,varname:node_8769,prsc:2;n:type:ShaderForge.SFN_Panner,id:5743,x:31503,y:33075,varname:node_5743,prsc:2,spu:0,spv:1|UVIN-4030-UVOUT,DIST-5625-OUT;n:type:ShaderForge.SFN_Slider,id:4822,x:30729,y:32829,ptovrint:False,ptlb:U2,ptin:_U2,varname:node_4822,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:7136,x:30886,y:32955,varname:node_7136,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9027,x:31083,y:32881,varname:node_9027,prsc:2|A-4822-OUT,B-7136-T;n:type:ShaderForge.SFN_Slider,id:1716,x:30866,y:33143,ptovrint:False,ptlb:V2,ptin:_V2,varname:node_1716,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:1662,x:30994,y:33215,varname:node_1662,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5625,x:31195,y:33189,varname:node_5625,prsc:2|A-1716-OUT,B-1662-T;n:type:ShaderForge.SFN_Panner,id:2048,x:31786,y:32370,varname:node_2048,prsc:2,spu:0,spv:1|UVIN-8657-UVOUT,DIST-3311-OUT;n:type:ShaderForge.SFN_Slider,id:2611,x:30836,y:32520,ptovrint:False,ptlb:MU,ptin:_MU,varname:node_2611,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:4470,x:30975,y:32609,varname:node_4470,prsc:2;n:type:ShaderForge.SFN_Multiply,id:937,x:31214,y:32537,varname:node_937,prsc:2|A-2611-OUT,B-4470-T;n:type:ShaderForge.SFN_Slider,id:973,x:31381,y:32586,ptovrint:False,ptlb:MV,ptin:_MV,varname:node_973,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:8796,x:31499,y:32740,varname:node_8796,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3311,x:31773,y:32621,varname:node_3311,prsc:2|A-973-OUT,B-8796-T;proporder:3931-4285-3171-4886-9806-9475-493-2127-4822-1716-2611-973;pass:END;sub:END;*/

Shader "LoadingBGShander/LoadingWater_wave" {
	Properties{
		_Main_Texture("Main_Texture", 2D) = "white" {}
		_Noise1_Texture("Noise1_Texture", 2D) = "white" {}
		_Mask_Texture("Mask_Texture", 2D) = "white" {}
		_Noise2_Texture("Noise2_Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,0.9705882,0.9705882,1)
		_liang("liang", Range(0, 10)) = 0
		_V1("V1", Range(-1, 1)) = 0
		_U1("U1", Range(-1, 1)) = 0
		_U2("U2", Range(-1, 1)) = 0
		_V2("V2", Range(-1, 1)) = 0
		_MU("MU", Range(-1, 1)) = 0
		_MV("MV", Range(-1, 1)) = 0
		[HideInInspector]_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	}
		SubShader{
			Tags {
				"IgnoreProjector" = "True"
				"Queue" = "Transparent"
				"RenderType" = "Transparent"
			}
			Pass {
				Name "FORWARD"
				Tags {
					"LightMode" = "ForwardBase"
				}
				Blend SrcAlpha OneMinusSrcAlpha
				ZWrite Off

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#define UNITY_PASS_FORWARDBASE
				#include "UnityCG.cginc"
				#pragma multi_compile_fwdbase
				#pragma only_renderers d3d9 d3d11 glcore gles gles3 metal
				#pragma target 3.0
				uniform sampler2D _Main_Texture; uniform float4 _Main_Texture_ST;
				uniform sampler2D _Noise1_Texture; uniform float4 _Noise1_Texture_ST;
				uniform sampler2D _Mask_Texture; uniform float4 _Mask_Texture_ST;
				uniform float4 _Color;
				uniform sampler2D _Noise2_Texture; uniform float4 _Noise2_Texture_ST;
				uniform float _liang;
				uniform float _V1;
				uniform float _U1;
				uniform float _U2;
				uniform float _V2;
				uniform float _MU;
				uniform float _MV;
				struct VertexInput {
					float4 vertex : POSITION;
					float2 texcoord0 : TEXCOORD0;
				};
				struct VertexOutput {
					float4 pos : SV_POSITION;
					float2 uv0 : TEXCOORD0;
				};
				VertexOutput vert(VertexInput v) {
					VertexOutput o = (VertexOutput)0;
					o.uv0 = v.texcoord0;
					o.pos = UnityObjectToClipPos(v.vertex);
					return o;
				}
				float4 frag(VertexOutput i) : COLOR {
					////// Lighting:
					////// Emissive:
									float4 node_8796 = _Time;
									float4 node_4470 = _Time;
									float2 node_2048 = ((i.uv0 + (_MU*node_4470.g)*float2(1,0)) + (_MV*node_8796.g)*float2(0,1));
									float4 _Main_Texture_var = tex2D(_Main_Texture,TRANSFORM_TEX(node_2048, _Main_Texture));
									float4 _Mask_Texture_var = tex2D(_Mask_Texture,TRANSFORM_TEX(i.uv0, _Mask_Texture));
									float3 emissive = (_Main_Texture_var.rgb*_Mask_Texture_var.rgb*_Color.rgb);
									float3 finalColor = emissive;
									float4 node_1662 = _Time;
									float4 node_7136 = _Time;
									float2 node_5743 = ((i.uv0 + (_U2*node_7136.g)*float2(1,0)) + (_V2*node_1662.g)*float2(0,1));
									float4 _Noise1_Texture_var = tex2D(_Noise1_Texture,TRANSFORM_TEX(node_5743, _Noise1_Texture));
									float4 node_8769 = _Time;
									float4 node_7972 = _Time;
									float2 node_4572 = ((i.uv0 + (node_7972.g*_U1)*float2(1,0)) + (node_8769.g*_V1)*float2(0,1));
									float4 _Noise2_Texture_var = tex2D(_Noise2_Texture,TRANSFORM_TEX(node_4572, _Noise2_Texture));
									return fixed4(finalColor,(_Color.a*((_Noise1_Texture_var.r*_Noise2_Texture_var.r*_liang)*_Mask_Texture_var.a)));
								}
								ENDCG
							}
		}
			FallBack "Mobile/Particles/Additive"
									CustomEditor "ShaderForgeMaterialInspector"
}