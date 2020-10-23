// Unlit shader. Simplest possible textured shader.
// - SUPPORTS lightmap
// - no lighting
// - no per-material color

Shader "Mobile/Unlit/Base" {
Properties {
	_MainTexture ("Base (RGB)", 2D) = "white" {}
}

SubShader {
	Tags{ "Queue"="Geometry" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "RenderType"="Opaque" }
	
	// Non-lightmapped
	Pass {
		Lighting Off
		Cull Back
		ZWrite On
		ZTest LEqual
		Fog{ Mode Off }
		
		SetTexture [_MainTexture]
	}
}
}



