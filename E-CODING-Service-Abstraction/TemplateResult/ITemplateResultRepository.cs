using _4___E_CODING_DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{
    public interface ITemplateResultRepository
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
        
        public void DeleteTemplateResult(int id);
        

    }
}
