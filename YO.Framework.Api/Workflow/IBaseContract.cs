namespace YO.Framework.Api.Workflow
{
    public interface IBaseContract<TDto> where TDto : new()
    {
        #region PostMethods
        ServiceResponse<TDto> Add(TDto item);
        #endregion
    }
}
