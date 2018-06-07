using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjetLogoV1._0.Dtos;
using ProjetLogoV1._0.Models;

namespace ProjetLogoV1._0.App_Start
{
    public class MappingProfil : Profile
    {
        public MappingProfil()
        {
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<PatientDto, Patient>();

            Mapper.CreateMap<Praticien, PraticienDto>();
            Mapper.CreateMap<PraticienDto, Praticien>();

        }
    }
}