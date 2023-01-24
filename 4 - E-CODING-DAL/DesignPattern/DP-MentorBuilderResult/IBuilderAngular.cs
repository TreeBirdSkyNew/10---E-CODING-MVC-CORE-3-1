using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL.DesignPattern
{
    public interface IBuilderAngular
    {
        TemplateResultItem BuilderAngularApp(string item);
        TemplateResultItem BuilderAngularRounting(string item);
        TemplateResultItem BuilderAngularController(string item);
        TemplateResultItem BuilderAngularService(string item);
        TemplateResultItem BuilderAngularView(string item);

    }
}
