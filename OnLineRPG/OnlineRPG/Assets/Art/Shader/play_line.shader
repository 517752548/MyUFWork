// Shader created with Shader Forge v1.38
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Mobile/Particles/Additive,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32560,y:32670,varname:node_3138,prsc:2|emission-5100-OUT,alpha-3171-A;n:type:ShaderForge.SFN_Tex2d,id:3171,x:31918,y:33067,ptovrint:False,ptlb:Mask_Texture,ptin:_Mask_Texture,varname:node_3171,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:336575cf9bc126648a68acba4460f493,ntxv:0,isnm:False|UVIN-2553-UVOUT;n:type:ShaderForge.SFN_Color,id:9806,x:31311,y:32573,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9806,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9310344,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:5629,x:31221,y:33098,varname:node_5629,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2553,x:31498,y:33073,varname:node_2553,prsc:2,spu:-0.3,spv:0|UVIN-5629-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8701,x:31111,y:32782,ptovrint:False,ptlb:node_8701,ptin:_node_8701,varname:node_8701,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:218a212c41553a049b028f506334035c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5100,x:32001,y:32687,varname:node_5100,prsc:2|A-9806-RGB,B-8701-A;proporder:3171-9806-8701;pass:END;sub:END;*/

Shader "BGShander/play_line" {
	Properties{
		_Mask_Texture("Mask_Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,0.9310344,0,1)
		_node_8701("node_8701", 2D) = "white" {}
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
				uniform sampler2D _Mask_Texture; uniform float4 _Mask_Texture_ST;
				uniform float4 _Color;
				uniform sampler2D _node_8701; uniform float4 _node_8701_ST;
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
									float4 _node_8701_var = tex2D(_node_8701,TRANSFORM_TEX(i.uv0, _node_8701));
									float3 emissive = (_Color.rgb + _node_8701_var.a);
									float3 finalColor = emissive;
									float4 node_1514 = _Time;
									float2 node_2553 = (i.uv0 + node_1514.g*float2(-0.3,0));
									float4 _Mask_Texture_var = tex2D(_Mask_Texture,TRANSFORM_TEX(node_2553, _Mask_Texture));
									return fixed4(finalColor,_Mask_Texture_var.a);
								}
								ENDCG
							}
		}
			FallBack "Mobile/Particles/Additive"
									CustomEditor "ShaderForgeMaterialInspector"
}