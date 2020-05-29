using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto;
using System.Collections.Generic;

namespace CIPSA.M_XI.Implementation.Application.ServiceImplementation.Exercise.Shop
{
    public class ArticleApplicationService : BaseApplicationService<Article, ArticleDto>, IArticleApplicationService
    {
        #region .: Properties :.

        private readonly IArticleDomainService _articleDomainService;

        #endregion

        #region .: Constructor :.

        public ArticleApplicationService(IArticleDomainService articleDomainService)
        {
            _articleDomainService = articleDomainService;
        }

        #endregion

        #region .: Public Methods :.
        
        public ArticleDto GetByPKs(params object[] dtoId)
        {
            return MapFromEntityToDto(_articleDomainService.GetByPKs(dtoId), DomainToDtoEnum.Article);
        }

        public IEnumerable<ArticleDto> GetAll()
        {
            return MapFromEntitiesToDtos(_articleDomainService.GetAll(), DomainToDtoEnum.Article);
        }
        #endregion
    }
}
