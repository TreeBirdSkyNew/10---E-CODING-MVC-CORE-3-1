using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestingWebApiTechniqueProject
{
    public class ValidationTests
    {
        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);

            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }

        [Theory]
        [InlineData(null, "templateTechniqueName0", "templateTechniqueVersion0", "templateTechniqueTitle0", "templateTechniqueDescription0", "TemplateTechniqueVersionNET",1,false)]
        public void TestModelValidation(
            int templateTechniqueId, 
            string? templateTechniqueName, 
            string? templateTechniqueVersion,
            string? templateTechniqueTitle,
            string? templateTechniqueDescription,
            string? templateTechniqueVersionNET,
            int templateProjectId,
            bool isValid)
        {
            var owner = new TemplateTechnique()
            {
                TemplateTechniqueId = templateTechniqueId,
                TemplateTechniqueName = templateTechniqueName,
                TemplateTechniqueVersion = templateTechniqueVersion,
                TemplateTechniqueTitle = templateTechniqueTitle,
                TemplateTechniqueDescription = templateTechniqueDescription,
                TemplateTechniqueVersionNET = templateTechniqueVersionNET,
                TemplateProjectId = templateProjectId
            };

            Assert.Equal(isValid, ValidateModel(owner));
        }
    }
}
