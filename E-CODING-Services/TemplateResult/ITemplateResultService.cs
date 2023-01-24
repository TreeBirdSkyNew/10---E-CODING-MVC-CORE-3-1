using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services
{
    public interface ITemplateResultService
    {
        Task<List<TemplateResult>> GetAllTemplateResult();
        Task<TemplateResult> DetailTemplateResult(int id);
        Task<List<TemplateResultItem>> DetailTemplateResultItems(int id);
        Task<TemplateResultItem> DetailTemplateResultItem(int id);

        Task<TemplateResult> CreateTemplateResult();
        Task<TemplateResult> CreateTemplateResult(TemplateResult templateResult);
        Task<TemplateResultItem> CreateTemplateResultItem();
        Task<TemplateResultItem> CreateTemplateResultItem(TemplateResultItem templateResultItem);

        Task<TemplateResult> EditTemplateResult(TemplateResult templateResult);
        Task<TemplateResultItem> EditTemplateResultItem(TemplateResultItem templateResultItem);

        void DeleteTemplateResult(int id);
    }
}
