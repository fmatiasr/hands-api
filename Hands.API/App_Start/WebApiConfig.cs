using Hands.API.Utils;
using Hands.Dominio.Repositorios;
using Hands.Dominio.Servicos;
using Hands.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace Hands.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<ICaseRepository, CaseRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IProdutoRepository, ProdutoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<ICaseServico, CaseServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IProdutoServico, ProdutoServico>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
