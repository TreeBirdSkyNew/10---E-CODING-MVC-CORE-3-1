using _4___E_CODING_DAL;
using E_CODING_Service_Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services
{
    public class TemplateResultService : ITemplateResultService
    {
        private ITemplateResultRepository _itemplateResultRepository;

        public TemplateResultService(ITemplateResultRepository itemplateResultRepository) : base()
        {
            _itemplateResultRepository = itemplateResultRepository;
        }

        public async Task<List<TemplateResult>> GetAllTemplateResult()
        {
            return await _itemplateResultRepository.GetAllTemplateResult();
        }

        public async Task<TemplateResult> DetailTemplateResult(int id)
        {
            return await _itemplateResultRepository.DetailTemplateResult(id);
        }

        public async Task<List<TemplateResultItem>> DetailTemplateResultItems(int id)
        {
            return await _itemplateResultRepository.DetailTemplateResultItems(id);
        }
        public async Task<TemplateResultItem> DetailTemplateResultItem(int id)
        {
            return await _itemplateResultRepository.DetailTemplateResultItem(id);
        }

        public async Task<TemplateResult> CreateTemplateResult()
        {
            return await _itemplateResultRepository.CreateTemplateResult();
        }

        public async Task<TemplateResult> CreateTemplateResult(TemplateResult templateResult)
        {
            return await _itemplateResultRepository.CreateTemplateResult(templateResult);
        }

        public async Task<TemplateResultItem> CreateTemplateResultItem()
        {
            return await _itemplateResultRepository.CreateTemplateResultItem();
        }

        public async Task<TemplateResultItem> CreateTemplateResultItem(TemplateResultItem templateResultItem)
        {
            return await _itemplateResultRepository.CreateTemplateResultItem(templateResultItem);
        }

        public async Task<TemplateResult> EditTemplateResult(TemplateResult templateResult)
        {
            return await _itemplateResultRepository.EditTemplateResult(templateResult);
        }
        public async Task<TemplateResultItem> EditTemplateResultItem(TemplateResultItem templateResultItem)
        {
            return await _itemplateResultRepository.EditTemplateResultItem(templateResultItem);
        }

        public void DeleteTemplateResult(int id)
        {
            _itemplateResultRepository.DeleteTemplateResult(id);
        }

    

    }

}
