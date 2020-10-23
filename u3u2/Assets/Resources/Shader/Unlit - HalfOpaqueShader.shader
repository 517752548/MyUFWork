// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Mobile/Unlit/HalfOpaqueShader"
{
    Properties {
        _MainTexture ("_MainTexture", 2D) = "white" {}
    }
    SubShader {
        Tags{ "Queue"="Transparent" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "RenderType"="Transparent" }
        Pass
        {
            ZWrite On
            ColorMask 0
        }

        Pass
        {
            Lighting Off
            Cull Back
            ZWrite On
            //ZTest LEqual
            Fog{ Mode Off }
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag			
            //#include "UnityCG.cginc"
    
            sampler2D _MainTexture;
    
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                //fixed4 color : COLOR;
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
                fixed4 col = tex2D(_MainTexture, IN.texcoord);
                col.a = 0.4;
                return col;
            }
            ENDCG
        } 
    }
    Fallback "Diffuse"
}