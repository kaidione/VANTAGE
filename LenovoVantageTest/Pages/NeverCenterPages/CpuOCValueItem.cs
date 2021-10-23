using System.Collections.Generic;

public class OCValueItem
{
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string NotOCValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string OCValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string MinValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string MaxValue { get; set; }
}

public class GamingOCValueList
{
    /// <summary>
    /// 
    /// </summary>
    public string Familyname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<OCValueItem> OCValue { get; set; }
}

public class OCListRoot
{
    /// <summary>
    /// 
    /// </summary>
    public List<GamingOCValueList> GamingOCList { get; set; }
}
