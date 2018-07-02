using UnityEngine;

public enum EaseFunc
{
    LINEAR = 0,
    QUADRATIC = 1,
    CUBIC = 2,
    QUARTIC = 3,
    QUINTIC = 4,
    SINUSOIDAL = 5,
    EXPONENTIAL = 6,
    CIRCULAR = 7,
    SQRT = 8
}

/* direction the eaMathf.Sing is applied (in, out, or both) */
public enum EaseDirection
{
    EASE_IN = 0,
    EASE_OUT = 1,
    EASE_IN_OUT = 2
}

public static class Easing
{
    
    /*
     * A map() replacement that allows for specifying Easing curves
     * with arbitrary exponents.
     *
     * value        :   The value to map
     * start1       :   The lower limit of the input range
     * stop1        :   The upper limit of the input range
     * start2       :   The lower limit of the output range
     * stop2        :   The upper limit of the output range
     * type         :   The type of easing (see above)
     * direction    :   One of EASE_IN, EASE_OUT, or EASE_IN_OUT
     */
    public static float Map2(float value, float start1, float stop1, float start2, float stop2, EaseFunc type, EaseDirection direction)
    {
        float b = start2;
        float c = stop2 - start2;
        float t = value - start1;
        float d = stop1 - start1;
        float p = 0.5f;
        switch (type)
        {
            case EaseFunc.LINEAR:
                return c * t / d + b;
            case EaseFunc.SQRT:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        t /= d;
                        return c * Mathf.Pow(t, p) + b;
                    case EaseDirection.EASE_OUT:
                        t /= d;
                        return c * (1 - Mathf.Pow(1 - t, p)) + b;
                    case EaseDirection.EASE_IN_OUT:
                        t /= d / 2;
                        if (t < 1) return c / 2 * Mathf.Pow(t, p) + b;
                        return c / 2 * (2 - Mathf.Pow(2 - t, p)) + b;
                }

                break;
            case EaseFunc.QUADRATIC:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        t /= d;
                        return c * t * t + b;
                    case EaseDirection.EASE_OUT:
                        t /= d;
                        return -c * t * (t - 2) + b;
                    case EaseDirection.EASE_IN_OUT:
                        t /= d / 2;
                        if (t < 1) return c / 2 * t * t + b;
                        t--;
                        return -c / 2 * (t * (t - 2) - 1) + b;
                }

                break;
            case EaseFunc.CUBIC:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        t /= d;
                        return c * t * t * t + b;
                    case EaseDirection.EASE_OUT:
                        t /= d;
                        t--;
                        return c * (t * t * t + 1) + b;
                    case EaseDirection.EASE_IN_OUT:
                        t /= d / 2;
                        if (t < 1) return c / 2 * t * t * t + b;
                        t -= 2;
                        return c / 2 * (t * t * t + 2) + b;
                }

                break;
            case EaseFunc.QUARTIC:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        t /= d;
                        return c * t * t * t * t + b;
                    case EaseDirection.EASE_OUT:
                        t /= d;
                        t--;
                        return -c * (t * t * t * t - 1) + b;
                    case EaseDirection.EASE_IN_OUT:
                        t /= d / 2;
                        if (t < 1) return c / 2 * t * t * t * t + b;
                        t -= 2;
                        return -c / 2 * (t * t * t * t - 2) + b;
                }

                break;
            case EaseFunc.QUINTIC:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        t /= d;
                        return c * t * t * t * t * t + b;
                    case EaseDirection.EASE_OUT:
                        t /= d;
                        t--;
                        return c * (t * t * t * t * t + 1) + b;
                    case EaseDirection.EASE_IN_OUT:
                        t /= d / 2;
                        if (t < 1) return c / 2 * t * t * t * t * t + b;
                        t -= 2;
                        return c / 2 * (t * t * t * t * t + 2) + b;
                }

                break;
            case EaseFunc.SINUSOIDAL:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        return -c * Mathf.Cos(t / d * (Mathf.PI / 2)) + c + b;
                    case EaseDirection.EASE_OUT:
                        return c * Mathf.Sin(t / d * (Mathf.PI / 2)) + b;
                    case EaseDirection.EASE_IN_OUT:
                        return -c / 2 * (Mathf.Cos(Mathf.PI * t / d) - 1) + b;
                }

                break;
            case EaseFunc.EXPONENTIAL:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        return c * Mathf.Pow(2, 10 * (t / d - 1)) + b;
                    case EaseDirection.EASE_OUT:
                        return c * (-Mathf.Pow(2, -10 * t / d) + 1) + b;
                    case EaseDirection.EASE_IN_OUT:
                        t /= d / 2;
                        if (t < 1) return c / 2 * Mathf.Pow(2, 10 * (t - 1)) + b;
                        t--;
                        return c / 2 * (-Mathf.Pow(2, -10 * t) + 2) + b;
                }

                break;
            case EaseFunc.CIRCULAR:
                switch (direction)
                {
                    case EaseDirection.EASE_IN:
                        t /= d;
                        return -c * (Mathf.Sqrt(1 - t * t) - 1) + b;
                    case EaseDirection.EASE_OUT:
                        t /= d;
                        t--;
                        return c * Mathf.Sqrt(1 - t * t) + b;
                    case EaseDirection.EASE_IN_OUT:
                        t /= d / 2;
                        if (t < 1) return -c / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
                        t -= 2;
                        return c / 2 * (Mathf.Sqrt(1 - t * t) + 1) + b;
                }

                break;
        };
        return 0;
    }

    /*
     * A map() replacement that allows for specifying eaMathf.Sing curves
     * with arbitrary exponents.
     * 
     * Default to EaseFunc.SQRT
     *
     * value        :   The value to map
     * start1       :   The lower limit of the input range
     * stop1        :   The upper limit of the input range
     * start2       :   The lower limit of the output range
     * stop2        :   The upper limit of the output range
     * v            :   The exponent value (e.g., 0.5, 0.1, 0.3)
     * direction    :   One of EASE_IN, EASE_OUT, or EASE_IN_OUT
     */
    public static float Map3(float value, float start1, float stop1, float start2, float stop2, float v, EaseDirection direction)
    {
        float b = start2;
        float c = stop2 - start2;
        float t = value - start1;
        float d = stop1 - start1;
        float p = v;
        float val = 0;
        switch (direction)
        {
            case EaseDirection.EASE_IN:
                t /= d;
                val = c * Mathf.Pow(t, p) + b;
                break;
            case EaseDirection.EASE_OUT:
                t /= d;
                val = c * (1 - Mathf.Pow(1 - t, p)) + b;
                break;
            case EaseDirection.EASE_IN_OUT:
                t /= d / 2;
                if (t < 1) return c / 2 * Mathf.Pow(t, p) + b;
                val = c / 2 * (2 - Mathf.Pow(2 - t, p)) + b;
                break;
        }

        return val;
    }
}