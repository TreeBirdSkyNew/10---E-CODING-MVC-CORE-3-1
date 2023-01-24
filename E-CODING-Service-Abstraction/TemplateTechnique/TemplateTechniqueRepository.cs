using _4___E_CODING_DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{
    public class TemplateTechniqueRepository : ITemplateTechniqueRepository
    {
        private readonly TemplateProjectDbContext _templateProjectDbContext;
        public TemplateTechniqueRepository() : base()
        {
            _templateProjectDbContext = new TemplateProjectDbContext();
        }

        public async Task<List<TemplateTechnique>> GetAllTemplateTechnique()
        {
            try
            {
                var templateTechniques = await _templateProjectDbContext.TemplateTechnique.ToListAsync();
                return templateTechniques;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<List<TemplateTechnique>> TemplateTechniqueByProject(int id)
        {
            try
            {
                List<TemplateTechnique> techniques = new List<TemplateTechnique>();
                var templateTechniques = await _templateProjectDbContext.TemplateTechnique.Where(o=>o.TemplateProjectId==id).ToListAsync();
                foreach(TemplateTechnique templateTechnique in templateTechniques)
                {
                    List<TemplateTechniqueItem> templateTechniqueItems = await _templateProjectDbContext.TemplateTechniqueItem.Where(o => o.TemplateTechniqueId == id).ToListAsync();
                    templateTechnique.TemplateTechniqueItem=templateTechniqueItems;
                    techniques.Add(templateTechnique);
                }
                return templateTechniques;
            }
            catch (Exception ex)
            { return null; }
        }        

        public async Task<TemplateTechniqueItem> DetailTemplateTechniqueItem(int id)
        {
            try
            {
                return await _templateProjectDbContext.TemplateTechniqueItem.Where(m => m.TemplateTechniqueItemId == id).SingleAsync();
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateTechnique> DetailTemplateTechnique(int id)
        {
            try
            {
                await Task.Delay(1);
                TemplateTechnique templateTechnique = await _templateProjectDbContext.TemplateTechnique
                    .Where(o => o.TemplateTechniqueId == id).SingleAsync();
                List<TemplateTechniqueItem> templateTechniqueItems = await _templateProjectDbContext.TemplateTechniqueItem
                    .Where(o => o.TemplateTechniqueId == id).ToListAsync();
                templateTechnique.TemplateTechniqueItem = templateTechniqueItems;
                return templateTechnique;
            }
            catch (Exception ex)
            { return null; }
        }        

        public async Task<TemplateTechnique> CreateTemplateTechnique()
        {
            TemplateTechnique templateTechnique = new TemplateTechnique();
            await Task.Delay(1);
            return templateTechnique;
        }

        public async Task<TemplateTechnique> CreateTemplateTechnique(TemplateTechnique templateTechnique)
        {
            try
            {
                _templateProjectDbContext.TemplateTechnique.Add(templateTechnique);
                _templateProjectDbContext.TemplateTechniqueItem.AddRange(templateTechnique.TemplateTechniqueItem);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateTechnique;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateTechniqueItem> CreateTemplateTechniqueItem()
        {
            TemplateTechniqueItem templateTechniqueItem = new TemplateTechniqueItem();
            await Task.Delay(1);
            return templateTechniqueItem;
        }

        public async Task<TemplateTechniqueItem> CreateTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            try
            {
                await _templateProjectDbContext.TemplateTechniqueItem.AddAsync(templateTechniqueItem);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateTechniqueItem;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateTechnique> EditTemplateTechnique(int id)
        {
            try
            {
                TemplateTechnique templateTechnique = await _templateProjectDbContext.TemplateTechnique
                    .Where(o => o.TemplateTechniqueId == id).SingleAsync();
                List<TemplateTechniqueItem> templateTechniqueItems = await _templateProjectDbContext.TemplateTechniqueItem
                    .Where(o => o.TemplateTechniqueId == id).ToListAsync();
                templateTechnique.TemplateTechniqueItem = templateTechniqueItems;
                return templateTechnique;
            }
            catch (Exception ex)
            { return null; }
         }

        public async Task<TemplateTechnique> EditTemplateTechnique(TemplateTechnique templateTechnique)
        {
            try
            {
                _templateProjectDbContext.Update(templateTechnique);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateTechnique;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateTechniqueItem> EditTemplateTechniqueItem(int id)
        {
            try
            {
                return await _templateProjectDbContext.TemplateTechniqueItem
                .Where(o => o.TemplateTechniqueItemId == id).SingleAsync();
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateTechniqueItem> EditTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            try
            {
                _templateProjectDbContext.Update(templateTechniqueItem);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateTechniqueItem;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<List<TemplateTechniqueItem>> DetailTemplateTechniqueItems(int id)
        {
            try
            {
                return await _templateProjectDbContext.TemplateTechniqueItem.Where(m => m.TemplateTechniqueId == id).ToListAsync();
            }
            catch (Exception ex)
            { return null; }
        }

        public void DeleteTemplateTechnique(int id)
        {
            TemplateTechnique templateTechnique = DetailTemplateTechnique(id).Result;
            _templateProjectDbContext.TemplateTechnique.Remove(templateTechnique);
            _templateProjectDbContext.SaveChanges();
        }

        public void DeleteTemplateTechniqueItem(int id)
        {
            TemplateTechniqueItem templateTechniqueItem = DetailTemplateTechniqueItem(id).Result;
            _templateProjectDbContext.TemplateTechniqueItem.Remove(templateTechniqueItem);
            _templateProjectDbContext.SaveChanges();
        }
    }
}
