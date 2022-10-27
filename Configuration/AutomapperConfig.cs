using AutoMapper;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace DevIO.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap(typeof(IPagedList<>), typeof(IPagedList<>));
            // CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            // CreateMap<ProdutoViewModel, Produto>();
            // CreateMap<Produto, ProdutoViewModel>()
            //  .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }
    }
}