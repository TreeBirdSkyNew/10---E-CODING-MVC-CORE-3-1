using _4___E_CODING_DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{
    public class TemplateFonctionnelRepository : ITemplateFonctionnelRepository
    {
        private readonly TemplateProjectDbContext _templateProjectDbContext;
        public TemplateFonctionnelRepository() : base()
        {
            _templateProjectDbContext = new TemplateProjectDbContext();
        }

        public async Task<List<TemplateFonctionnel>> GetAllTemplateFonctionnel()
        {
            var templateTechniques = await _templateProjectDbContext.TemplateFonctionnel.ToListAsync();
            return templateTechniques;
        }

        public async Task<TemplateFonctionnel> DetailTemplateFonctionnel(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnel.Where(m => m.TemplateFonctionnelId == id).SingleAsync();
        }

        public async Task<TemplateFonctionnelEntity> DetailTemplateFonctionnelEntity(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnelEntity.Where(m => m.TemplateFonctionnelEntityId == id).SingleAsync();
        }

        public async Task<List<TemplateFonctionnelEntity>> DetailTemplateFonctionnelEntities(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnelEntity.Where(m => m.TemplateFonctionnelId == id).ToListAsync();
        }

        public async Task<TemplateFonctionnelProperty> DetailTemplateFonctionnelProperty(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnelProperty.Where(m => m.TemplateFonctionnelPropertyId == id).SingleAsync();
        }

        public async Task<List<TemplateFonctionnelProperty>> DetailTemplateFonctionnelProperties(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnelProperty.Where(m => m.TemplateFonctionnelId == id).ToListAsync();
        }

        public async Task<TemplateFonctionnel> TemplateFonctionnelByProject(int id)
        {
            try { 
                
                TemplateFonctionnel templateFonctionnel = await _templateProjectDbContext.TemplateFonctionnel.Where(m => m.TemplateProjectId == id).SingleAsync();
                List<TemplateFonctionnelEntity> templateFonctionnelEntities = await _templateProjectDbContext.TemplateFonctionnelEntity.Where(m => m.TemplateFonctionnelId == templateFonctionnel.TemplateFonctionnelId).ToListAsync();
                templateFonctionnel.TemplateFonctionnelEntity= templateFonctionnelEntities;
                foreach (TemplateFonctionnelEntity templateFonctionnelEntity in templateFonctionnelEntities)
                {
                    List<TemplateFonctionnelProperty> TemplateFonctionnelProperties = await _templateProjectDbContext.TemplateFonctionnelProperty.Where(m => m.TemplateFonctionnelEntityId == templateFonctionnelEntity.TemplateFonctionnelEntityId).ToListAsync();
                    templateFonctionnelEntity.TemplateFonctionnelProperty = TemplateFonctionnelProperties;  
                }
                return templateFonctionnel;
            }
            catch(Exception ex) {
                return null;
            }

        }

        public async Task<TemplateFonctionnel> CreateTemplateFonctionnel()
        {
            TemplateFonctionnel templateFonctionnel = new TemplateFonctionnel();
            await Task.Delay(1);
            return templateFonctionnel;
        }

        public async Task<TemplateFonctionnel> CreateTemplateFonctionnel(TemplateFonctionnel templateFonctionnel)
        {
            _templateProjectDbContext.TemplateFonctionnel.Add(templateFonctionnel);
            await _templateProjectDbContext.SaveChangesAsync();
            return templateFonctionnel;
        }

        public async Task<TemplateFonctionnelEntity> CreateTemplateFonctionnelEntity()
        {
            TemplateFonctionnelEntity templateFonctionnelEntity = new TemplateFonctionnelEntity();
            await Task.Delay(1);
            return templateFonctionnelEntity;
        }

        public async Task<TemplateFonctionnelEntity> CreateTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            _templateProjectDbContext.TemplateFonctionnelEntity.Add(templateFonctionnelEntity);
            await _templateProjectDbContext.SaveChangesAsync();
            return templateFonctionnelEntity;
        }

        public async Task<TemplateFonctionnelProperty> CreateTemplateFonctionnelProperty()
        {
            TemplateFonctionnelProperty templateFonctionnelProperty = new TemplateFonctionnelProperty();
            await Task.Delay(1);
            return templateFonctionnelProperty;
        }

        public async Task<TemplateFonctionnelProperty> CreateTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            _templateProjectDbContext.TemplateFonctionnelProperty.Add(templateFonctionnelProperty);
            await _templateProjectDbContext.SaveChangesAsync();
            return templateFonctionnelProperty;
        }

        public async Task<TemplateFonctionnel> EditTemplateFonctionnel(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnel.Where(m => m.TemplateFonctionnelId == id).SingleAsync();
        }

        public async Task<TemplateFonctionnel> EditTemplateFonctionnel(TemplateFonctionnel templateFonctionnel)
        {
            _templateProjectDbContext.TemplateFonctionnel.Update(templateFonctionnel);
            await _templateProjectDbContext.SaveChangesAsync();
            return templateFonctionnel;
        }

        public async Task<TemplateFonctionnelEntity> EditTemplateFonctionnelEntity(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnelEntity.Where(m => m.TemplateFonctionnelEntityId == id).SingleAsync();
        }

        public async Task<TemplateFonctionnelEntity> EditTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            _templateProjectDbContext.TemplateFonctionnelEntity.Update(templateFonctionnelEntity);
             await _templateProjectDbContext.SaveChangesAsync();
            return templateFonctionnelEntity;
        }

        public async Task<TemplateFonctionnelProperty> EditTemplateFonctionnelProperty(int id)
        {
            return await _templateProjectDbContext.TemplateFonctionnelProperty.Where(m => m.TemplateFonctionnelPropertyId == id).SingleAsync();
        }

        public async Task<TemplateFonctionnelProperty> EditTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            _templateProjectDbContext.TemplateFonctionnelProperty.Update(templateFonctionnelProperty);
            await _templateProjectDbContext.SaveChangesAsync();
            return templateFonctionnelProperty;

        }
        public void DeleteTemplateFonctionnel(int id)
        {
            Task<TemplateFonctionnel> templateFonctionnel = DetailTemplateFonctionnel(id);
            _templateProjectDbContext.TemplateFonctionnel.Remove(templateFonctionnel.Result);
            _templateProjectDbContext.SaveChanges();
        }

        
    }
}
