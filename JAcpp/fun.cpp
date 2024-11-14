#include "pch.h"
#include <cstdint>

extern "C" __declspec(dllexport) int addingg(int a, int b)
{
    return a / b;
}

extern "C" __declspec(dllexport)
void ApplyLaplaceFilter(unsigned char* input, unsigned char* output, int width, int height, int startY, int endY) {
    static const int laplaceKernel[3][3] = {
    { -1, -1, -1 },
    { -1,  8, -1 },
    { -1, -1, -1 }
    };

    for (int y = startY; y < endY; ++y) {
        for (int x = 1; x < width - 1; ++x) {
            for (int channel = 0; channel < 3; ++channel) {
                if (y == 0 || y == height - 1) {
                    int inputIndex = ((y * width) + x) * 3 + channel;
                    int outputIndex = ((y * width) + x) * 3 + channel;
                    output[outputIndex] = input[inputIndex];
                    continue;
                }

                int sum = 0;

                for (int ky = -1; ky <= 1; ++ky) {
                    for (int kx = -1; kx <= 1; ++kx) {
                        int pixelX = x + kx;
                        int pixelY = y + ky;
                        int inputIndex = ((pixelY * width) + pixelX) * 3 + channel;
                        int srodkowy = input[inputIndex];
                        sum += srodkowy * laplaceKernel[ky + 1][kx + 1];
                    }
                }

                int result = sum;
                if (result < 0) result = 0;
                if (result > 255) result = 255;

                int outputIndex = ((y * width) + x) * 3 + channel;
                output[outputIndex] = static_cast<unsigned char>(result);
            }
        }
    }
}
