// Unlit shader. Simplest possible textured shader.
// - SUPPORTS lightmap
// - no lighting
// - no per-material color

Shader "Unlit/ColoredTexture" {
	Properties {
		_MainTexture ("Base (RGB)", 2D) = "white" {}
	}

	SubShader {
		Tags{ "Queue"="Geometry" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "RenderType"="Opaque" }
		LOD 100
		// Non-lightmapped
		Pass {
			Lighting Off
			Fog{ Mode Off }
			
			SetTexture [_MainTexture]
		}
	}
}
