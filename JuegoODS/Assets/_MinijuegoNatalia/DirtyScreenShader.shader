Shader "Custom/DirtyScreenShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _DirtyTex ("Dirty Texture", 2D) = "white" {}
        _TimeParam ("Time Parameter", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _DirtyTex;
            float _TimeParam;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half4 color = tex2D(_MainTex, i.uv);
                half4 dirty = tex2D(_DirtyTex, i.uv);
                return lerp(dirty, color, _TimeParam);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}

