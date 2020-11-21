using AutoMapper;
using Microsoft.AspNetCore.Http;
using YO.Framework.Dal.Repository;
using YO.Framework.Dal.UoW;

namespace YO.Framework.Api.Workflow
{
    public class BaseWorkFlow<T, TDto> : IBaseContract<TDto> where T : class where TDto : class, new()
    {
        private readonly IGenericRepository<T> _repository;
        public readonly IUoW _uow;
        private readonly IMapper _mapper;

        public BaseWorkFlow(IGenericRepository<T> repository, IUoW UoW, IMapper mapper)
        {
            _repository = repository;
            _uow = UoW;
            _mapper = mapper;
        }

        public ServiceResponse<TDto> Add(TDto item)
        {
            var result = new ServiceResponse<TDto> { IsStatus = true };

            var entity = _mapper.Map<T>(item);

            _repository.Add(entity);

            result.Data = item;
            result.Message = "success";
            result.StatusCode = StatusCodes.Status200OK;

            return result;
        }
    }
}
