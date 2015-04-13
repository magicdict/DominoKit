using BussinessLogic.Entity;
using System;

public enum InterviewProcessType
{
    /// <summary>
    /// 待面试
    /// </summary>
    [EnumDisplayName("待面试")]
    Under = 1 ,

    /// <summary>
    /// 通过
    /// </summary>
    [EnumDisplayName("通过")]
    Pass = 5 ,

    /// <summary>
    /// 待考虑
    /// </summary>
    [EnumDisplayName("待考虑")]
    Marginal = 10 ,

    /// <summary>
    /// 淘汰
    /// </summary>
    [EnumDisplayName("淘汰")]
    Failed = 15 ,

}
