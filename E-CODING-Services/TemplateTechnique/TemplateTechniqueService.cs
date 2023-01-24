using _4___E_CODING_DAL;
using E_CODING_Service_Abstraction;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services
{
    public class TemplateTechniqueService : ITemplateTechniqueService
    {
 
        private ITemplateTechniqueRepository _itemplateTechniqueRepository;

        public TemplateTechniqueService(ITemplateTechniqueRepository itemplateTechniqueRepository) : base()
        {
            _itemplateTechniqueRepository = itemplateTechniqueRepository;
        }

        public async Task<TemplateTechnique> CreateTemplateTechnique()
        {
            return await _itemplateTechniqueRepository.CreateTemplateTechnique();
        }
        
        public async Task<TemplateTechnique> CreateTemplateTechnique(TemplateTechnique templateTechnique)
        {
             return await _itemplateTechniqueRepository.CreateTemplateTechnique(templateTechnique);
        }

        public async Task<TemplateTechniqueItem> CreateTemplateTechniqueItem()
        {
            return await _itemplateTechniqueRepository.CreateTemplateTechniqueItem();
        }

        public async Task<TemplateTechniqueItem> CreateTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            return await _itemplateTechniqueRepository.CreateTemplateTechniqueItem(templateTechniqueItem);
        }

        public async Task<TemplateTechnique> DetailTemplateTechnique(int id)
        {
            return await _itemplateTechniqueRepository.DetailTemplateTechnique(id);
        }

        public async Task<TemplateTechniqueItem> DetailTemplateTechniqueItem(int id)
        {
            return await _itemplateTechniqueRepository.DetailTemplateTechniqueItem(id);
        }

        public async Task<List<TemplateTechniqueItem>> DetailTemplateTechniqueItems(int id)
        {
            return await _itemplateTechniqueRepository.DetailTemplateTechniqueItems(id);
        }

        public async Task<List<TemplateTechnique>> GetAllTemplateTechnique()
        {
            return await _itemplateTechniqueRepository.GetAllTemplateTechnique();
        }

        public async Task<List<TemplateTechnique>> TemplateTechniqueByProject(int id)
        {
            return await _itemplateTechniqueRepository.TemplateTechniqueByProject(id);
        }

        public void DeleteTemplateTechnique(int id)
        {
            _itemplateTechniqueRepository.DeleteTemplateTechnique(id);
        }

        public void DeleteTemplateTechniqueItem(int id)
        {
            _itemplateTechniqueRepository.DeleteTemplateTechniqueItem(id);
        }

        public async Task<TemplateTechnique> EditTemplateTechnique(int id)
        {
           return  await _itemplateTechniqueRepository.EditTemplateTechnique(id);
        }

        public async Task<TemplateTechnique> EditTemplateTechnique(TemplateTechnique templateTechnique)
        {
            return await _itemplateTechniqueRepository.EditTemplateTechnique(templateTechnique);
        }

        public async Task<TemplateTechniqueItem> EditTemplateTechniqueItem(int id)
        {
            return await _itemplateTechniqueRepository.EditTemplateTechniqueItem(id);
        }

        public async Task<TemplateTechniqueItem> EditTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            return await _itemplateTechniqueRepository.EditTemplateTechniqueItem(templateTechniqueItem);
        }

        

        
    }
}
