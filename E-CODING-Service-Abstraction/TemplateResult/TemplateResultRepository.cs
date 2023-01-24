using _4___E_CODING_DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{

    public class TemplateResultRepository : ITemplateResultRepository
    {
        private readonly TemplateProjectDbContext _templateProjectDbContext;
        public TemplateResultRepository() : base()
        {
            _templateProjectDbContext = new TemplateProjectDbContext();
        }

        public async Task<List<TemplateResult>> GetAllTemplateResult()
        {
            try
            {
                var templateResults = await _templateProjectDbContext.TemplateResult.ToListAsync();
                return templateResults;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateResult> DetailTemplateResult(int id)
        {
            try
            {
                 return await _templateProjectDbContext.TemplateResult.Where(m => m.TemplateResultId == id).SingleAsync();
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<List<TemplateResultItem>> DetailTemplateResultItems(int id)
        {
            try
            {
                return await _templateProjectDbContext.TemplateResultItem.Where(m => m.TemplateResultId == id).ToListAsync();
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateResultItem> DetailTemplateResultItem(int id)
        {
            try
            {
                return await _templateProjectDbContext.TemplateResultItem.Where(m => m.TemplateResultItemId == id).SingleAsync();
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateResult> CreateTemplateResult()
        {
            await Task.Delay(1);
            TemplateResult templateResult = new TemplateResult();
            return templateResult;
        }

        public async Task<TemplateResult> CreateTemplateResult(TemplateResult templateResult)
        {
            try
            {
                await _templateProjectDbContext.TemplateResult.AddAsync(templateResult);
                await _templateProjectDbContext.TemplateResultItem.AddRangeAsync(templateResult.TemplateResultItem);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateResult;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateResultItem> CreateTemplateResultItem()
        {
            await Task.Delay(1);
            TemplateResultItem templateResultItem = new TemplateResultItem();
            return templateResultItem;
        }

        public async Task<TemplateResultItem> CreateTemplateResultItem(TemplateResultItem templateResultItem)
        {
            try
            {
                await _templateProjectDbContext.TemplateResultItem.AddAsync(templateResultItem);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateResultItem;
            }
            catch (Exception ex)
            { return null; }
        }


        public async Task<TemplateResult> EditTemplateResult(TemplateResult templateResult)
        {
            return await CreateTemplateResult(templateResult);
        }

        public async Task<TemplateResultItem> EditTemplateResultItem(TemplateResultItem templateResultItem)
        {
            return await CreateTemplateResultItem(templateResultItem);
        }

        public void DeleteTemplateResult(int id)
        {
            TemplateResult templateResult = _templateProjectDbContext.TemplateResult.Where(m => m.TemplateResultId == id).Single();
            _templateProjectDbContext.SaveChanges();
        }        

    }

}
