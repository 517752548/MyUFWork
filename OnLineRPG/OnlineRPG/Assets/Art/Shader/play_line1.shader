// Shader created with Shader Forge v1.38
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Mobile/Particles/Additive,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32915,y:32781,varname:node_3138,prsc:2|emission-635-OUT,alpha-4836-OUT;n:type:ShaderForge.SFN_Tex2d,id:3931,x:31484,y:32393,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_3931,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:218a212c41553a049b028f506334035c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4285,x:31659,y:32914,ptovrint:False,ptlb:Noise1_Texture,ptin:_Noise1_Texture,varname:node_4285,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:438f3d4ad93cf6c4daeb0a4114301798,ntxv:0,isnm:False|UVIN-4030-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2670,x:30928,y:32820,varname:node_2670,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4030,x:31380,y:32836,varname:node_4030,prsc:2,spu:0.2,spv:0.1|UVIN-2670-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3171,x:31928,y:33642,ptovrint:False,ptlb:Mask_Texture,ptin:_Mask_Texture,varname:node_3171,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:336575cf9bc126648a68acba4460f493,ntxv:0,isnm:False|UVIN-2630-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4836,x:32498,y:33470,varname:node_4836,prsc:2|A-7339-OUT,B-3171-A,C-9940-A;n:type:ShaderForge.SFN_Tex2d,id:4886,x:31804,y:33338,ptovrint:False,ptlb:Noise2_Texture,ptin:_Noise2_Texture,varname:_node_4285_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:438f3d4ad93cf6c4daeb0a4114301798,ntxv:0,isnm:False|UVIN-2553-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5629,x:30841,y:33234,varname:node_5629,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7339,x:32089,y:33092,varname:node_7339,prsc:2|A-4285-R,B-4886-R,C-9475-OUT;n:type:ShaderForge.SFN_Slider,id:9475,x:31375,y:33198,ptovrint:False,ptlb:liang,ptin:_liang,varname:node_9475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Panner,id:2553,x:31359,y:33339,varname:node_2553,prsc:2,spu:0.2,spv:0.1|UVIN-5629-UVOUT;n:type:ShaderForge.SFN_Panner,id:2630,x:31585,y:33578,varname:node_2630,prsc:2,spu:-0.3,spv:0|UVIN-4903-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4903,x:31195,y:33598,varname:node_4903,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:635,x:32371,y:32554,varname:node_635,prsc:2|A-3931-A,B-4422-RGB;n:type:ShaderForge.SFN_Color,id:4422,x:31575,y:32622,ptovrint:False,ptlb:MainColor,ptin:_MainColor,varname:node_4422,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5620689,c2:1,c3:0.06617647,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9940,x:31928,y:33873,ptovrint:False,ptlb:node_9940,ptin:_node_9940,varname:node_9940,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:995ed90e00fdbac40895efdaa227ec98,ntxv:0,isnm:False;proporder:3931-4285-3171-4886-9475-4422-9940;pass:END;sub:END;*/

Shader "BGShander/play_line1" {
	Properties{
		_MainTex("MainTex", 2D) = "white" {}
		_Noise1_Texture("Noise1_Texture", 2D) = "white" {}
		_Mask_Texture("Mask_Texture", 2D) = "white" {}
		_Noise2_Texture("Noise2_Texture", 2D) = "white" {}
		_liang("liang", Range(0, 10)) = 0
		_MainColor("MainColor", Color) = (0.5620689,1,0.06617647,1)
		_node_9940("node_9940", 2D) = "white" {}
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
				uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
				uniform sampler2D _Noise1_Texture; uniform float4 _Noise1_Texture_ST;
				uniform sampler2D _Mask_Texture; uniform float4 _Mask_Texture_ST;
				uniform sampler2D _Noise2_Texture; uniform float4 _Noise2_Texture_ST;
				uniform float _liang;
				uniform float4 _MainColor;
				uniform sampler2D _node_9940; uniform float4 _node_9940_ST;
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
									float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
									float3 emissive = (_MainTex_var.a + _MainColor.rgb);
									float3 finalColor = emissive;
									float4 node_892 = _Time;
									float2 node_4030 = (i.uv0 + node_892.g*float2(0.2,0.1));
									float4 _Noise1_Texture_var = tex2D(_Noise1_Texture,TRANSFORM_TEX(node_4030, _Noise1_Texture));
									float2 node_2553 = (i.uv0 + node_892.g*float2(0.2,0.1));
									float4 _Noise2_Texture_var = tex2D(_Noise2_Texture,TRANSFORM_TEX(node_2553, _Noise2_Texture));
									float2 node_2630 = (i.uv0 + node_892.g*float2(-0.3,0));
									float4 _Mask_Texture_var = tex2D(_Mask_Texture,TRANSFORM_TEX(node_2630, _Mask_Texture));
									float4 _node_9940_var = tex2D(_node_9940,TRANSFORM_TEX(i.uv0, _node_9940));
									return fixed4(finalColor,((_Noise1_Texture_var.r*_Noise2_Texture_var.r*_liang)*_Mask_Texture_var.a*_node_9940_var.a));
								}
								ENDCG
							}
		}
			FallBack "Mobile/Particles/Additive"
									CustomEditor "ShaderForgeMaterialInspector"
}