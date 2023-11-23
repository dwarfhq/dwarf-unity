using UnityEngine;
/// <summary>
/// Wrapper to spring utils to make it easier to use.
/// </summary>
public class SpringUtilsWrapper
{
    private readonly SpringUtils.DampedSpringMotionParams _springParams;
    float _currentVelocity;

    public SpringUtilsWrapper()
    {
        _springParams = new SpringUtils.DampedSpringMotionParams();
    }

    public float UpdateSpring(float current, float target, float frequency, float dampingRatio)
    {
        return UpdateSpring(current, target, Time.deltaTime, frequency, dampingRatio);
    }

    public float UpdateSpring(float currentPosition, float target, float deltaTime, float frequency, float dampingRatio)
    {
        SpringUtils.CalcDampedSpringMotionParams(_springParams, deltaTime, frequency, dampingRatio);
        var (positon, velocity) = SpringUtils.UpdateDampedSpringMotion(currentPosition, _currentVelocity, target, _springParams);
        _currentVelocity = velocity;
        return positon;
    }
}
