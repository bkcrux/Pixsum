using AutoMapper;
using Pixsum.Entities;
using Pixsum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixsum.Services.Mappings
{
    public class DomainToModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            CreateMap<Account, AccountModel>();
            //TODO : Finish adding the rest of the models
        }

    }
}