
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
    SQRT = 8,
}

/* direction the easing is applied (in, out, or both) */
public enum EaseDirection
{
    EASE_IN = 0,
    EASE_OUT = 1,
    EASE_IN_OUT = 2;
}
public static class Easing
{

    /*
     * A map() replacement that allows for specifying easing curves
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
    static float Map2(float value, float start1, float stop1, float start2, float stop2, int type, int direction)
    {
        float b = start2;
        float c = stop2 - start2;
        float t = value - start1;
        float d = stop1 - start1;
        float p = 0.5;
        switch (type)
        {
            case EaseFunc.LINEAR:
                return c * t / d + b;
            case EaseFunc.SQRT:
                if (direction == EaseDirection.EASE_IN)
                {
                    t /= d;
                    return c * pow(t, p) + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    t /= d;
                    return c * (1 - pow(1 - t, p)) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    t /= d / 2;
                    if (t < 1) return c / 2 * pow(t, p) + b;
                    return c / 2 * (2 - pow(2 - t, p)) + b;
                }
                break;
            case EaseFunc.QUADRATIC:
                if (direction == EaseDirection.EASE_IN)
                {
                    t /= d;
                    return c * t * t + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    t /= d;
                    return -c * t * (t - 2) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    t /= d / 2;
                    if (t < 1) return c / 2 * t * t + b;
                    t--;
                    return -c / 2 * (t * (t - 2) - 1) + b;
                }
                break;
            case EaseFunc.CUBIC:
                if (direction == EaseDirection.EASE_IN)
                {
                    t /= d;
                    return c * t * t * t + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    t /= d;
                    t--;
                    return c * (t * t * t + 1) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    t /= d / 2;
                    if (t < 1) return c / 2 * t * t * t + b;
                    t -= 2;
                    return c / 2 * (t * t * t + 2) + b;
                }
                break;
            case EaseFunc.QUARTIC:
                if (direction == EaseDirection.EASE_IN)
                {
                    t /= d;
                    return c * t * t * t * t + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    t /= d;
                    t--;
                    return -c * (t * t * t * t - 1) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    t /= d / 2;
                    if (t < 1) return c / 2 * t * t * t * t + b;
                    t -= 2;
                    return -c / 2 * (t * t * t * t - 2) + b;
                }
                break;
            case EaseFunc.QUINTIC:
                if (direction == EaseDirection.EASE_IN)
                {
                    t /= d;
                    return c * t * t * t * t * t + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    t /= d;
                    t--;
                    return c * (t * t * t * t * t + 1) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    t /= d / 2;
                    if (t < 1) return c / 2 * t * t * t * t * t + b;
                    t -= 2;
                    return c / 2 * (t * t * t * t * t + 2) + b;
                }
                break;
            case EaseFunc.SINUSOIDAL:
                if (direction == EaseDirection.EASE_IN)
                {
                    return -c * cos(t / d * (PI / 2)) + c + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    return c * sin(t / d * (PI / 2)) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    return -c / 2 * (cos(PI * t / d) - 1) + b;
                }
                break;
            case EaseFunc.EXPONENTIAL:
                if (direction == EaseDirection.EASE_IN)
                {
                    return c * pow(2, 10 * (t / d - 1)) + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    return c * (-pow(2, -10 * t / d) + 1) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    t /= d / 2;
                    if (t < 1) return c / 2 * pow(2, 10 * (t - 1)) + b;
                    t--;
                    return c / 2 * (-pow(2, -10 * t) + 2) + b;
                }
                break;
            case EaseFunc.CIRCULAR:
                if (direction == EaseDirection.EASE_IN)
                {
                    t /= d;
                    return -c * (sqrt(1 - t * t) - 1) + b;
                }
                else if (direction == EaseDirection.EASE_OUT)
                {
                    t /= d;
                    t--;
                    return c * sqrt(1 - t * t) + b;
                }
                else if (direction == EaseDirection.EASE_IN_OUT)
                {
                    t /= d / 2;
                    if (t < 1) return -c / 2 * (sqrt(1 - t * t) - 1) + b;
                    t -= 2;
                    return c / 2 * (sqrt(1 - t * t) + 1) + b;
                }
                break;
        };
        return 0;
    }

    /*
     * A map() replacement that allows for specifying easing curves
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
    static float Map3(float value, float start1, float stop1, float start2, float stop2, float v, int direction)
    {
        float b = start2;
        float c = stop2 - start2;
        float t = value - start1;
        float d = stop1 - start1;
        float p = v;
        float out = 0;
        if (direction == EaseDirection.EASE_IN)
        {
            t /= d;
            out = c * pow(t, p) + b;
        }
        else if (direction == EaseDirection.EASE_OUT)
        {
            t /= d;
            out = c * (1 - pow(1 - t, p)) + b;
        }
        else if (direction == EaseDirection.EASE_IN_OUT)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * pow(t, p) + b;
            out = c / 2 * (2 - pow(2 - t, p)) + b;
        }
        return out;
    }
}