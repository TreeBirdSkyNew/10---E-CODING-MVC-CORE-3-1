using _4___E_CODING_DAL;
using E_CODING_Service_Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services
{
    public class TemplateFonctionnelService : ITemplateFonctionnelService
    {
        private ITemplateFonctionnelRepository _itemplateFonctionnelRepository;

        public TemplateFonctionnelService(ITemplateFonctionnelRepository itemplateFonctionnelRepository) : base()
        {
            _itemplateFonctionnelRepository = itemplateFonctionnelRepository;
        }

        public async Task<List<TemplateFonctionnel>> GetAllTemplateFonctionnel()
        {
            return await _itemplateFonctionnelRepository.GetAllTemplateFonctionnel();
        }

        public async Task<TemplateFonctionnel> DetailTemplateFonctionnel(int id)
        {
            return await _itemplateFonctionnelRepository.DetailTemplateFonctionnel(id);
        }

        public async Task<TemplateFonctionnelEntity> DetailTemplateFonctionnelEntity(int id)
        {
            return await _itemplateFonctionnelRepository.DetailTemplateFonctionnelEntity(id);
        }

        public async Task<List<TemplateFonctionnelEntity>> DetailTemplateFonctionnelEntities(int id)
        {
            return await _itemplateFonctionnelRepository.DetailTemplateFonctionnelEntities(id);
        }

        public async Task<TemplateFonctionnelProperty> DetailTemplateFonctionnelProperty(int id)
        {
            return await _itemplateFonctionnelRepository.DetailTemplateFonctionnelProperty(id);
        }

        public async Task<List<TemplateFonctionnelProperty>> DetailTemplateFonctionnelProperties(int id)
        {
            return await _itemplateFonctionnelRepository.DetailTemplateFonctionnelProperties(id);
        }

        public async Task<TemplateFonctionnel> TemplateFonctionnelByProject(int id)
        {
            return await _itemplateFonctionnelRepository.TemplateFonctionnelByProject(id);
        }
        


        public async Task<TemplateFonctionnel> CreateTemplateFonctionnel()
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.CreateTemplateFonctionnel();
        }

        public async Task<TemplateFonctionnel> CreateTemplateFonctionnel(TemplateFonctionnel templateFonctionnel)
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.CreateTemplateFonctionnel(templateFonctionnel);
        }

        public async Task<TemplateFonctionnelEntity> CreateTemplateFonctionnelEntity()
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.CreateTemplateFonctionnelEntity();
        }

        public async Task<TemplateFonctionnelEntity> CreateTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.CreateTemplateFonctionnelEntity(templateFonctionnelEntity);
        }

        public async Task<TemplateFonctionnelProperty> CreateTemplateFonctionnelProperty()
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.CreateTemplateFonctionnelProperty();
        }

        public async Task<TemplateFonctionnelProperty> CreateTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.CreateTemplateFonctionnelProperty(templateFonctionnelProperty);
        }

        public async Task<TemplateFonctionnel> EditTemplateFonctionnel(TemplateFonctionnel templateFonctionnel)
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.EditTemplateFonctionnel(templateFonctionnel);
        }

        public async Task<TemplateFonctionnelEntity> EditTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.EditTemplateFonctionnelEntity(templateFonctionnelEntity);
        }

        public async Task<TemplateFonctionnelProperty> EditTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            await Task.Delay(1);
            return await _itemplateFonctionnelRepository.EditTemplateFonctionnelProperty(templateFonctionnelProperty);
        }

        public void DeleteTemplateFonctionnel(int id)
        {
            _itemplateFonctionnelRepository.DeleteTemplateFonctionnel(id);
        }

        public async Task<TemplateFonctionnel> EditTemplateFonctionnel(int id)
        {
            return await _itemplateFonctionnelRepository.DetailTemplateFonctionnel(id);
        }

        public async Task<TemplateFonctionnelEntity> EditTemplateFonctionnelEntity(int id)
        {
            return await _itemplateFonctionnelRepository.EditTemplateFonctionnelEntity(id);
        }

        public async Task<TemplateFonctionnelProperty> EditTemplateFonctionnelProperty(int id)
        {
            return await _itemplateFonctionnelRepository.EditTemplateFonctionnelProperty(id);
        }
    }
}
