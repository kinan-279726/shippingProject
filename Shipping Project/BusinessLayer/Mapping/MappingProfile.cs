using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DTO;
using DataAccess.Migrations;
using Domains;

namespace BusinessLayer.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // tables
        CreateMap<TbAboutUs , AboutUsDto>().ReverseMap();
        CreateMap<TbCarriers , CarriersDto>().ReverseMap();
        CreateMap<TbCities , CitesDto>().ReverseMap();
        CreateMap<TbCountries , CountriesDto>().ReverseMap();
        CreateMap<TbHomeSliders , HomeSlidersDto>().ReverseMap();
        CreateMap<TbPaymentMethod , PaymentMethodDto>().ReverseMap();
        CreateMap<TbSettings , SettingsDto>().ReverseMap();
        CreateMap<TbShipments , ShipmentsDto>().ReverseMap();
        CreateMap<TbShipmentStatus , ShipmentStatusDto>().ReverseMap();
        CreateMap<TbShipmentType , ShipmentTypeDto>().ReverseMap();
        CreateMap<TbSubscriptionPackages , SubscriptionPackagesDto>().ReverseMap();
        CreateMap<TbUsersReceivers , UsersReceiversDto>().ReverseMap();
        CreateMap<TbUsers , UsersDto>().ReverseMap();
        CreateMap<TbUsersSender , UsersSenderDto>().ReverseMap();
        CreateMap<TbUserSubscriptions , UserSubscriptionsDto>().ReverseMap();

        // views
        CreateMap<VwCiti , VwCitesDto>().ReverseMap();
    }
}
