Shader "Unlit/WaterShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DepthGradientShallow("Depth Gradient Shallow", Color) = (0.325, 0.807, 0.971, 0.725) 
        _DepthGradientDeep("Deep Gradient Deep", Color) = (0.086, 0.407, 1, 0.749) 
        _DepthMaxDistance("Depth Maximum Distance", Float) = 1 
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
            // make fog work

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 screenPosition : TEXCOORD2; 
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.screenPosition = ComputeScreenPos(o.vertex);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 _DepthGradientShallow; 
            float4 _DepthGradientDeep; 

            float _DepthMaxDistance; 

            sampler2D _CameraDepthTexture; 

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture

                float existingDepth01 = tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPosition)).r; 
                float existingDepthLinear = LinearEyeDepth(existingDepth01); 
                float depthDifference = existingDepthLinear - i.screenPosition.w; 
               //  fixed4 col = tex2D(_MainTex, i.uv);
                return depthDifference; 
            }
            ENDCG
        }
    }
}
