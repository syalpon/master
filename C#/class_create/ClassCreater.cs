class ClassCreater
{
    private Field _field;
    private string _className;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="classname"></param>
    public ClassCreater(string className)
    {
        _className = className;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="field"></param>
    public void AddField(Field field)
    {
        _field = field;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetClassName()
    {
        return _className;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Field GetField()
    {
        return _field;
    }
}