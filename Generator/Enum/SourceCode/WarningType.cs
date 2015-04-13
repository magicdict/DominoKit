using BussinessLogic.Entity;
using System;

public enum WarningType
{
    /// <summary>
    /// 无
    /// </summary>
    [EnumDisplayName("无")]
    none ,

    /// <summary>
    /// 主要
    /// </summary>
    [EnumDisplayName("主要")]
    primary ,

    /// <summary>
    /// 成功
    /// </summary>
    [EnumDisplayName("成功")]
    success ,

    /// <summary>
    /// 信息
    /// </summary>
    [EnumDisplayName("信息")]
    info ,

    /// <summary>
    /// 警告
    /// </summary>
    [EnumDisplayName("警告")]
    warning ,

    /// <summary>
    /// 危险
    /// </summary>
    [EnumDisplayName("危险")]
    danger ,

}
