using AutoMapper;
using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using ProjetoModeloDDD2.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.MVC.AutoMapper
{
    public class DominioToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDominioMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
        }

    }
}