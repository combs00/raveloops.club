# RaveLoops FX – MadMapper Surface 2D FX

GLSL Surface 2D effect for MadMapper (Quad, Triangle, Circle surfaces). Adds optional **RGB chromatic shift**, **scanlines**, **hue shift**, and **glow** on top of your content.

## Parameters

| Parameter       | Description                          |
|----------------|--------------------------------------|
| **RGB Shift**  | Red/blue chromatic offset (0 = off)  |
| **Scanlines**  | Intensity of moving scanlines        |
| **Scanline Speed** | Speed of scanline motion         |
| **Hue Shift**  | Rotate hue 0–1 (one full cycle)     |
| **Glow**       | Brighten the image                  |

## Installation

1. **Thumbnail**  
   MadMapper needs a thumbnail for the FX. Add an image named exactly **`thumbnail.png`** or **`thumbnail.jpg`** into this folder (e.g. 256×256). You can copy one from another FX in MadMapper’s built-in materials, or use any square image.

2. **Copy the folder**  
   Copy the whole **`RaveLoops_FX`** folder (containing `RaveLoops_FX.fs` and `thumbnail.png`) into MadMapper’s **Surface FX** folder:
   - **macOS**: `~/Documents/MadMapper/Materials/Surface 2D FX/` (or path shown in MadMapper → Preferences).
   - **Windows**: Check MadMapper preferences or documentation for the Materials / Surface FX path.

3. **Reload**  
   Restart MadMapper or use the option to reload materials. The effect should appear in the Surface FX list for Quad, Triangle, and Circle surfaces.

## Usage

1. Create or select a **Quad**, **Triangle**, or **Circle** surface.
2. Assign your input (video, Syphon, etc.) as usual.
3. Add **Surface FX** and choose **RaveLoops_FX** (or the name shown in the list).
4. Adjust the parameters in the FX panel.

## Requirements

- MadMapper version that supports custom Surface FX (see [MadMapper Materials](https://github.com/madmappersoftware/MadMapper-Materials)).
- Surface type: **2D** (Quad, Triangle, Circle). Not for 3D or Line surfaces.

## Shader format

- Single fragment shader (`.fs`); no vertex shader.
- Uses MadMapper’s `fxColorForPixel(vec2 mm_FragNormCoord)` and `FX_NORM_PIXEL()`.
- Includes `MadCommon.glsl` for HSV helpers (PI, etc.).
- ISF-style header with INPUTS and a `time_base` GENERATOR for scanline animation.
