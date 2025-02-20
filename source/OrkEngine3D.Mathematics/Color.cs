﻿// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Globalization;
namespace OrkEngine3D.Mathematics
{
    /// <summary>
    /// Represents a 32-bit color (4 bytes) in the form of RGBA (in byte order: R, G, B, A).
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public partial struct Color : IEquatable<Color>, IFormattable
    {

        /// <summary>
        /// The red component of the color.
        /// </summary>
        public byte Red;

        /// <summary>
        /// The green component of the color.
        /// </summary>
        public byte Green;

        /// <summary>
        /// The blue component of the color.
        /// </summary>
        public byte Blue;

        /// <summary>
        /// The alpha component of the color.
        /// </summary>
        public byte Alpha;

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="value">The value that will be assigned to all components.</param>
        public Color(byte value)
        {
            Red = value;
            Green = value;
            Blue = value;
            Alpha = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="value">The value that will be assigned to all components.</param>
        public Color(float value) : this(ToByte(value))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.  Alpha is set to 255.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = 255;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public Color(float red, float green, float blue, float alpha)
        {
            Red = ToByte(red);
            Green = ToByte(green);
            Blue = ToByte(blue);
            Alpha = ToByte(alpha);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.  Alpha is set to 255.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        public Color(float red, float green, float blue)
        {
            Red = ToByte(red);
            Green = ToByte(green);
            Blue = ToByte(blue);
            Alpha = 255;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="value">The red, green, blue, and alpha components of the color.</param>
        public Color(Vector4 value)
        {
            Red = ToByte(value.X);
            Green = ToByte(value.Y);
            Blue = ToByte(value.Z);
            Alpha = ToByte(value.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="value">The red, green, and blue components of the color.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public Color(Vector3 value, float alpha)
        {
            Red = ToByte(value.X);
            Green = ToByte(value.Y);
            Blue = ToByte(value.Z);
            Alpha = ToByte(alpha);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct. Alpha is set to 255.
        /// </summary>
        /// <param name="value">The red, green, and blue components of the color.</param>
        public Color(Vector3 value)
        {
            Red = ToByte(value.X);
            Green = ToByte(value.Y);
            Blue = ToByte(value.Z);
            Alpha = 255;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="rgba">A packed integer containing all four color components in RGBA order.</param>
        public Color(uint rgba)
        {
            Alpha = (byte)((rgba >> 24) & 255);
            Blue = (byte)((rgba >> 16) & 255);
            Green = (byte)((rgba >> 8) & 255);
            Red = (byte)(rgba & 255);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="rgba">A packed integer containing all four color components in RGBA order.</param>
        public Color(int rgba)
        {
            Alpha = (byte)((rgba >> 24) & 255);
            Blue = (byte)((rgba >> 16) & 255);
            Green = (byte)((rgba >> 8) & 255);
            Red = (byte)(rgba & 255);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="values">The values to assign to the red, green, and blue, alpha components of the color. This must be an array with four elements.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="values"/> contains more or less than four elements.</exception>
        public Color(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length != 4)
                throw new ArgumentOutOfRangeException(nameof(values), "There must be four and only four input values for Color.");

            Red = ToByte(values[0]);
            Green = ToByte(values[1]);
            Blue = ToByte(values[2]);
            Alpha = ToByte(values[3]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="values">The values to assign to the red, green, blue, or alpha components of the color. This must be an array with four elements.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="values"/> contains more or less than four elements.</exception>
        public Color(byte[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length != 4)
                throw new ArgumentOutOfRangeException(nameof(values), "There must be four and only four input values for Color.");

            Red = values[0];
            Green = values[1];
            Blue = values[2];
            Alpha = values[3];
        }

        /// <summary>
        /// Gets or sets the component at the specified index.
        /// </summary>
        /// <value>The value of the red, green, blue, or alpha component, depending on the index.</value>
        /// <param name="index">The index of the component to access. Use 0 for the red(R) component, 1 for the green(G) component, 2 for the blue(B) component, and 3 for the alpha(A) component.</param>
        /// <returns>The value of the component at the specified index.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <paramref name="index"/> is out of the range [0, 3].</exception>
        public byte this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Red;
                    case 1: return Green;
                    case 2: return Blue;
                    case 3: return Alpha;
                }

                throw new ArgumentOutOfRangeException(nameof(index), "Indices for Color run from 0 to 3, inclusive.");
            }

            set
            {
                switch (index)
                {
                    case 0: Red = value; break;
                    case 1: Green = value; break;
                    case 2: Blue = value; break;
                    case 3: Alpha = value; break;
                    default: throw new ArgumentOutOfRangeException(nameof(index), "Indices for Color run from 0 to 3, inclusive.");
                }
            }
        }

        /// <summary>
        /// Converts the color into a packed integer.
        /// </summary>
        /// <returns>A packed integer containing all four color components.</returns>
        public int ToBgra()
        {
            int value = Blue;
            value |= Green << 8;
            value |= Red << 16;
            value |= Alpha << 24;

            return value;
        }

        /// <summary>
        /// Converts the color into a packed integer.
        /// </summary>
        /// <returns>A packed integer containing all four color components.</returns>
        public int ToRgba()
        {
            int value = Red;
            value |= Green << 8;
            value |= Blue << 16;
            value |= Alpha << 24;

            return value;
        }

        /// <summary>
        /// Converts the color into a packed integer.
        /// </summary>
        /// <returns>A packed integer containing all four color components.</returns>
        public int ToArgb()
        {
            int value = Alpha;
            value |= Red << 8;
            value |= Green << 16;
            value |= Blue << 24;

            return value;
        }

        /// <summary>
        /// Converts the color into a packed integer.
        /// </summary>
        /// <returns>A packed integer containing all four color components.</returns>
        public int ToAbgr()
        {
            int value = Alpha;
            value |= Blue << 8;
            value |= Green << 16;
            value |= Red << 24;

            return value;
        }

        /// <summary>
        /// Converts the color into a three component vector.
        /// </summary>
        /// <returns>A three component vector containing the red, green, and blue components of the color.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(Red / 255.0f, Green / 255.0f, Blue / 255.0f);
        }

        /// <summary>
        /// Converts the color into a three component color.
        /// </summary>
        /// <returns>A three component color containing the red, green, and blue components of the color.</returns>
        public Color3 ToColor3()
        {
            return new Color3(Red / 255.0f, Green / 255.0f, Blue / 255.0f);
        }

        /// <summary>
        /// Converts the color into a four component vector.
        /// </summary>
        /// <returns>A four component vector containing all four color components.</returns>
        public Vector4 ToVector4()
        {
            return new Vector4(Red / 255.0f, Green / 255.0f, Blue / 255.0f, Alpha / 255.0f);
        }

        /// <summary>
        /// Creates an array containing the elements of the color.
        /// </summary>
        /// <returns>A four-element array containing the components of the color in RGBA order.</returns>
        public byte[] ToArray()
        {
            return new[] { Red, Green, Blue, Alpha };
        }

        /// <summary>
        /// Gets the brightness.
        /// </summary>
        /// <returns>The Hue-Saturation-Brightness (HSB) saturation for this <see cref="Color"/></returns>
        public float GetBrightness()
        {
            float r = Red / 255.0f;
            float g = Green / 255.0f;
            float b = Blue / 255.0f;

            float max, min;

            max = r;
            min = r;

            if (g > max) max = g;
            if (b > max) max = b;

            if (g < min) min = g;
            if (b < min) min = b;

            return (max + min) / 2;
        }

        /// <summary>
        /// Gets the hue.
        /// </summary>
        /// <returns>The Hue-Saturation-Brightness (HSB) saturation for this <see cref="Color"/></returns>
        public float GetHue()
        {
            if (Red == Green && Green == Blue)
                return 0; // 0 makes as good an UNDEFINED value as any

            float r = Red / 255.0f;
            float g = Green / 255.0f;
            float b = Blue / 255.0f;

            float max, min;
            float delta;
            float hue = 0.0f;

            max = r;
            min = r;

            if (g > max) max = g;
            if (b > max) max = b;

            if (g < min) min = g;
            if (b < min) min = b;

            delta = max - min;

            if (r == max)
            {
                hue = (g - b) / delta;
            }
            else if (g == max)
            {
                hue = 2 + (b - r) / delta;
            }
            else if (b == max)
            {
                hue = 4 + (r - g) / delta;
            }
            hue *= 60;

            if (hue < 0.0f)
            {
                hue += 360.0f;
            }
            return hue;
        }

        /// <summary>
        /// Gets the saturation.
        /// </summary>
        /// <returns>The Hue-Saturation-Brightness (HSB) saturation for this <see cref="Color"/></returns>
        public float GetSaturation()
        {
            float r = Red / 255.0f;
            float g = Green / 255.0f;
            float b = Blue / 255.0f;

            float max, min;
            float l, s = 0;

            max = r;
            min = r;

            if (g > max) max = g;
            if (b > max) max = b;

            if (g < min) min = g;
            if (b < min) min = b;

            // if max == min, then there is no color and
            // the saturation is zero.
            if (max != min)
            {
                l = (max + min) / 2;

                if (l <= .5)
                {
                    s = (max - min) / (max + min);
                }
                else
                {
                    s = (max - min) / (2 - max - min);
                }
            }
            return s;
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <param name="result">When the method completes, completes the sum of the two colors.</param>
        public static void Add(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (byte)(left.Alpha + right.Alpha);
            result.Red = (byte)(left.Red + right.Red);
            result.Green = (byte)(left.Green + right.Green);
            result.Blue = (byte)(left.Blue + right.Blue);
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <returns>The sum of the two colors.</returns>
        public static Color Add(Color left, Color right)
        {
            return new Color((byte)(left.Red + right.Red), (byte)(left.Green + right.Green), (byte)(left.Blue + right.Blue), (byte)(left.Alpha + right.Alpha));
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract.</param>
        /// <param name="result">WHen the method completes, contains the difference of the two colors.</param>
        public static void Subtract(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (byte)(left.Alpha - right.Alpha);
            result.Red = (byte)(left.Red - right.Red);
            result.Green = (byte)(left.Green - right.Green);
            result.Blue = (byte)(left.Blue - right.Blue);
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract</param>
        /// <returns>The difference of the two colors.</returns>
        public static Color Subtract(Color left, Color right)
        {
            return new Color((byte)(left.Red - right.Red), (byte)(left.Green - right.Green), (byte)(left.Blue - right.Blue), (byte)(left.Alpha - right.Alpha));
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <param name="result">When the method completes, contains the modulated color.</param>
        public static void Modulate(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (byte)(left.Alpha * right.Alpha / 255);
            result.Red = (byte)(left.Red * right.Red / 255);
            result.Green = (byte)(left.Green * right.Green / 255);
            result.Blue = (byte)(left.Blue * right.Blue / 255);
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <returns>The modulated color.</returns>
        public static Color Modulate(Color left, Color right)
        {
            return new Color((byte)(left.Red * right.Red / 255), (byte)(left.Green * right.Green / 255), (byte)(left.Blue * right.Blue / 255), (byte)(left.Alpha * right.Alpha / 255));
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The color to scale.</param>
        /// <param name="scale">The amount by which to scale.</param>
        /// <param name="result">When the method completes, contains the scaled color.</param>
        public static void Scale(ref Color value, float scale, out Color result)
        {
            result.Alpha = (byte)(value.Alpha * scale);
            result.Red = (byte)(value.Red * scale);
            result.Green = (byte)(value.Green * scale);
            result.Blue = (byte)(value.Blue * scale);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The color to scale.</param>
        /// <param name="scale">The amount by which to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color Scale(Color value, float scale)
        {
            return new Color((byte)(value.Red * scale), (byte)(value.Green * scale), (byte)(value.Blue * scale), (byte)(value.Alpha * scale));
        }

        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <param name="result">When the method completes, contains the negated color.</param>
        public static void Negate(ref Color value, out Color result)
        {
            result.Alpha = (byte)(255 - value.Alpha);
            result.Red = (byte)(255 - value.Red);
            result.Green = (byte)(255 - value.Green);
            result.Blue = (byte)(255 - value.Blue);
        }

        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <returns>The negated color.</returns>
        public static Color Negate(Color value)
        {
            return new Color((byte)(255 - value.Red), (byte)(255 - value.Green), (byte)(255 - value.Blue), (byte)(255 - value.Alpha));
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="result">When the method completes, contains the clamped value.</param>
        public static void Clamp(ref Color value, ref Color min, ref Color max, out Color result)
        {
            byte alpha = value.Alpha;
            alpha = (alpha > max.Alpha) ? max.Alpha : alpha;
            alpha = (alpha < min.Alpha) ? min.Alpha : alpha;

            byte red = value.Red;
            red = (red > max.Red) ? max.Red : red;
            red = (red < min.Red) ? min.Red : red;

            byte green = value.Green;
            green = (green > max.Green) ? max.Green : green;
            green = (green < min.Green) ? min.Green : green;

            byte blue = value.Blue;
            blue = (blue > max.Blue) ? max.Blue : blue;
            blue = (blue < min.Blue) ? min.Blue : blue;

            result = new Color(red, green, blue, alpha);
        }

        /// <summary>
        /// Converts the color from a packed BGRA integer.
        /// </summary>
        /// <param name="color">A packed integer containing all four color components in BGRA order</param>
        /// <returns>A color.</returns>
        public static Color FromBgra(int color)
        {
            return new Color((byte)((color >> 16) & 255), (byte)((color >> 8) & 255), (byte)(color & 255), (byte)((color >> 24) & 255));
        }

        /// <summary>
        /// Converts the color from a packed BGRA integer.
        /// </summary>
        /// <param name="color">A packed integer containing all four color components in BGRA order</param>
        /// <returns>A color.</returns>
        public static Color FromBgra(uint color)
        {
            return FromBgra(unchecked((int)color));
        }

        /// <summary>
        /// Converts the color from a packed ABGR integer.
        /// </summary>
        /// <param name="color">A packed integer containing all four color components in ABGR order</param>
        /// <returns>A color.</returns>
        public static Color FromAbgr(int color)
        {
            return new Color((byte)(color >> 24), (byte)(color >> 16), (byte)(color >> 8), (byte)color);
        }

        /// <summary>
        /// Converts the color from a packed ABGR integer.
        /// </summary>
        /// <param name="color">A packed integer containing all four color components in ABGR order</param>
        /// <returns>A color.</returns>
        public static Color FromAbgr(uint color)
        {
            return FromAbgr(unchecked((int)color));
        }

        /// <summary>
        /// Converts the color from a packed RGBA integer.
        /// </summary>
        /// <param name="color">A packed integer containing all four color components in RGBA order</param>
        /// <returns>A color.</returns>
        public static Color FromRgba(int color)
        {
            return new Color(color);
        }

        /// <summary>
        /// Converts the color from a packed RGBA integer.
        /// </summary>
        /// <param name="color">A packed integer containing all four color components in RGBA order</param>
        /// <returns>A color.</returns>
        public static Color FromRgba(uint color)
        {
            return new Color(color);
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static Color Clamp(Color value, Color min, Color max)
        {
            Color result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }

        /// <summary>
        /// Performs a linear interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the linear interpolation of the two colors.</param>
        /// <remarks>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static void Lerp(ref Color start, ref Color end, float amount, out Color result)
        {
            result.Red = MathUtil.Lerp(start.Red, end.Red, amount);
            result.Green = MathUtil.Lerp(start.Green, end.Green, amount);
            result.Blue = MathUtil.Lerp(start.Blue, end.Blue, amount);
            result.Alpha = MathUtil.Lerp(start.Alpha, end.Alpha, amount);
        }

        /// <summary>
        /// Performs a linear interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The linear interpolation of the two colors.</returns>
        /// <remarks>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static Color Lerp(Color start, Color end, float amount)
        {
            Color result;
            Lerp(ref start, ref end, amount, out result);
            return result;
        }

        /// <summary>
        /// Performs a cubic interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the cubic interpolation of the two colors.</param>
        public static void SmoothStep(ref Color start, ref Color end, float amount, out Color result)
        {
            amount = MathUtil.SmoothStep(amount);
            Lerp(ref start, ref end, amount, out result);
        }

        /// <summary>
        /// Performs a cubic interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The cubic interpolation of the two colors.</returns>
        public static Color SmoothStep(Color start, Color end, float amount)
        {
            Color result;
            SmoothStep(ref start, ref end, amount, out result);
            return result;
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <param name="result">When the method completes, contains an new color composed of the largest components of the source colors.</param>
        public static void Max(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (left.Alpha > right.Alpha) ? left.Alpha : right.Alpha;
            result.Red = (left.Red > right.Red) ? left.Red : right.Red;
            result.Green = (left.Green > right.Green) ? left.Green : right.Green;
            result.Blue = (left.Blue > right.Blue) ? left.Blue : right.Blue;
        }

        /// <summary>
        /// Returns a color containing the largest components of the specified colorss.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <returns>A color containing the largest components of the source colors.</returns>
        public static Color Max(Color left, Color right)
        {
            Color result;
            Max(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <param name="result">When the method completes, contains an new color composed of the smallest components of the source colors.</param>
        public static void Min(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (left.Alpha < right.Alpha) ? left.Alpha : right.Alpha;
            result.Red = (left.Red < right.Red) ? left.Red : right.Red;
            result.Green = (left.Green < right.Green) ? left.Green : right.Green;
            result.Blue = (left.Blue < right.Blue) ? left.Blue : right.Blue;
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <returns>A color containing the smallest components of the source colors.</returns>
        public static Color Min(Color left, Color right)
        {
            Color result;
            Min(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Adjusts the contrast of a color.
        /// </summary>
        /// <param name="value">The color whose contrast is to be adjusted.</param>
        /// <param name="contrast">The amount by which to adjust the contrast.</param>
        /// <param name="result">When the method completes, contains the adjusted color.</param>
        public static void AdjustContrast(ref Color value, float contrast, out Color result)
        {
            result.Alpha = value.Alpha;
            result.Red = ToByte(0.5f + contrast * (value.Red / 255.0f - 0.5f));
            result.Green = ToByte(0.5f + contrast * (value.Green / 255.0f - 0.5f));
            result.Blue = ToByte(0.5f + contrast * (value.Blue / 255.0f - 0.5f));
        }

        /// <summary>
        /// Adjusts the contrast of a color.
        /// </summary>
        /// <param name="value">The color whose contrast is to be adjusted.</param>
        /// <param name="contrast">The amount by which to adjust the contrast.</param>
        /// <returns>The adjusted color.</returns>
        public static Color AdjustContrast(Color value, float contrast)
        {
            return new Color(
                ToByte(0.5f + contrast * (value.Red / 255.0f - 0.5f)),
                ToByte(0.5f + contrast * (value.Green / 255.0f - 0.5f)),
                ToByte(0.5f + contrast * (value.Blue / 255.0f - 0.5f)),
                value.Alpha);
        }

        /// <summary>
        /// Adjusts the saturation of a color.
        /// </summary>
        /// <param name="value">The color whose saturation is to be adjusted.</param>
        /// <param name="saturation">The amount by which to adjust the saturation.</param>
        /// <param name="result">When the method completes, contains the adjusted color.</param>
        public static void AdjustSaturation(ref Color value, float saturation, out Color result)
        {
            float grey = value.Red / 255.0f * 0.2125f + value.Green / 255.0f * 0.7154f + value.Blue / 255.0f * 0.0721f;

            result.Alpha = value.Alpha;
            result.Red = ToByte(grey + saturation * (value.Red / 255.0f - grey));
            result.Green = ToByte(grey + saturation * (value.Green / 255.0f - grey));
            result.Blue = ToByte(grey + saturation * (value.Blue / 255.0f - grey));
        }

        /// <summary>
        /// Adjusts the saturation of a color.
        /// </summary>
        /// <param name="value">The color whose saturation is to be adjusted.</param>
        /// <param name="saturation">The amount by which to adjust the saturation.</param>
        /// <returns>The adjusted color.</returns>
        public static Color AdjustSaturation(Color value, float saturation)
        {
            float grey = value.Red / 255.0f * 0.2125f + value.Green / 255.0f * 0.7154f + value.Blue / 255.0f * 0.0721f;

            return new Color(
                ToByte(grey + saturation * (value.Red / 255.0f - grey)),
                ToByte(grey + saturation * (value.Green / 255.0f - grey)),
                ToByte(grey + saturation * (value.Blue / 255.0f - grey)),
                value.Alpha);
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <returns>The sum of the two colors.</returns>
        public static Color operator +(Color left, Color right)
        {
            return new Color((byte)(left.Red + right.Red), (byte)(left.Green + right.Green), (byte)(left.Blue + right.Blue), (byte)(left.Alpha + right.Alpha));
        }

        /// <summary>
        /// Assert a color (return it unchanged).
        /// </summary>
        /// <param name="value">The color to assert (unchanged).</param>
        /// <returns>The asserted (unchanged) color.</returns>
        public static Color operator +(Color value)
        {
            return value;
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract.</param>
        /// <returns>The difference of the two colors.</returns>
        public static Color operator -(Color left, Color right)
        {
            return new Color((byte)(left.Red - right.Red), (byte)(left.Green - right.Green), (byte)(left.Blue - right.Blue), (byte)(left.Alpha - right.Alpha));
        }

        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <returns>A negated color.</returns>
        public static Color operator -(Color value)
        {
            return new Color(-value.Red, -value.Green, -value.Blue, -value.Alpha);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="scale">The factor by which to scale the color.</param>
        /// <param name="value">The color to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color operator *(float scale, Color value)
        {
            return new Color((byte)(value.Red * scale), (byte)(value.Green * scale), (byte)(value.Blue * scale), (byte)(value.Alpha * scale));
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The factor by which to scale the color.</param>
        /// <param name="scale">The color to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color operator *(Color value, float scale)
        {
            return new Color((byte)(value.Red * scale), (byte)(value.Green * scale), (byte)(value.Blue * scale), (byte)(value.Alpha * scale));
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <returns>The modulated color.</returns>
        public static Color operator *(Color left, Color right)
        {
            return new Color((byte)(left.Red * right.Red / 255.0f), (byte)(left.Green * right.Green / 255.0f), (byte)(left.Blue * right.Blue / 255.0f), (byte)(left.Alpha * right.Alpha / 255.0f));
        }

        /// <summary>
        /// Tests for equality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> has the same value as <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests for inequality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> has a different value than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Color left, Color right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Color"/> to <see cref="Color3"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color3(Color value)
        {
            return value.ToColor3();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Color"/> to <see cref="Vector3"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Vector3(Color value)
        {
            return new Vector3(value.Red / 255.0f, value.Green / 255.0f, value.Blue / 255.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Color"/> to <see cref="Vector4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Vector4(Color value)
        {
            return new Vector4(value.Red / 255.0f, value.Green / 255.0f, value.Blue / 255.0f, value.Alpha / 255.0f);
        }

        /// <summary>
        /// Convert this instance to a <see cref="Color4"/>
        /// </summary>
        /// <returns>The result of the conversion.</returns>
        public Color4 ToColor4()
        {
            return new Color4(Red / 255.0f, Green / 255.0f, Blue / 255.0f, Alpha / 255.0f);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Color"/> to <see cref="Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Color4(Color value)
        {
            return value.ToColor4();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Vector3"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(Vector3 value)
        {
            return new Color(value.X, value.Y, value.Z, 1.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Color3"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(Color3 value)
        {
            return new Color(value.Red, value.Green, value.Blue, 1.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Vector4"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(Vector4 value)
        {
            return new Color(value.X, value.Y, value.Z, value.W);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Color4"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(Color4 value)
        {
            return new Color(value.Red, value.Green, value.Blue, value.Alpha);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="int"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator int(Color value)
        {
            return value.ToRgba();
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="int"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator Color(int value)
        {
            return new Color(value);
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ColorExtensions.RgbaToString(ToRgba());
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Alpha.GetHashCode() + Red.GetHashCode() + Green.GetHashCode() + Blue.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="Color"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Color"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Color"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Color other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to this instance.
        /// </summary>
        /// <param name="value">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            if (!ReferenceEquals(value.GetType(), typeof(Color)))
                return false;

            return Equals((Color)value);
        }

        private static byte ToByte(float component)
        {
            var value = (int)(component * 255.0f);
            return (byte)(value < 0 ? 0 : value > 255 ? 255 : value);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
