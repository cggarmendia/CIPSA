using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop
{
    public interface IArticleApplicationService
    {
        IEnumerable<ArticleDto> GetAll();

        ArticleDto GetByPKs(params object[] keyValues);
    }
}
