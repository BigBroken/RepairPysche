#ifndef FLIPUTILITIES_INCLUDED
#define FLIPUTILITIES_INCLUDED

void CalculateFlip_float(float2 InUV, float2 ObjectPosition, float ScreenWidth, float ScreenHeight, bool FlipX, bool FlipY, out float2 Out)
{
    float2 result = InUV;
    float nox = ObjectPosition.x / ScreenWidth;
    float noy = ObjectPosition.y / ScreenHeight;

    if (FlipX) {
        result.x = -(result.x - nox) + nox;
    }

    if (FlipY) {
        result.y = -(result.y - noy) + noy;
    }
    
    Out = result;
}

#endif // FLIPUTILITIES_INCLUDED
