/*{
  "CREDIT": "RaveLoops.Club",
  "CATEGORIES": [ "Stylize", "Rave" ],
  "VSN": 1,
  "INPUTS": [
    {
      "NAME": "fx_rgb_shift",
      "LABEL": "RGB Shift",
      "TYPE": "float",
      "DEFAULT": 0.02,
      "MIN": 0.0,
      "MAX": 0.15
    },
    {
      "NAME": "fx_scanlines",
      "LABEL": "Scanlines",
      "TYPE": "float",
      "DEFAULT": 0.0,
      "MIN": 0.0,
      "MAX": 1.0
    },
    {
      "NAME": "fx_scanline_speed",
      "LABEL": "Scanline Speed",
      "TYPE": "float",
      "DEFAULT": 2.0,
      "MIN": 0.0,
      "MAX": 10.0
    },
    {
      "NAME": "fx_hue_shift",
      "LABEL": "Hue Shift",
      "TYPE": "float",
      "DEFAULT": 0.0,
      "MIN": 0.0,
      "MAX": 1.0
    },
    {
      "NAME": "fx_glow",
      "LABEL": "Glow",
      "TYPE": "float",
      "DEFAULT": 0.0,
      "MIN": 0.0,
      "MAX": 1.0
    }
  ],
  "GENERATORS": [
    {
      "NAME": "fx_phase",
      "TYPE": "time_base",
      "PARAMS": { "speed": "fx_scanline_speed", "speed_curve": 2 }
    }
  ]
}*/

#include "MadCommon.glsl"

vec4 fxColorForPixel(vec2 mm_FragNormCoord) {
  vec2 uv = mm_FragNormCoord;
  vec2 px = 1.0 / FX_IMG_SIZE();

  // Chromatic offset (R/G/B sample at slightly different positions)
  float r = FX_NORM_PIXEL(uv + vec2(fx_rgb_shift, 0.0)).r;
  float g = FX_NORM_PIXEL(uv).g;
  float b = FX_NORM_PIXEL(uv - vec2(fx_rgb_shift, 0.0)).b;
  float a = FX_NORM_PIXEL(uv).a;
  vec4 color = vec4(r, g, b, a);

  // Optional hue shift
  if (fx_hue_shift > 0.001) {
    vec3 hsv = rgb2hsv(color.rgb);
    hsv.x = fract(hsv.x + fx_hue_shift);
    color.rgb = hsv2rgb(hsv);
  }

  // Scanlines (moving with time)
  if (fx_scanlines > 0.001) {
    float scan = sin((uv.y + fx_phase) * 3.14159265 * 120.0) * 0.5 + 0.5;
    color.rgb = mix(color.rgb, color.rgb * (1.0 - scan), fx_scanlines);
  }

  // Simple glow (brighten)
  if (fx_glow > 0.001) {
    color.rgb = color.rgb + color.rgb * fx_glow;
  }

  return color;
}
